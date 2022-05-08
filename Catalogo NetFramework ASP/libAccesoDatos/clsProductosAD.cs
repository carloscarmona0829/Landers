using System;
using System.Data;
using System.Data.SqlClient;
using libConexion;
using libEntidades;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace libAccesoDatos
{   
    public class clsProductosAD
    {
        //Instancia de la base de datos con enterprise library llamando directamente al config
        private Database DBProductos = DatabaseFactory.CreateDatabase("cnx");

        private clsAccesoSQL objDatos = new clsAccesoSQL();

        public DataSet CargarDdl_Productos()
        {
            try
            {
                return objDatos.TraerDataSet(objDatos.ObtenerConexion("cnx"), "sp_CargaDdl_Categoria");
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        public DataTable ProductosCrud(string Accion, clsProductosEN entidadProductos)
        {
            try
            {
                DataTable dtDatos = new DataTable();
                SqlParameter[] Parametros;
                switch (Accion)
                {
                    case "INSERTAR":

                        Parametros = new SqlParameter[8];
                        
                        Parametros[0] = new SqlParameter("@Nombre", entidadProductos.Nombre);                        
                        Parametros[1] = new SqlParameter("@Descripcion", entidadProductos.Descripcion);
                        Parametros[2] = new SqlParameter("@Id_Categoria", entidadProductos.Id_Categoria);
                        Parametros[3] = new SqlParameter("@Imagen", entidadProductos.Imagen);
                        Parametros[4] = new SqlParameter("@Stock", entidadProductos.Stock);
                        Parametros[5] = new SqlParameter("@Precio", entidadProductos.Precio);
                        Parametros[6] = new SqlParameter("@Estado", entidadProductos.Estado);                     
                        Parametros[7] = new SqlParameter("@Accion", Accion);

                        break;

                    //case "ACTUALIZAR":

                    //    Parametros = new SqlParameter[17];

                    //    Parametros[0] = new SqlParameter("@Identificacion", entidadProductos.IdUsuario);
                    //    Parametros[1] = new SqlParameter("@Nom_Usuario ", entidadProductos.nombre);
                    //    Parametros[2] = new SqlParameter("@Celular", entidadProductos.celular);
                    //    Parametros[3] = new SqlParameter("@Tl_Fijo ", entidadProductos.fijo);
                    //    Parametros[4] = new SqlParameter("@FechaNacimiento ", entidadProductos.fechnto);
                    //    Parametros[5] = new SqlParameter("@Email_Usuario ", entidadProductos.email);
                    //    Parametros[6] = new SqlParameter("@Contraseña ", entidadProductos.pwd);
                    //    Parametros[7] = new SqlParameter("@DirResidencia ", entidadProductos.dir);
                    //    Parametros[8] = new SqlParameter("@Id_TipoUsuario ", entidadProductos.tipouser);
                    //    Parametros[9] = new SqlParameter("@Id_Perfil ", entidadProductos.perfil);
                    //    Parametros[10] = new SqlParameter("@Id_Estado ", entidadProductos.estado);
                    //    Parametros[11] = new SqlParameter("@Usu_CreaUsuario ", entidadProductos.usuAccion);
                    //    Parametros[12] = new SqlParameter("@Fecha_CreaUsuario ", entidadProductos.fechAccion);
                    //    Parametros[13] = new SqlParameter("@Usu_ModUsuario ", entidadProductos.UsuModifica);
                    //    Parametros[14] = new SqlParameter("@Fecha_ModUsuario ", entidadProductos.FechaModifica);
                    //    Parametros[15] = new SqlParameter("@UsuarioAutorizador ", entidadProductos.Autorizador);
                    //    Parametros[16] = new SqlParameter("@Accion", Accion);

                    //    break;

                    //case "INHABILITAR":

                    //    Parametros = new SqlParameter[4];

                    //    Parametros[0] = new SqlParameter("@Identificacion", entidadProductos.IdUsuario);
                    //    Parametros[1] = new SqlParameter("@Nom_Usuario ", entidadProductos.nombre);
                    //    Parametros[2] = new SqlParameter("@Email_Usuario ", entidadProductos.email);
                    //    Parametros[3] = new SqlParameter("@Accion", Accion);

                    //    break;

                    //case "CONSULTAR":

                    //    Parametros = new SqlParameter[4];

                    //    Parametros[0] = new SqlParameter("@Identificacion", entidadProductos.IdUsuario);
                    //    Parametros[1] = new SqlParameter("@Nom_Usuario ", entidadProductos.nombre);
                    //    Parametros[2] = new SqlParameter("@Email_Usuario ", entidadProductos.email);
                    //    Parametros[3] = new SqlParameter("@Accion", Accion);

                    //    break;

                    //case "LISTAUSUARIOS":

                    //    Parametros = new SqlParameter[5];

                    //    Parametros[0] = new SqlParameter("@Identificacion", entidadProductos.IdUsuario);
                    //    Parametros[1] = new SqlParameter("@Nom_Usuario ", entidadProductos.nombre);
                    //    Parametros[2] = new SqlParameter("@Email_Usuario ", entidadProductos.email);
                    //    Parametros[3] = new SqlParameter("@Id_TipoUsuario ", entidadProductos.tipouser);
                    //    Parametros[4] = new SqlParameter("@Accion", Accion);

                    //    break;

                    
                    default:
                        return null;
                }
                dtDatos = objDatos.TraerDataTable(objDatos.ObtenerConexion("cnx"), "sp_Productos_CRUD", Parametros);
                return dtDatos;

            }
            catch (Exception error)
            {
                throw error;
            }

        }        

        //Metodo construido con Enterprise Library
        public DataTable Listar_Productos()
        {
            try
            {
                DbCommand dbCommandConsulta = null;
                dbCommandConsulta = DBProductos.GetStoredProcCommand("sp_Productos_CRUD");
                DBProductos.AddInParameter(dbCommandConsulta, "@Accion", DbType.String, "LISTAR");
                return DBProductos.ExecuteDataSet(dbCommandConsulta).Tables[0];
            }
            catch (Exception error)
            {

                throw error;
            }

        }
        
    }
}
