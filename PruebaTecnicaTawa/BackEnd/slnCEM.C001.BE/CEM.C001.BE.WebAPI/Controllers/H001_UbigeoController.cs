using CEM.C001.BE.BLL;
using CEM.C001.BE.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace CEM.C001.BE.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Authorize]

    public class H001_UbigeoController : ControllerBase
    {
        readonly IConfiguration _configuration;
        
        public H001_UbigeoController(IConfiguration configuration){           
             _configuration = configuration;           
        }

        [AllowAnonymous]
        [HttpGet("ListarDepartamento")]
        public IActionResult ListarDepartamento()
        {
            try{
                using (BLL_H001_Ubigeo instancia = new BLL_H001_Ubigeo(_configuration))
                {
                    return Ok(instancia.ListarDepartamento());

                }

            }
            catch (Exception ex)
            {
                return null;
            }
           
        }

        [AllowAnonymous]
        [HttpGet("ListarProvincia/{psCodDepartamento}")]
        public IActionResult ListarProvincia(string psCodDepartamento)
        {
            try
            {
                using (BLL_H001_Ubigeo instancia = new BLL_H001_Ubigeo(_configuration))
                {
                    return Ok(instancia.ListarProvincia(psCodDepartamento));

                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        [AllowAnonymous]
        [HttpGet("ListarDistrito/{psCodDepartamento}/{psCodProvincia}")]
        public IActionResult ListarDistrito(string psCodDepartamento, string psCodProvincia)
        {
            try
            {
                using (BLL_H001_Ubigeo instancia = new BLL_H001_Ubigeo(_configuration))
                {
                    return Ok(instancia.ListarDistrito(psCodDepartamento, psCodProvincia));

                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}
