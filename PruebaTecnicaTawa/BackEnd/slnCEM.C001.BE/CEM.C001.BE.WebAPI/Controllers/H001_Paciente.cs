using CEM.C001.BE.BLL;
using CEM.C001.BE.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CEM.C001.BE.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Authorize]
    public class H001_Paciente : ControllerBase{
        readonly IConfiguration _configuration;
   
        public H001_Paciente(IConfiguration configuration){           
               _configuration = configuration;           
        }   
      

        [AllowAnonymous]
        [HttpPost("InsertarPaciente")]
        public IActionResult InsertarPaciente([FromBody] H001_Persona poH001_Persona){
            try{
                using (BLL_H001_Persona instancia = new BLL_H001_Persona(_configuration))
                {
                    return Ok(instancia.InsertarPersona(poH001_Persona));
                }
            }
            catch (Exception ex){
                return null;
            }
            
        }
       
    }
}