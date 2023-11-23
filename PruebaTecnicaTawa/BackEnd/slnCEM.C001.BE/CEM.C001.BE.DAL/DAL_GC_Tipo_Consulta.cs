using CEM.C001.BE.Interface;
using CEM.C001.BE.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CEM.C001.BE.DAL
{
    public class DAL_GC_Tipo_Consulta : IGC_Tipo_Consulta
    {
        private string database;
        //private Logger _logger = new Logger();

        public DAL_GC_Tipo_Consulta(IConfiguration config)
        {
            database = config["Database:Repository"];
            //byte[] decryted = Convert.FromBase64String(database);
            //database = System.Text.Encoding.Unicode.GetString(decryted);
        }

        public IEnumerable<GC_Tipo_Consulta> ListarTipoConsulta(int pIdTipoConsulta)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(database))
                {
                    conexion.Open();

                    var parametros = new DynamicParameters();
                    parametros.Add("pIdTipoConsulta", pIdTipoConsulta);
                    var lista = conexion.Query<GC_Tipo_Consulta>("USP_LISTAR_TIPO_CONSULTA", param: parametros, commandType: CommandType.StoredProcedure);
                    return lista;
                }
            }
            catch (Exception ex)
            {
                //_logger.ToFile(2, "ClienteRepositorio.ListarClientes :: " + ex.Message.ToString());
                return null;
            }
        }

        public int InsertarTipoConsulta(GC_Tipo_Consulta data){
            try
            {
                using (IDbConnection conexion = new SqlConnection(database))
                {
                    conexion.Open();
                    var parametros = new DynamicParameters();
                    parametros.Add("pIdTipoConsulta", data.IdTipoConsulta);
                    parametros.Add("pTipoConsulta", data.TipoConsulta);
                    parametros.Add("pIdUsuCreaRegistro", data.IdUsuCreaRegistro);
                    parametros.Add("pEstadoRegistro", data.EstadoRegistro);
                    //parametros.Add("pIdUsuCreaRegistro", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    conexion.Execute("USP_INSERTAR_TIPO_CONSULTA", param: parametros, commandType: CommandType.StoredProcedure);

                    //return parametros.Get<int>("Resultado");
                    return 1;
                }
            }
            catch (Exception ex)
            {
                //_logger.ToFile(2, "ComentarioDetalleRepositorio.RegistrarComentarioDetalle :: " + ex.Message.ToString());
                return 0;
            }
        }


    }
}
