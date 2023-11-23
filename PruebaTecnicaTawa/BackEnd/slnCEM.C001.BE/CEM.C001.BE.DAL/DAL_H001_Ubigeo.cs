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
    public class DAL_H001_Ubigeo:I_H001_Ubigeo
    {
        private string database;
        public DAL_H001_Ubigeo(IConfiguration config)
        {
            database = config["Database:CNX"];
        }
   
        public IEnumerable<H001_Ubigeo> ListarDepartamento(){
            List<H001_Ubigeo> lst = new List<H001_Ubigeo>();
            using (SqlConnection oConexion = new SqlConnection(database))
            {

                SqlCommand cmd = new SqlCommand("SP_ConsultarDepartamentos", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        lst.Add(new H001_Ubigeo()
                        {
                            //CodUbigeo = dr["CodUbigeo"].ToString(),
                            CodDepartamento = dr["CodDepartamento"].ToString(),
                            Departamento = dr["Departamento"].ToString()

   

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

        public IEnumerable<H001_Ubigeo> ListarProvincia(string psCodDepartamento){
            List<H001_Ubigeo> lst = new List<H001_Ubigeo>();
            using (SqlConnection oConexion = new SqlConnection(database))
            {

                SqlCommand cmd = new SqlCommand("SP_ConsultarPronvicias", oConexion);
                cmd.Parameters.AddWithValue("@CodDepartamento", psCodDepartamento);
                cmd.CommandType = CommandType.StoredProcedure;


                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        lst.Add(new H001_Ubigeo()
                        {
                            //CodUbigeo = dr["CodUbigeo"].ToString(),
                            CodDepartamento = dr["CodDepartamento"].ToString(),
                            CodProvincia = dr["CodProvincia"].ToString(),
                            Provincia = dr["Provincia"].ToString()



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

        public IEnumerable<H001_Ubigeo> ListarDistrito(string psCodDepartamento, string psCodProvincia)
        {
            List<H001_Ubigeo> lst = new List<H001_Ubigeo>();
            using (SqlConnection oConexion = new SqlConnection(database))
            {

                SqlCommand cmd = new SqlCommand("SP_ConsultarDistritos", oConexion);
                cmd.Parameters.AddWithValue("@CodDepartamento", psCodDepartamento);
                cmd.Parameters.AddWithValue("@CodProvincia", psCodProvincia );
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        lst.Add(new H001_Ubigeo()
                        {
                            CodUbigeo = dr["CodUbigeo"].ToString(),
                            CodDepartamento = dr["CodDepartamento"].ToString(),
                            CodProvincia = dr["CodProvincia"].ToString(),
                            Distrito = dr["Distrito"].ToString()



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