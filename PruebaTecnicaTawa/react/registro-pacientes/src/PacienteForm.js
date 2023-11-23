import React, { useState, useEffect } from 'react';

const PacienteForm = ({ onAddPaciente, fetchTipoDocumento,fetchDepartamentos, fetchProvincias,fetchDistritos}) => {
    const [selectedTipoDocumento, setselectedTipoDocumento] = useState('');
    const [TipodDocumento, setTipodDocumento] = useState('');
  const [NumeroDocumento, setNumeroDocumento] = useState('');
  const [Nombre, setNombre] = useState('');
  const [ApellidoPaterno, setApellidoPaterno] = useState('');
  const [FechaNacimiento, setFechaNacimiento] = useState('');
  const [Sexo, setSexo] = useState('');
  const [Correo, setCorreo] = useState('');
  const [Celular, setCelular] = useState('');
  const [Direccion, setDireccion] = useState('');
  const [selectedDepartamentos, setselectedDepartamentos] = useState('');
  const [selectedProvincias, setselectedProvincias] = useState('');
  const [selectedDistritos, steselectedDistritos] = useState('');
  const [Departamento, setDepartamento] = useState([]);
  const [Provincia, setProvincia] = useState([]);
  const [Distrito, setDistrit] = useState([]);


  useEffect(() => {

    fetchTipoDocumento()
      .then(data => setselectedTipoDocumento(data))
      .catch(error => console.error('Error fetching TipoDocumento:', error));
  }, [fetchTipoDocumento]);

  useEffect(() => {

    fetchDepartamentos()
      .then(data => setselectedDepartamentos(data))
      .catch(error => console.error('Error fetching Departamentos:', error));
  }, [fetchDepartments]);


  useEffect(() => {
    if (selectedDepartment) {
      fetchProvincias(selectedDepartment)
        .then(data => setProvincias(data))
        .catch(error => console.error('Error fetching Provincias:', error));
    } else {
      setProvinces([]);
    }
  }, [setselectedDepartamentos, fetchProvincias]);

  useEffect(() => {
    if (selectedDistritos) {
      fetchDistritos(selectedProvincias)
        .then(data => setDistritos(data))
        .catch(error => console.error('Error fetching Distritos:', error));
    } else {
      setProvinces([]);
    }
  }, [selectedProvincias, fetchDistritos]);

  const handleSubmit = (e) => {
    e.preventDefault();
 
    fetch('https://localhost:44389/api/H001_Paciente/InsertarPaciente', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ TipodDocumento : selectedTipoDocumento, Nombre,ApellidoPaterno,FechaNacimiento,Sexo,Correo,Celular,Direccion, Departamento: selectedDepartment, 
        Provincia: selectedProvincias, Distrito: selectedDistritos }),
    })
      .then(response => response.json())
      .then(data => {

        onAddPatient(data);
        setselectedTipoDocumento('');
        setTipodDocumento('');
        setNumeroDocumento('');
        setNombre('');
        setApellidoPaterno('');
        setFechaNacimiento('');
        setSexo('');
        setCorreo('');
        setCelular('');
        setDireccion('');
        setselectedDepartamentos('');
        setselectedProvincias('');
        steselectedDistritos('');

      })
      .catch(error => console.error('Error al Insertar Paciente:', error));
  };

  return (
    <form onSubmit={handleSubmit}>
      <label>
        Tipo de Documento:
        <select value={setselectedTipoDocumento} onChange={(e) => setselectedTipoDocumento(e.target.value)}>
          <option value="">Selecciona un Tipo de Documento</option>
          {departments.map((dept) => (
            <option key={dept.idTipoDocumento} value={dept.idTipoDocumento}>{dept.abreviatura}</option>
          ))}
        </select>
        <input type="text" value={TipodDocumento} onChange={(e) => setselectedTipoDocumento(e.target.value)} />
      </label>
      <label>
        Nro. Documento:
        <input type="text" value={NumeroDocumento} onChange={(e) => setNumeroDocumento(e.target.value)} />
      </label>
      <label>
        Nombre:
        <input type="text" value={NumeroDocumento} onChange={(e) => setNumeroDocumento(e.target.value)} />
      </label>
      <label>
        Apelldio Paterno:
        <input type="text" value={NumeroDocumento} onChange={(e) => setNumeroDocumento(e.target.value)} />
      </label>
      <label>
        Apellido Materno:
        <input type="text" value={NumeroDocumento} onChange={(e) => setNumeroDocumento(e.target.value)} />
      </label>
      <label>
        Fecha de FechaNacimiento:
        <input class="datepicker" data-date-format="mm/dd/yyyy" value={NumeroDocumento} onChange={(e) => setNumeroDocumento(e.target.value)} />
      </label>
      <label>
        Sexo:
        <input type="text" value={NumeroDocumento} onChange={(e) => setNumeroDocumento(e.target.value)} />
      </label>
      <label>
       Correo:
        <input type="text" value={NumeroDocumento} onChange={(e) => setNumeroDocumento(e.target.value)} />
      </label>
      <label>
        Celular:
        <input type="text" value={NumeroDocumento} onChange={(e) => setNumeroDocumento(e.target.value)} />
      </label>
      <label>
        Dirección:
        <input type="text" value={NumeroDocumento} onChange={(e) => setNumeroDocumento(e.target.value)} />
      </label>
      <label>
        Departamento:
        <select value={selectedDepartamentos} onChange={(e) => setselectedDepartamentos(e.target.value)}>
          <option value="">Seleccione un Departamento</option>
          {departments.map((dept) => (
            <option key={dept.codDepartamento} value={dept.codDepartamento}>{dept.departamento}</option>
          ))}
        </select>
      </label>
      <label>
        Provincia:
        <select value={selectedProvincias} onChange={(e) => selectedProvincias(e.target.value)}>
          <option value="">Seleccione una Provincia</option>
          {provinces.map((prov) => (
            <option key={provc.codProvincia} value={prov.codProvincia}>{prov.provincia}</option>
          ))}
        </select>
      </label>
      <label>
        Distrito:
        <select value={selectedDistritos} onChange={(e) => steselectedDistritos(e.target.value)}>
          <option value="">Seleccione un Distrito</option>
          {provinces.map((prov) => (
            <option key={prov.codUbigeo} value={prov.codUbigeo}>{prov.distrito}</option>
          ))}
        </select>
      </label>
      <button type="submit">Registrar Paciente</button>
    </form>
  );
};

export default PatientForm;
