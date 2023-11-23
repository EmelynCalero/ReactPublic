using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Text;

namespace CEM.C001.BE.Model
{
    public class H001_Persona
    {
		[DataMember]
		public string CodPersona { get; set; }
		[DataMember]
		public int IdTipoDocumento { get; set; }
		[DataMember]
		public string DNI { get; set; }
		[DataMember]
		public string NumDocIdentidad { get; set; }
		[DataMember]
		public string Nombre { get; set; }
		[DataMember]
		public string Nombres { get; set; }

		[DataMember]
		public string ApellidoPaterno { get; set; }
		[DataMember]
		public string ApellidoMaterno { get; set; }
		[DataMember]
		public string IdSexo { get; set; }
		[DataMember]
		public string Sexo { get; set; }
		[DataMember]
		public DateTime FechaNacimiento { get; set; }
		[DataMember]
		public int IdPertenenciaEtnica { get; set; }
		[DataMember]
		public int IdPaisNacimiento { get; set; }
		
		[DataMember]
		public string CodDepartamento { get; set; }
		[DataMember]
		public string Departamento { get; set; }
		[DataMember]
		public string CodProvincia { get; set; }
		[DataMember]
		public string Provincia { get; set; }
		[DataMember]
		public string CodUbigeo { get; set; }
		[DataMember]
		public string Distrito { get; set; }
		[DataMember]
		public string Foto { get; set; }
		[DataMember]
		public int IdGradoInstruccion { get; set; }
		[DataMember]
		public int IdReligion { get; set; }
		[DataMember]
		public string CentroEducativo { get; set; }
		[DataMember]
		public int IdEstadoCivil { get; set; }
		[DataMember]
		public int IdOcupacion { get; set; }
		[DataMember]
		public string TelefonoFijo { get; set; }
		[DataMember]
		public string TelefonoMovil { get; set; }
		[DataMember]
		public string Correo { get; set; }
		[DataMember]
		public int IdTipoPersona { get; set; }
		[DataMember]
		public bool IndTratamientoDatos { get; set; }
		[DataMember]
		public string IdUsuCreaRegistro { get; set; }
		[DataMember]
		public DateTime FechaCreaRegistro { get; set; }
		[DataMember]
		public string IdUsuModificaRegistro { get; set; }
		[DataMember]
		public DateTime FechaModificaRegistro { get; set; }
		[DataMember]
		public bool EstadoRegistro { get; set; }

		[DataMember]
		public string NombreCompleto { get; set; }
		[DataMember]
		public string CodUbigeoNacimiento { get; set; }

		[DataMember]
		public string Direccion { get; set; }
		[DataMember]
		public string Password { get; set; }
		[DataMember]
		public string ConfirmarPassword { get; set; }
		[DataMember]
		public int Edad { get; set; }
		[DataMember]
		public string TipoDocumento { get; set; }
		[DataMember]
		public string Abreviatura { get; set; }
		
			[DataMember]
		public string CodUsuario { get; set; }
	}
}