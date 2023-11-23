using CEM.C001.BE.Interface;
using CEM.C001.BE.Model;

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CEM.C001.BE.DAL{
    public class DAL_H001_Persona : I_H001_Persona
    {
        private string database;

        public DAL_H001_Persona(IConfiguration config)
        {
            database = config["Database:CNX"];
        }
    
        public bool InsertarPersona(H001_Persona poH001_Persona){

            using (SqlConnection oConexion = new SqlConnection(database))
            {

                SqlCommand cmd = new SqlCommand("SP_RegistrarPaciente", oConexion);
         
                cmd.Parameters.AddWithValue("@IdTipoDocumento", poH001_Persona.IdTipoDocumento);
                cmd.Parameters.AddWithValue("@NumDocIdentidad", poH001_Persona.NumDocIdentidad);
                cmd.Parameters.AddWithValue("@Nombre", poH001_Persona.Nombre);
                cmd.Parameters.AddWithValue("@ApellidoPaterno", poH001_Persona.ApellidoPaterno);
                cmd.Parameters.AddWithValue("@ApellidoMaterno", poH001_Persona.ApellidoMaterno);
                cmd.Parameters.AddWithValue("@Sexo", poH001_Persona.Sexo);
                cmd.Parameters.AddWithValue("@FechaNacimiento", poH001_Persona.FechaNacimiento);
                cmd.Parameters.AddWithValue("@IdPertenenciaEtnica", poH001_Persona.IdPertenenciaEtnica);
                cmd.Parameters.AddWithValue("@IdPaisNacimiento", poH001_Persona.IdPaisNacimiento);
                cmd.Parameters.AddWithValue("@CodUbigeoNacimiento", poH001_Persona.CodUbigeoNacimiento);
                cmd.Parameters.AddWithValue("@Foto", poH001_Persona.Foto);
                cmd.Parameters.AddWithValue("@IdGradoInstruccion", poH001_Persona.IdGradoInstruccion);
                cmd.Parameters.AddWithValue("@IdReligion", poH001_Persona.IdReligion);
                cmd.Parameters.AddWithValue("@CentroEducativo", poH001_Persona.CentroEducativo);
                cmd.Parameters.AddWithValue("@IdEstadoCivil", poH001_Persona.IdEstadoCivil);
                cmd.Parameters.AddWithValue("@IdOcupacion", poH001_Persona.IdOcupacion);
                cmd.Parameters.AddWithValue("@TelefonoFijo", poH001_Persona.TelefonoFijo);
                cmd.Parameters.AddWithValue("@TelefonoMovil", poH001_Persona.TelefonoMovil);
                cmd.Parameters.AddWithValue("@Correo" ,poH001_Persona.Correo);               
                cmd.Parameters.AddWithValue("@IdTipoPersona", poH001_Persona.IdTipoPersona);
                cmd.Parameters.AddWithValue("@TratamientoDato", poH001_Persona.IndTratamientoDatos);
                cmd.Parameters.AddWithValue("@TerminoCondicion", poH001_Persona.IndTratamientoDatos);
                cmd.Parameters.AddWithValue("@CodUsuario", poH001_Persona.CodUsuario);
                cmd.Parameters.AddWithValue("@CodUsuCreaRegistro", poH001_Persona.CodUsuario);
                cmd.Parameters.AddWithValue("@FechaCreaRegistro", poH001_Persona.FechaCreaRegistro);
                cmd.Parameters.AddWithValue("@CodUsuModificaRegistro", poH001_Persona.CodUsuario);
                cmd.Parameters.AddWithValue("@FechaModificaRegistro", poH001_Persona.FechaModificaRegistro);
                cmd.Parameters.AddWithValue("@EstadoRegistro" ,poH001_Persona.EstadoRegistro);
                cmd.CommandType = CommandType.StoredProcedure;


                try
                {
                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    return true;

                }
                catch (Exception ex)

                {
                    return false;
                }
      

            }

        }
    }
}