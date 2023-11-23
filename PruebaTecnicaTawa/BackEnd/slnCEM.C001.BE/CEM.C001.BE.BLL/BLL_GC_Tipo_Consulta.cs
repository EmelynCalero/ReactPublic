using CEM.C001.BE.DAL;
using CEM.C001.BE.Interface;
using CEM.C001.BE.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace CEM.C001.BE.BLL
{
    public class BLL_GC_Tipo_Consulta : IDisposable
    {

        readonly IConfiguration _configuration;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public BLL_GC_Tipo_Consulta(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<GC_Tipo_Consulta> ListarTipoConsulta(int pIdTipoConsulta)
        {
            IGC_Tipo_Consulta instancia = new DAL_GC_Tipo_Consulta(_configuration);
            return instancia.ListarTipoConsulta(pIdTipoConsulta);
        }

        public int InsertarTipoConsulta(GC_Tipo_Consulta data){
            {
                IGC_Tipo_Consulta instancia = new DAL_GC_Tipo_Consulta(_configuration);
                return instancia.InsertarTipoConsulta(data);
            }
        }

    }
}
