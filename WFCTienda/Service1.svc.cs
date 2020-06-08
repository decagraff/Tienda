using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WFCTienda.Modelo;
using System.Data;
using System.Data.SqlClient;


namespace WFCTienda
{

    public class Service1 : IService1
    {
        public string Agregar(Producto reg, HttpPostedFileBase archivo)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection("server=.;database=Tienda;uid=sa;pwd=sql"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(
                    "Insert producto Values(@codp,@codcp,@codmp,@des,@precio,@stock,@img,@estado)", cn);
                    cmd.Parameters.AddWithValue("@codp", reg.Codigo_P);
                    cmd.Parameters.AddWithValue("@codcp", reg.Codigo_CP);
                    cmd.Parameters.AddWithValue("@codmp", reg.Codigo_MP);
                    cmd.Parameters.AddWithValue("@des", reg.Descripcion_P);
                    cmd.Parameters.AddWithValue("@precio", reg.Precio_P);
                    cmd.Parameters.AddWithValue("@stock", reg.Stock_P);
                    cmd.Parameters.AddWithValue("@img", "/Fotos/ " + System.IO.Path.GetFileName(archivo.FileName));
                    cmd.Parameters.AddWithValue("@estado", reg.Estado_P);
                    cn.Open();
                    cmd.ExecuteNonQuery();//ejecutar
                    mensaje = "Cliente Agregado";
                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }


        public Producto Buscar(string idprod)
        {
            return listado().Where(c => c.Codigo_P == idprod).FirstOrDefault();
        }

        public List<Clase> clases()
        {
            List<Clase> temporal = new List<Clase>();
            using (SqlConnection cn = new SqlConnection("server=.;database=Tienda;uid=sa;pwd=sql"))
            {
                SqlCommand cmd = new SqlCommand("MOSTRAR_CLASE_PRODUCTO_HABILITADOS", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Clase reg = new Clase()
                    {
                        codigo_cp = dr.GetString(0),
                        nombre_cp = dr.GetString(1),
                        estado_cp = dr.GetString(2),                       

                    };
                    temporal.Add(reg);
                }
                dr.Close(); cn.Close();
            }

            return temporal;
        }

        public string Editar(Producto reg, HttpPostedFileBase archivo)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection("server=.;database=Tienda;uid=sa;pwd=sql"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Update producto Set Codigo_CP=@codcp," +
                    "Codigo_MP=@codmp,Descripcion_P=@des,Precio_P=@precio,Stock_P=@stock,Imagen_P=@img,Estado_P=@estado Where Codigo_P=@codp", cn);

                    cmd.Parameters.AddWithValue("@codp", reg.Codigo_P);
                    cmd.Parameters.AddWithValue("@codcp", reg.Codigo_CP);
                    cmd.Parameters.AddWithValue("@codmp", reg.Codigo_MP);
                    cmd.Parameters.AddWithValue("@des", reg.Descripcion_P);
                    cmd.Parameters.AddWithValue("@precio", reg.Precio_P);
                    cmd.Parameters.AddWithValue("@stock", reg.Stock_P);
                    cmd.Parameters.AddWithValue("@img", "/Fotos/ "+ System.IO.Path.GetFileName(archivo.FileName));
                    cmd.Parameters.AddWithValue("@estado", reg.Estado_P);
                    cn.Open();
                    cmd.ExecuteNonQuery();//ejecutar
                    mensaje = "Producto Actualizado";
                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }

        public string Eliminar(string idprod)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection("server=.;database=Tienda;uid=sa;pwd=sql"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("ELIMINAR_PRODUCTO", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cod", idprod);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    mensaje = "Producto Eliminado";
                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }

        public List<Producto> listado()
        {
            List<Producto> temporal = new List<Producto>();
            using (SqlConnection cn = new SqlConnection("server=.;database=Tienda;uid=sa;pwd=sql")) 
            {
                SqlCommand cmd = new SqlCommand("MOSTRAR_PRODUCTOS_HABILITADOS", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Producto reg = new Producto()
                    {
                        Codigo_P = dr.GetString(0),
                        Codigo_CP = dr.GetString(1),
                        Codigo_MP = dr.GetString(2),
                        Descripcion_P = dr.GetString(3),
                        Precio_P = dr.GetDecimal(4),
                        Imagen_P=dr.GetString(5),
                        Estado_P=dr.GetString(6),                       

                    };
                    temporal.Add(reg);
                }
                dr.Close(); cn.Close();
            }

            return temporal;
            }        

        public List<Marca> marcas()
        {
            List<Marca> temporal = new List<Marca>();
            using (SqlConnection cn = new SqlConnection("server=.;database=Tienda;uid=sa;pwd=sql"))
            {
                SqlCommand cmd = new SqlCommand("MOSTRAR_MARCA_PRODUCTO_HABILITADOS", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Marca reg = new Marca()
                    {
                        codigo_mp = dr.GetString(0),
                        nombre_mp = dr.GetString(1),
                        estado = dr.GetString(2)
                    };
                    temporal.Add(reg);
                }
                dr.Close(); cn.Close();
            }
            return temporal;
        }
    }
}

