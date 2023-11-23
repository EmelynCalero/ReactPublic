using CEM.C001.BE.DAL;
using CEM.C001.BE.Interface;
using CEM.C001.BE.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace CEM.C001.BE.BLL
{
    public class BLL_H001_Ubigeo:IDisposable
    {
        readonly IConfiguration _configuration;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public BLL_H001_Ubigeo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<H001_Ubigeo> ListarDepartamento()
        {
            I_H001_Ubigeo instancia = new DAL_H001_Ubigeo(_configuration);
            return instancia.ListarDepartamento();
        }
        public IEnumerable<H001_Ubigeo> ListarProvincia(string psCodDepartamento)
        {
            I_H001_Ubigeo instancia = new DAL_H001_Ubigeo(_configuration);
            return instancia.ListarProvincia(psCodDepartamento);
        }
        public IEnumerable<H001_Ubigeo> ListarDistrito(string psCodDepartamento, string psCodProvincia)
        {
            I_H001_Ubigeo instancia = new DAL_H001_Ubigeo(_configuration);
            return instancia.ListarDistrito(psCodDepartamento, psCodProvincia);
        }


    }
}
