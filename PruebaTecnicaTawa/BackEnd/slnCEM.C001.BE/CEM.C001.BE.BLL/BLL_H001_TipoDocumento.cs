using CEM.C001.BE.DAL;
using CEM.C001.BE.Interface;
using CEM.C001.BE.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace CEM.C001.BE.BLL
{
    public class BLL_H001_TipoDocumento: IDisposable
    {
        readonly IConfiguration _configuration;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public BLL_H001_TipoDocumento(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<H001_TipoDocumento> ListarTipoDocumento()
        {
            I_H001_TipoDocumento instancia = new DAL_H001_TipoDocumento(_configuration);
            return instancia.ListarTipoDocumento();
        }





    }
}
