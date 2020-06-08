using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WFCTienda.Modelo;

namespace WFCTienda
{
    
    [ServiceContract]
    public interface IService1
    {
        [OperationContract] List<Producto> listado();
        [OperationContract] List<Clase> clases();
        [OperationContract] List<Marca> marcas();
        [OperationContract] string Agregar(Producto reg, HttpPostedFileBase archivo);
        [OperationContract] string Editar(Producto reg, HttpPostedFileBase archivo);
        [OperationContract] string Eliminar(string idprod);
        [OperationContract] Producto Buscar(string idprod);
    }
}
