using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WFCTienda.Modelo
{
    [DataContract]public class Marca
    {
        [DataMember]public string codigo_mp { get; set; }
        [DataMember] public string nombre_mp { get; set; }
        [DataMember] public string estado { get; set; }
    }
}