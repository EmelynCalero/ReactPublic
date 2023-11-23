using System;

namespace CEM.C001.BE.Model
{
    public class GC_Tipo_Consulta {      
        public int IdTipoConsulta { get; set; }
        
        public string TipoConsulta { get; set; }

               
        public string IdUsuCreaRegistro { get; set; }

        public DateTime? FechaCreaRegistro { get; set; }

        
        public string IdUsuModificaRegistro { get; set; }

        public bool? EstadoRegistro { get; set; }

    }
}
