using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WFCTienda.Modelo
{
    [DataContract]public class Venta
    {
        [DataMember] public string Codigo_V { get; set; }
        [DataMember] public string Codigo_U { get; set; }
        [DataMember] public string Total { get; set; }
        [DataMember] public string Fecha { get; set; }
    }
}