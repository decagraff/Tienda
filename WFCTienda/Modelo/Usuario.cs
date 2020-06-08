using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WFCTienda.Modelo
{
    [DataContract]
    public class Usuario
    {
        [DataMember] public string Codigo_U { get; set; }
        [DataMember] public string Nombres_U { get; set; }
        [DataMember] public string Apellidos_U { get; set; }
        [DataMember] public string Dni_U { get; set; }
        [DataMember] public string Email_U { get; set; }
        [DataMember] public string Departamento_U { get; set; }
        [DataMember] public string Provincia_U { get; set; }
        [DataMember] public string Distrito_U { get; set; }
        [DataMember] public string Direccion1_U { get; set; }
        [DataMember] public string Telefono_U { get; set; }
        [DataMember] public string Id_U { get; set; }
        [DataMember] public string Clave_U { get; set; }
        [DataMember] public string Tipo_U { get; set; }
        [DataMember] public string Estado_U { get; set; }
        

    }
}


/* private string { get; set; }
        private string { get; set; }
        private string { get; set; }
        private string { get; set; }
        private string { get; set; }
        private string { get; set; }
        private string { get; set; }
        private string{ get; set; }*/
