using System;
using System.Runtime.Serialization;

namespace CEM.C001.BE.Model
{
    public class H001_TipoDocumento
    {
        [DataMember]
        public int IdTipoDocumento { get; set; }
        [DataMember]
        public string TipoDocumento { get; set; }
        [DataMember]
        public string Abreviatura { get; set; }
        [DataMember]
        public bool? EstadoRegistro { get; set; }
        [DataMember]
        public int? MaxNumDigito { get; set; }
    }
}
