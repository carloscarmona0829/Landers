using System;
using System.Data;
using libAccesoDatos;
using libEntidades;

namespace libReglasNegocio
{
    public class clsProductosRN
    {
        clsProductosAD objProductos = new clsProductosAD();
        public DataSet CargarDdl_Productos() 
        {
            try
            {
                clsProductosAD objRN = new clsProductosAD();
                return objRN.CargarDdl_Productos();
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
                clsProductosAD objRN = new clsProductosAD();
                return objRN.ProductosCrud(Accion, entidadProductos);
            }
            catch (Exception error)
            {
                throw error;
            }
        }        
        public DataTable Listar_Productos()
        {
            try
            {
                return objProductos.Listar_Productos();
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
