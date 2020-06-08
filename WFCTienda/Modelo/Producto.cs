using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WFCTienda.Modelo
{
    [DataContract]public class Producto
    {
        [DataMember] public string Codigo_P { get; set; }
        [DataMember] public string Codigo_CP { get; set; }
        [DataMember] public string Codigo_MP { get; set; }
        [DataMember] public string Descripcion_P { get; set; }
        [DataMember] public decimal Precio_P { get; set; }
        [DataMember] public decimal Stock_P { get; set; }
        [DataMember] public string Imagen_P { get; set; }
        [DataMember] public string Estado_P { get; set; }
    }
}