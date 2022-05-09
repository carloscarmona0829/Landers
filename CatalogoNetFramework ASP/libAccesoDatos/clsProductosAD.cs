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

                    case "ACTUALIZAR":

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


                    case "ELIMINAR":

                        Parametros = new SqlParameter[2];

                        Parametros[0] = new SqlParameter("@Id", entidadProductos.Id);                        
                        Parametros[1] = new SqlParameter("@Accion", Accion);

                        break;

                    case "BUSCAR":

                        Parametros = new SqlParameter[4];

                        Parametros[0] = new SqlParameter("@Identificacion", entidadProductos.Nombre);
                        Parametros[1] = new SqlParameter("@Nom_Usuario ", entidadProductos.Descripcion);
                        Parametros[2] = new SqlParameter("@Email_Usuario ", entidadProductos.Id_Categoria);
                        Parametros[3] = new SqlParameter("@Accion", Accion);

                        break;
                    

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
