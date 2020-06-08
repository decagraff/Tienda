using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WFCTienda.Modelo
{
    [DataContract]public class Clase
    {
        [DataMember] public string codigo_cp { get; set; }
        [DataMember] public string nombre_cp { get; set; }
        [DataMember] public string estado_cp { get; set; }
    }
}