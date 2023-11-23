import React, { useState, useEffect } from 'react';
import PatientForm from './PacienteForm';

const App = () => {
 
  const fetchTipoDocumento = () => {
    return fetch('https://localhost:44389/api/H001_TipoDocumento/ListarTipoDocumento')
      .then(response => response.json());
  };
  
 const fetchDepartamentos = () => {
     return fetch('https://localhost:44389/api/H001_Ubigeo/ListarDepartamento')
      .then(response => response.json());
  };

  const fetchProvincias = (codDepartamento) => {
     return fetch(`https://localhost:44389/api/H001_Ubigeo/ListarProvincia/${codDepartamento}`)
      .then(response => response.json());
  };
  const fetchDistritos = (codDepartamento,codProvincia) => {
      return fetch(`https://localhost:44389/api/H001_Ubigeo/ListarDistrito/${codDepartamento}/${codProvincia}`)
      .then(response => response.json());
  };
  return (
    <div>
      <h1>Formulario React Registro de Paciente</h1>
      <PatientForm onAddPaciente={addPaciente} fetchTipoDocumento={fetchTipoDocumento} fetchDepartamentos={fetchDepartamentos} fetchProvinces={fetchProvincias} fetchDistritos={fetchDistritosnp}/>
    </div>
  );
};

export default App;
