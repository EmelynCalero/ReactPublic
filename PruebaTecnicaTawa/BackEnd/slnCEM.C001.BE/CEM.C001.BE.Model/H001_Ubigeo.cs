using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace CEM.C001.BE.Model
{
    public class H001_Ubigeo
    {
        
        [DataMember]
        public string CodDepartamento { get; set; }
        [DataMember]
        public string Departamento { get; set; }
        [DataMember]
        public string CodProvincia { get; set; }
        [DataMember]
        public string Provincia { get; set; }
        [DataMember]
        public string CodUbigeo { get; set; }
        [DataMember]
        public string Distrito { get; set; }



        [DataMember]
        public string IdUsuCreaRegistro { get; set; }
        [DataMember]
        public DateTime? FechaCreaRegistro { get; set; }
        [DataMember]
        public string IdUsuModificaRegistro { get; set; }
        [DataMember]
        public DateTime? FechaModificaRegistro { get; set; }
        [DataMember]
        public bool? EstadoRegistro { get; set; }


    }
}
