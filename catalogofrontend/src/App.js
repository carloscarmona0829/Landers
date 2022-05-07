import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";
import axios from "axios";    
import {Modal, ModalBody, ModalFooter, ModalHeader} from "reactstrap";
import React, { useState, useEffect } from "react";


function App() {
const baseUrl="https://localhost:7062/api/Productos"
const [data, setData] = useState([]);
const [modalInsertar, SetModalInsertar]=useState(false);
const [productoSeleccionado, setProductoSeleccionado]=useState({
  id:"",
  nombre:"",
  descripcion:"",
  categoria:"",
  imagen:"",
  stock:"",
  precio:""
})

const handleChange=e=>{
  const {name, value}=e.target;
  setProductoSeleccionado({
    productoSeleccionado,
    [name]:value
  });
  console.log(productoSeleccionado);
}

const abrirCerrarModalInsertar=()=>{
  SetModalInsertar(!modalInsertar);
}

const peticionGet=async()=>{
  await axios.get(baseUrl)
  .then(response=>{
    setData(response.data);
  }).catch(error=>{
    console.log(error);
  })
}

const peticionPost=async()=>{
  delete productoSeleccionado.id;
  productoSeleccionado.stock=parseInt(productoSeleccionado.stock);
  productoSeleccionado.precio=parseInt(productoSeleccionado.precio);
  await axios.post(baseUrl, productoSeleccionado)
  .then(response=>{
    setData(data.concat(response.data));
    abrirCerrarModalInsertar();
  }).catch(error=>{
    console.log(error);
  })
}

useEffect(()=>{
  peticionGet();
},[])


  return (
    <div className="App">
      <h1>Catálogo de Productos</h1>
      <hr />
      <button className="btn btn-success" onClick={()=>abrirCerrarModalInsertar()}>Insertar Producto</button>
      <hr />
      <table className="table table-bordered">
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
      <button className="btn btn-primary">Editar</button> {" "}
      <button className="btn btn-danger">Eliminar</button>
    </td>
  </tr>
))}
        </tbody>
      </table>

      <Modal isOpen={modalInsertar}>
        <ModalHeader>Insertar Producto </ModalHeader>
        <ModalBody>
          <div className="form-group">
            <label>Nombre: </label>
            <input type="text" className="form-control" name="nombre" onChange={handleChange}></input>
            <label>Descripcion: </label>
            <input type="text" className="form-control" name="descripcion" onChange={handleChange}></input>
            <label>Categoria: </label>
            <input type="text" className="form-control" name="categoria" onChange={handleChange}></input>
            <label>Imagen: </label>
            <input type="text" className="form-control" name="imagen" onChange={handleChange}></input>
            <label>Stock: </label>
            <input type="text" className="form-control" name="stock" onChange={handleChange}></input>
            <label>Precio: </label>
            <input type="text" className="form-control" name="precio" onChange={handleChange}></input>
          </div>
        </ModalBody>
        <ModalFooter>
          <button className='btn btn-primary' onClick={()=>peticionPost()}>Insertar</button>
          <button className='btn btn-danger' onClick={()=>abrirCerrarModalInsertar()}>Cancelar</button>
        </ModalFooter>
      </Modal>

    </div>
  );
}

export default App;
