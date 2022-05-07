import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';    
import {Modal, ModalBody, ModalFooter, ModalHeader} from 'reactstrap';
import React, { useState, useEffect } from 'react';

function App() {
const baseUrl='https://localhost:7062/api/Productos'
const [data, setData] = useState([]);

const peticionGet=async()=>{
  await axios.get(baseUrl)
  .then(Response=>{
    setData(Response.data);
  }).catch(error=>{
    console.log(error);
  })
}

useEffect(()=>{
  peticionGet();
},[])


  return (
    <div className="App">
      <table className='table table-bordered'>
        <thead>
          <tr>
            <th>ID</th>
            <th>Nombre</th>
            <th>Descripción</th>
            <th>Categoría</th>
            <th>Imagen</th>
            <th>Stock</th>
            <th>Precio</th>
            <th>Acciones</th>
          </tr>
        </thead>
        <tbody>
{data.map(producto=>(
  <tr key={producto.id}>
    <td>{producto.id}</td>
    <td>{producto.nombre}</td>
    <td>{producto.descripcion}</td>
    <td>{producto.categoria}</td>
    <td>{producto.imagen}</td>
    <td>{producto.stock}</td>
    <td>{producto.precio}</td>
    <td>
      <button className='btn btn-primary'>Editar</button> {" "}
      <button className='btn btn-danger'>Eliminar</button>
    </td>
  </tr>
))}
        </tbody>
      </table>
    </div>
  );
}

export default App;
