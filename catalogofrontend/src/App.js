import React, { useState, useEfect, Component } from 'react';
import './App.css';
import axios from "axios";
import "bootstrap/dist/css/bootstrap.min.css";
import { Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap';

const url = "https://localhost:7062/api/Productos"

class App extends Component {
  state = {
    data: [],
    modalInsertar: false,
    modalEliminar: false,
    modalImagen: false,
    urlImagen: "",
    form: {
      id: "",
      nombre: "",
      descripcion: "",
      categoria: "",
      imagen: "",
      stock: "",
      precio: "",
    }    
  }   

  peticionGet = () => {
    axios.get(url).then(response => {
      this.setState({ data: response.data });      
    }).catch(error => {
      console.log(error.message);
    })
  }

  peticionPost = async () => {
    delete this.state.form.id;
    await axios.post(url, this.state.form).then(response => {
      this.modalInsertar();
      this.peticionGet();
    }).catch(error => {
      console.log(error.message);
    })
  }

  peticionPut = () => {
    axios.put(`${url}/${this.state.form.id}`, this.state.form).then(response => {
      this.modalInsertar();
      this.peticionGet();
    })
  }

  peticionDelete = () => {
    axios.delete(`${url}/${this.state.form.id}`).then(response => {
      this.setState({ modalEliminar: false });
      this.peticionGet();
    })
  }

  modalInsertar = () => {
    this.setState({ modalInsertar: !this.state.modalInsertar });
  }

  seleccionarProducto = (producto) => {
    this.setState({
      tipoModal: 'actualizar',
      form: {
        id: producto.id,
        nombre: producto.nombre,
        descripcion: producto.descripcion,
        categoria: producto.id_Categoria,
        imagen: producto.imagen,
        stock: producto.stock,
        precio: producto.precio
      }
    })
  }

  handleChange = async e => {
    e.persist();
    await this.setState({
      form: {
        ...this.state.form,
        [e.target.name]: e.target.value
      }
    });
    console.log(this.state.form);
  }

  onClickImagen(urlImagen) {
    this.setState(prev => ({ ...prev, urlImagen, modalImagen: true }))
  }

  componentDidMount() {
    this.peticionGet();
  }

  render() {
    const { form } = this.state;
    return (
      <div className="App">
        <h1>Catálogo de Productos</h1>
        <hr />        
        <button className="btn btn-success" onClick={() => { this.setState({ form: null, tipoModal: 'insertar' }); this.modalInsertar() }}>Agregar Producto</button>
        <br /><br />        
        <table className="table ">
          <thead>
            <tr>
              <th>Imagen</th>          
              <th>Código</th>
              <th>Nombre</th>
              <th>Descripción</th>
              <th>Categoría</th>
              <th>Stock</th>
              <th>Precio</th>
              <th>Acciones</th>
            </tr>
          </thead>
          <tbody>

            {this.state.data.map(producto => {
              return (
                
                <tr>                  
                  <td><img style={{ width: 70, height: 70, borderRadius: 50 }} onClick={() => this.onClickImagen(producto.imagen)} src={producto.imagen} /> </td>
                  <td>{producto.id}</td>
                  <td>{producto.nombre}</td>
                  <td>{producto.descripcion}</td>
                  <td>{producto.id_Categoria}</td>
                  <td>{producto.stock}</td>
                  <td>{producto.precio}</td>
                  <td>
                    <button type="submit" className="btn btn-primary" onClick={() => { this.seleccionarProducto(producto); this.modalInsertar() }}>Editar</button>
                    
                    <button type="submit" className="btn btn-danger" onClick={() => { this.seleccionarProducto(producto); this.setState({ modalEliminar: true }) }}>Eliminar</button>
                  </td>
                </tr>
              )
            })}
          </tbody>
        </table>


        <Modal isOpen={this.state.modalInsertar}>
          <ModalHeader style={{ display: 'block' }}>
            <span style={{ float: 'right' }} onClick={() => this.modalInsertar()}>x</span>
          </ModalHeader>
          <ModalBody>
            <form method="post">
            <div className="form-group">
              <label htmlFor="id">ID</label>
              <input className="form-control" type="text" name="id" readOnly onChange={this.handleChange} value={form ? form.id : this.state.data.length + 1} />

              <label htmlFor="nombre">Nombre</label>
              <input class="form-control" type="text" name="nombre" onChange={this.handleChange} value={form ? form.nombre : ''} />

              <label htmlFor="nombre">Descripcion</label>
              <input className="form-control" type="text" name="descripcion" onChange={this.handleChange} value={form ? form.descripcion : ''} />

              <label htmlFor="id_Categoria">Categoria</label>
              <input className="form-control" type="text" name="id_Categoria" onChange={this.handleChange} value={form ? form.categoria : ''} />

              <label htmlFor="categoria">Imagen</label>
              <input className="form-control" type="text" name="imagen" onChange={this.handleChange} value={form ? form.imagen : ''} />

              <label htmlFor="categoria">Stock</label>
              <input className="form-control" type="text" name="stock" onChange={this.handleChange} value={form ? form.stock : ''} />

              <label htmlFor="categoria">Precio</label>
              <input className="form-control" type="text" name="precio" onChange={this.handleChange} value={form ? form.precio : ''} />
            </div>
            </form>
          </ModalBody>

          <ModalFooter>
            {this.state.tipoModal == 'insertar' ?
              <button className="btn btn-success" onClick={() => this.peticionPost()}>
                Insertar
              </button> : <button className="btn btn-primary" onClick={() => this.peticionPut()}>
                Actualizar
              </button>
            }
            <button className="btn btn-danger" onClick={() => this.modalInsertar()}>Cancelar</button>
          </ModalFooter>
        </Modal>


        <Modal isOpen={this.state.modalEliminar}>
          <ModalBody>
            Estás seguro que deseas eliminar el producto {form && form.nombre}
          </ModalBody>
          <ModalFooter>
            <button className="btn btn-danger" onClick={() => this.peticionDelete()}>Sí</button>
            <button className="btn btn-secundary" onClick={() => this.setState({ modalEliminar: false })}>No</button>
          </ModalFooter>
        </Modal>


        <Modal isOpen={this.state.modalImagen}>
          <ModalBody>
            <div className='text-center'>
              <img style={{ width: 400, height: 400, }} src={this.state.urlImagen} />
            </div>
          </ModalBody>
          <ModalFooter>
            <button className="btn btn-secundary" onClick={() => this.setState(prev => ({ ...prev, modalImagen: false }))}>Cerrar</button>
          </ModalFooter>
        </Modal>

      </div>

    );
  }
}
export default App;