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
    public class DAL_H001_TipoDocumento: I_H001_TipoDocumento
    {
        private string database;
        public DAL_H001_TipoDocumento(IConfiguration config)
        {
            database = config["Database:CNX"];
        }
        public IEnumerable<H001_TipoDocumento> ListarTipoDocumento(){
            List<H001_TipoDocumento> lst = new List<H001_TipoDocumento>();
     
                using (SqlConnection oConexion = new SqlConnection(database))
                {
             
                    SqlCommand cmd = new SqlCommand("SP_ConsultarTipoDocumento", oConexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                
                    try
                    {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        lst.Add(new H001_TipoDocumento()
                        {
                            IdTipoDocumento = Convert.ToInt32(dr["IdTipoDocumento"].ToString()),
                            Abreviatura = dr["Abreviatura"].ToString(),
           
                        });
                    }
                    dr.Close();

                    return lst;


                    }
                    catch (Exception ex)

                     {
                        lst = null;
                        return lst;
                    }
                }

            }

    }


}
    
