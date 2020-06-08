using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tienda.ServiceReference1;


namespace Tienda.Controllers
{
    public class TiendaController : Controller
    {
        Service1Client servicio = new Service1Client();
        public ActionResult Index()
        {
            return View(servicio.listado());
        }

        public ActionResult Details(string id)
        {
            if (id == null) return RedirectToAction("Index");

            Producto reg = servicio.Buscar(id);

            return View(reg);
        }
        public ActionResult Create()
        {

            ViewBag.clases = new SelectList(
                servicio.clases(), "codigo_cp", "nombre_cp");
            ViewBag.marcas = new SelectList(
                servicio.marcas(), "codigo_mp", "nombre_mp");

            return View(new Producto());

        }
        [HttpPost]
        public ActionResult Create(Producto reg,HttpPostedFileBase archivo)
        {

            ViewBag.mensaje = servicio.Agregar(reg,archivo);


            ViewBag.clases = new SelectList(
               servicio.clases(), "codigo_cp", "nombre_cp",reg.Codigo_CP);
            ViewBag.marcas = new SelectList(
                servicio.marcas(), "codigo_mp", "nombre_mp",reg.Codigo_MP);

            return View(reg);

        }
        public ActionResult Edit(string id)
        {
            if (id == null) return RedirectToAction("Index");

            Producto reg = servicio.Buscar(id);
            ViewBag.clases = new SelectList(
              servicio.clases(), "codigo_cp", "nombre_cp", reg.Codigo_CP);
            ViewBag.marcas = new SelectList(
                servicio.marcas(), "codigo_mp", "nombre_mp", reg.Codigo_MP);

            return View(reg);
        }
        [HttpPost]
        public ActionResult Edit(Producto reg, HttpPostedFileBase archivo)
        {
            ViewBag.mensaje = servicio.Editar(reg,archivo);

            ViewBag.clases = new SelectList(
              servicio.clases(), "codigo_cp", "nombre_cp", reg.Codigo_CP);
            ViewBag.marcas = new SelectList(
                servicio.marcas(), "codigo_mp", "nombre_mp", reg.Codigo_MP);

            return View(reg);
        }

    }
}