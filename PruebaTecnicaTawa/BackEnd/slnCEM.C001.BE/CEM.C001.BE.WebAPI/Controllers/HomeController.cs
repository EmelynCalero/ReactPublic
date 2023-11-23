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

namespace CEM.CLC.BackEnd.WebAPI.Controllers
{
   
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HomeController : ControllerBase
    {

        readonly IConfiguration _configuration;
        string[] configuracion = new String[10];
        public HomeController(IConfiguration configuration)
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

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] Usuario userParam)
        {
            try
            {
                //_logger.ToFile(1, "UsuarioController.autenticarse :: Inicio");

                //UserFachada _userService = new UserFachada(_configuration);

                //var user = _userService.Autenticarse(userParam.Email, userParam.Password);

                //if (user.IDUsuario == 0) {                 
                //    user.Token = null;
                //    return BadRequest(new { message = "Inicio de sesión no válido." });
                //}

                var vGC_Usuario = new Usuario();
                //Datos de prueba como si se hubiera logueado correctamente
                vGC_Usuario.Login = userParam.Login;
                vGC_Usuario.Nombres = "Andree.Galdos";

                string securityKey = _configuration.GetSection("AppSettings:Token").Value;
                var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
                var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha512Signature);
                var token = new JwtSecurityToken(                       
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: signingCredentials
                    );

                //Setea el nuevo token
                vGC_Usuario.Token = new JwtSecurityTokenHandler().WriteToken(token);

                //return Ok(new { token = tokenHandler, usuario = "Andree Galdos" });

                return Ok(vGC_Usuario);

            }
            catch (Exception ex) {               
                return BadRequest(new { message = "Ha ocurrido un error inesperado. Contacte con el administrador de la aplicación." });
            }
        }

        //[AllowAnonymous]
        [HttpGet("getListarTipoConsulta")]
        public IEnumerable<GC_Tipo_Consulta> getListarTipoConsulta()
        {
            try
            {
                //_logger.ToFile(1, "UserController.ListarUser :: Ejecutando..");

                using (BLL_GC_Tipo_Consulta instancia = new BLL_GC_Tipo_Consulta(_configuration))
                {
                    return instancia.ListarTipoConsulta(3);
                }
            }
            catch (Exception ex)
            {
                //_logger.ToFile(2, "UserController.ListarUser :: " + ex.Message + " :: " + ex.StackTrace);
                return null;
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

                int oresultado = 0;

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

        [AllowAnonymous]
        [HttpPost("InsertarTipoConsultav2")]
        public IActionResult InsertarTipoConsultav2([FromBody] string inputParam)
        {
            try
            {

                GC_Tipo_Consulta userParam = JsonConvert.DeserializeObject<GC_Tipo_Consulta>(inputParam);

                //string Usuario = Request.Form["Usuario"];     
                //string Contraseña = Request.Form["Contraseña"];

                //_logger.ToFile(1, "UsuarioController.AutenticarseAD :: Iniciando. Usuario: " + Usuario);

                int oresultado = 0;

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

        //[HttpGet]
        //public IEnumerable<GC_Tipo_Consulta> getListarTipoConsulta1()
        //{
        //    try
        //    {
        //        //_logger.ToFile(1, "UserController.ListarUser :: Ejecutando..");

        //        using (BLL_GC_Tipo_Consulta instancia = new BLL_GC_Tipo_Consulta(_configuration))
        //        {
        //            return instancia.ListarTipoConsulta(3);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //_logger.ToFile(2, "UserController.ListarUser :: " + ex.Message + " :: " + ex.StackTrace);
        //        return null;
        //    }
        //}



    }
}
