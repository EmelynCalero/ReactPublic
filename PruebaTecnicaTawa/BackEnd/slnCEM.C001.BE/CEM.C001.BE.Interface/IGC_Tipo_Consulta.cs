using CEM.C001.BE.Model;
using System.Collections.Generic;

namespace CEM.C001.BE.Interface
{
    public interface IGC_Tipo_Consulta
    {
        int InsertarTipoConsulta(GC_Tipo_Consulta data);

        IEnumerable<GC_Tipo_Consulta> ListarTipoConsulta(int pIdTipoConsulta);

    }
}
