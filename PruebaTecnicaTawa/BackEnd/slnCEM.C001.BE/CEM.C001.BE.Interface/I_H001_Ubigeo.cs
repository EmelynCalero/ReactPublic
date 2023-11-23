using CEM.C001.BE.Model;
using System.Collections.Generic;


namespace CEM.C001.BE.Interface
{
    public interface I_H001_Ubigeo
    {
        IEnumerable<H001_Ubigeo> ListarDepartamento();
        IEnumerable<H001_Ubigeo> ListarProvincia(string psCodDepartamento);
        IEnumerable<H001_Ubigeo> ListarDistrito(string psCodDepartamento, string psCodProvincia);

    }
}
