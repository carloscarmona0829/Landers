using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace libConexion
{
    public class clsAccesoSQL
    {
        /// <summary>        
        /// Retorna una Conexión Abierta, empleando una cadena de conexion existente
        /// en el archivo de configuración Web.config.
        /// </summary>
        /// <param name="cnx">Conexión</param>
        /// <returns>Conexión Abierta</returns>
        public SqlConnection ObtenerConexion(string cnx)
        {
            try
            {
                string connect = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;
                SqlConnection objConexion = new SqlConnection(connect);
                objConexion.Open();
                return objConexion;
            }
            catch (SqlException errorSQL)
            {
                throw errorSQL;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        /// <summary>        
        /// Retorna una Conexión Abierta, Windows Form empleando una cadena de conexion existente
        /// en el archivo de configuración.
        /// </summary>
        /// <param name="pConnection">Conexión</param>
        /// <returns>Conexión Abierta</returns>
        public SqlConnection ObtenerConexion1(string pConnection)
        {
            try
            {
                //Conexión para Windows Form
                SqlConnection objConexion = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings[pConnection].ToString());
                objConexion.Open();
                return objConexion;
            }
            catch (SqlException errorSQL)
            {
                throw errorSQL;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        /// <summary>
        /// Me retorna un DataSet de una consulta que no requiere parámetros
        /// </summary>
        /// <param name="objConexion">Conexión Abierta</param>
        /// <param name="pStoredProcedure">Procedimiento Almacenado</param>
        /// <returns>DataSet</returns>
        /// <remarks>Me retorna un DataSet de una consulta que no requiere parámetros</remarks>
        public DataSet TraerDataSet(SqlConnection objConexion, string pStoredProcedure)
        {
            try
            {

                SqlCommand objCommand = new SqlCommand(pStoredProcedure, objConexion);
                SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
                DataSet dsGeneral = new DataSet();
                objCommand.CommandType = CommandType.StoredProcedure;
                objAdapter.Fill(dsGeneral);
                objConexion.Close();
                return dsGeneral;
            }
            catch (SqlException ErrorSQL)
            {
                throw ErrorSQL;
            }
            catch (Exception Error)
            {
                throw Error;
            }
            finally
            {
                objConexion.Close();
            }
        }
        /// <summary>
        /// Me retorna un DataSet de una Consulta que requiere parámetros
        /// </summary>
        /// <param name="objConexion">Conexión Abierta</param>
        /// <param name="pStoredProcedure">Procedimiento Almacenado</param>
        /// <param name="pParameters">Arreglo de Parametros</param>
        /// <returns>DataSet</returns>
        public DataSet TraerDataSet(SqlConnection objConexion, string pStoredProcedure, SqlParameter[] pParameters)
        {
            try
            {
                SqlCommand objCommand = new SqlCommand(pStoredProcedure, objConexion);
                SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
                DataSet dsGeneral = new DataSet();
                objCommand.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter Parameters in pParameters)
                {
                    objAdapter.SelectCommand.Parameters.AddWithValue(Parameters.ParameterName, Parameters.Value);
                }
                objAdapter.Fill(dsGeneral);
                objConexion.Close();
                return dsGeneral;
            }
            catch (SqlException ErrorSQL)
            {
                throw ErrorSQL;
            }
            catch (Exception Error)
            {
                throw Error;
            }
            finally
            {
                objConexion.Close();
            }
        }
        /// <summary>
        /// Me retorna un DataTable de una Consulta que no requiere parámetros
        /// </summary>
        /// <param name="objConexion">Conexión Abierta</param>
        /// <param name="pStoredProcedure">Procedimiento Almacenado</param>
        /// <returns>DataTable</returns>
        public DataTable TraerDataTable(SqlConnection objConexion, string pStoredProcedure)
        {
            try
            {
                SqlCommand objCommand = new SqlCommand(pStoredProcedure, objConexion);
                SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
                DataTable dtGeneral = new DataTable();
                objCommand.CommandType = CommandType.StoredProcedure;
                objAdapter.Fill(dtGeneral);
                objConexion.Close();
                return dtGeneral;
            }
            catch (SqlException ErrorSQL)
            {
                throw ErrorSQL;
            }
            catch (Exception Error)
            {
                throw Error;
            }
            finally
            {
                objConexion.Close();
            }
        }
        /// <summary>
        /// Me retorna un DataTable de una consulta que requiere parametros
        /// </summary>
        /// <param name="objConexion">Conexión Abierta</param>
        /// <param name="pStoredProcedure">Procedimiento Almacenado</param>
        /// <param name="pParameters">Arreglo de Parametros</param>
        /// <returns>DataTable</returns>
        public DataTable TraerDataTable(SqlConnection objConexion, string pStoredProcedure, SqlParameter[] pParameters)
        {
            try
            {
                SqlCommand objCommand = new SqlCommand(pStoredProcedure, objConexion);
                SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
                DataTable dtGeneral = new DataTable();
                objCommand.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter Parameters in pParameters)
                {
                    objAdapter.SelectCommand.Parameters.AddWithValue(Parameters.ParameterName, Parameters.Value);
                }
                objAdapter.Fill(dtGeneral);
                objConexion.Close();
                return dtGeneral;
            }
            catch (SqlException ErrorSQL)
            {
                throw ErrorSQL;
            }
            catch (Exception Error)
            {
                throw Error;
            }
            finally
            {
                objConexion.Close();
            }
        }
        /// <summary>
        /// Me retorna un SqlDataReader de una Consulta que no requiere parámetros
        /// </summary>
        /// <param name="objConexion">Conexión Abierta</param>
        /// <param name="pStoredProcedure">Procedimiento Almacenado</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader TraerDataReader(SqlConnection objConexion, string pStoredProcedure)
        {
            try
            {
                SqlCommand objCommand = new SqlCommand(pStoredProcedure, objConexion);
                SqlDataReader drGeneral;
                objCommand.CommandType = CommandType.StoredProcedure;
                drGeneral = objCommand.ExecuteReader();
                return drGeneral;
            }
            catch (SqlException ErrorSQL)
            {
                throw ErrorSQL;
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }
        /// <summary>
        /// Me retorna un DataReader de una consulta que requiere parametros
        /// </summary>
        /// <param name="objConexion">Conexión Abierta</param>
        /// <param name="pStoredProcedure">Procedimiento Almacenado</param>
        /// <param name="pParameters">Arreglo de Parametros</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader TraerDataReader(SqlConnection objConexion, string pStoredProcedure, SqlParameter[] pParameters)
        {
            try
            {
                SqlCommand objCommand = new SqlCommand(pStoredProcedure, objConexion);
                SqlDataReader drGeneral;
                objCommand.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter Parameters in pParameters)
                {
                    objCommand.Parameters.AddWithValue(Parameters.ParameterName, Parameters.Value);
                }
                drGeneral = objCommand.ExecuteReader();
                return drGeneral;
            }
            catch (SqlException ErrorSQL)
            {
                throw ErrorSQL;
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }
        /// <summary>
        /// Ejecuta un procedimiento almacenado que requiere parametros
        /// </summary>
        /// <param name="objConexion">Conexión Abierta</param>
        /// <param name="pStoredProcedure">Procedimiento Almacenado</param>
        /// <param name="pParameters">Arreglo de Parametros</param>
        /// <returns>Numero de filas afectadas</returns>
        public int EjecutarQuery(SqlConnection objConexion, string pStoredProcedure, SqlParameter[] pParameters)
        {
            try
            {
                SqlCommand objCommand = new SqlCommand(pStoredProcedure, objConexion);
                objCommand.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter Parameters in pParameters)
                {
                    objCommand.Parameters.AddWithValue(Parameters.ParameterName, Parameters.Value);
                }
                return objCommand.ExecuteNonQuery();
            }
            catch (SqlException ErrorSQL)
            {
                throw ErrorSQL;
            }
            catch (Exception Error)
            {
                throw Error;
            }
            finally
            {
                objConexion.Close();
            }
        }
        /// <summary>
        /// Ejecuta un procedimiento almacenado que no requiere parametros
        /// </summary>
        /// <param name="objConexion">Conexión Abierta</param>
        /// <param name="pStoredProcedure">Procedimiento Almacenado</param>
        /// <returns>Numero de filas afectadas</returns>
        public int EjecutarQuery(SqlConnection objConexion, string pStoredProcedure)
        {
            try
            {
                SqlCommand objCommand = new SqlCommand(pStoredProcedure, objConexion);
                objCommand.CommandType = CommandType.StoredProcedure;
                return objCommand.ExecuteNonQuery();
            }
            catch (SqlException ErrorSQL)
            {
                throw ErrorSQL;
            }
            catch (Exception Error)
            {
                throw Error;
            }
            finally
            {
                objConexion.Close();
            }
        }
        /// <summary>
        /// Me retorna un verdadero si se ejecuto correctamente la consulta
        /// </summary>
        /// <param name="objConexion">Conexión Abierta</param>
        /// <param name="pStoredProcedure">Procedimiento Almacenado</param>
        public bool EjecutarQuerys(SqlConnection objConexion, string pStoredProcedure)
        {
            try
            {
                SqlCommand objCommand = new SqlCommand(pStoredProcedure, objConexion);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ErrorSQL)
            {
                throw ErrorSQL;
            }
            catch (Exception Error)
            {
                throw Error;
            }
            finally
            {
                objConexion.Close();
            }
        }
        /// <summary>
        /// Me retorna un verdadero si ejecuto correctamente una consulta que requiere parametros
        /// </summary>
        /// <param name="objConexion">Conexión Abierta</param>
        /// <param name="pStoredProcedure">Procedimiento Almacenado</param>
        /// <param name="pParameters">Arreglo de Parametros</param>
        /// <returns></returns>
        public bool EjecutarQuerys(SqlConnection objConexion, string pStoredProcedure, SqlParameter[] pParameters)
        {
            try
            {
                SqlCommand objCommand = new SqlCommand(pStoredProcedure, objConexion);
                objCommand.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter Parameters in pParameters)
                {
                    if (Parameters.Direction == ParameterDirection.Output)
                    {
                        objCommand.Parameters.AddWithValue(Parameters.ParameterName, Parameters.Value);
                        objCommand.Parameters[Parameters.ParameterName].Direction = ParameterDirection.Output;
                    }
                    else
                    {
                        objCommand.Parameters.AddWithValue(Parameters.ParameterName, Parameters.Value);
                    }
                }
                objCommand.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ErrorSQL)
            {
                throw ErrorSQL;
            }
            catch (Exception Error)
            {
                throw Error;
            }
            finally
            {
                objConexion.Close();
            }
        }
        /// <summary>
        /// Me retorna un string con el valor @@identity devuelto por SQL
        /// </summary>
        /// <param name="objConexion">Conexión Abierta</param>
        /// <param name="pStoredProcedure">Procedimiento Almacenado</param>
        /// <param name="pParameters">Arreglo de Parametros</param>
        /// <returns>string con valor @@identity</returns>
        public string EjecutarQuerysDirecccion(SqlConnection objConexion, string pStoredProcedure, SqlParameter[] pParameters)
        {
            try
            {
                SqlCommand objCommand = new SqlCommand(pStoredProcedure, objConexion);
                objCommand.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter Parameters in pParameters)
                {
                    if (Parameters.Direction == ParameterDirection.Output)
                    {
                        objCommand.Parameters.AddWithValue(Parameters.ParameterName, Parameters.Value);
                        objCommand.Parameters[Parameters.ParameterName].Direction = ParameterDirection.Output;
                    }
                    else if (Parameters.Direction == ParameterDirection.InputOutput)
                    {
                        objCommand.Parameters.AddWithValue(Parameters.ParameterName, Parameters.Value);
                        objCommand.Parameters[Parameters.ParameterName].Direction = ParameterDirection.InputOutput;
                    }
                    else
                    {
                        objCommand.Parameters.AddWithValue(Parameters.ParameterName, Parameters.Value);
                    }
                }
                objCommand.ExecuteNonQuery();
                return objCommand.Parameters[pParameters.Length - 1].Value.ToString();
            }
            catch (SqlException ErrorSQL)
            {
                throw ErrorSQL;
            }
            catch (Exception Error)
            {
                throw Error;
            }
            finally
            {
                objConexion.Close();
            }
        }
    }

}
