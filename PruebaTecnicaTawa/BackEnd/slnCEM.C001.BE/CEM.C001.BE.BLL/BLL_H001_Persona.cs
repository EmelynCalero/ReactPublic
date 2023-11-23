using CEM.C001.BE.DAL;
using CEM.C001.BE.Interface;
using CEM.C001.BE.Model;
using Microsoft.Extensions.Configuration;
using System;

namespace CEM.C001.BE.BLL
{
    public class BLL_H001_Persona : IDisposable
    {
        readonly IConfiguration _configuration;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public BLL_H001_Persona(IConfiguration configuration)
        {
            _configuration = configuration;
        }             
     

        public bool InsertarPersona(H001_Persona data)
        {
            {
                I_H001_Persona instancia = new DAL_H001_Persona(_configuration);               
                return instancia.InsertarPersona(data);
            }
        }       

    }
}
