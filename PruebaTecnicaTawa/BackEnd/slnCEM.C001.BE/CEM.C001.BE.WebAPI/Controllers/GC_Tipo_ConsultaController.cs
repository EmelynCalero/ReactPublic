using CEM.C001.BE.BLL;
using CEM.C001.BE.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace CEM.CLC.BackEnd.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Authorize]
    public class GC_Tipo_ConsultaController : ControllerBase
    {

        readonly IConfiguration _configuration;
        string[] configuracion = new String[10];
        //private Logger _logger = new Logger();


        public GC_Tipo_ConsultaController(IConfiguration configuration)
        {
            try
            {
                _configuration = configuration;
                configuracion[0] = _configuration["ActiveDirectory:LDAP_DOMAIN"];
                configuracion[1] = _configuration["ActiveDirectory:LDAP_PORT"];
                configuracion[2] = _configuration["ActiveDirectory:LDAP_PATH"];
            }
            catch (Exception ex)
            {
                //_logger.ToFile(2, "UsuarioController.UsuarioController :: " + ex.Message + " :: " + ex.StackTrace);
            }
        }
        [HttpGet("ListarTipoConsulta")]
        public IEnumerable<GC_Tipo_Consulta> ListarTipoConsulta(int pIdTipoConsulta)
        {
            try
            {
                //_logger.ToFile(1, "UserController.ListarUser :: Ejecutando..");

                using (BLL_GC_Tipo_Consulta instancia = new BLL_GC_Tipo_Consulta(_configuration))
                {
                    return instancia.ListarTipoConsulta(pIdTipoConsulta);
                }
            }
            catch (Exception ex)
            {
                //_logger.ToFile(2, "UserController.ListarUser :: " + ex.Message + " :: " + ex.StackTrace);
                return null;
            }
        }

        [AllowAnonymous]
        [HttpPost("InsertarTipoConsulta")]
        public IActionResult InsertarTipoConsulta([FromBody] GC_Tipo_Consulta userParam)
        {
            try
            {
                //string Usuario = Request.Form["Usuario"];
                //string Contraseña = Request.Form["Contraseña"];

                //_logger.ToFile(1, "UsuarioController.AutenticarseAD :: Iniciando. Usuario: " + Usuario);

                int oresultado =0;

                using (BLL_GC_Tipo_Consulta instancia = new BLL_GC_Tipo_Consulta(_configuration))
                {
                    oresultado = instancia.InsertarTipoConsulta(userParam);
                }

                //if (user.Estado == "Z")
                //{
                //    _logger.ToFile(1, "UsuarioController.AutenticarseAD :: Intento de acceso con contraseña incorrecta");
                //    return BadRequest(new { message = "Credenciales no válidas. Por favor, revise su usuario y contraseña." });
                //}

                //if (user.IDUsuario == 0)
                //{
                //    _logger.ToFile(1, "UsuarioController.AutenticarseAD :: IDUsuario = 0 ");
                //}

                //_logger.ToFile(1, "UsuarioController.AutenticarseAD :: Autenticación OK");
                return Ok(oresultado);

            }
            catch (Exception ex)
            {
                //_logger.ToFile(2, "UsuarioController.AutenticarseAD :: " + ex.Message + " :: " + ex.StackTrace);
                return BadRequest(new { message = "Ha ocurrido un error inesperado. Contacte con el administrador de la aplicación." });
            }
        }


        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
