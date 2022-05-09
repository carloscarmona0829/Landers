using System;
using System.Data;
using System.Web.UI.WebControls;
using libEntidades;
using libReglasNegocio;

namespace Matricula_de_Proyectos
{
    public partial class Proyectos : System.Web.UI.Page
    {
        clsProductosEN entidadProducto = new clsProductosEN();
        clsProductosRN objRN = new clsProductosRN();
        clsProductosRN objRNe = new clsProductosRN();

        #region Métodos Públicos

        private void CargarDdl_Productos()
        {
            try
            {
                DataSet dsCombos = new DataSet();
                dsCombos = objRN.CargarDdl_Productos();

                if (dsCombos.Tables[0] != null)
                {
                    ddlCategoria.DataSource = dsCombos.Tables[0];
                    ddlCategoria.DataTextField = "Valor";
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataBind();
                    ddlCategoria.Items.Add(new ListItem("Seleccionar", "0"));
                    ddlCategoria.SelectedValue = "0";
                }

            }
            catch (Exception Error)
            {
                lblError.Text = Error.Message;
            }
        }
        private void CargarGrid()
        {
            try
            {
                if (!IsPostBack)
                {
                    gvDatos.DataSource = objRNe.Listar_Productos();
                    gvDatos.DataBind();
                }
            }
            catch (Exception Error)
            {

                throw Error;
            }
        }

        private void AsignarEntidadProductos()
        {
            try
            {
                entidadProducto.Nombre = txtNombre.Text;
                entidadProducto.Descripcion = txtDescripcion.Text;
                entidadProducto.Id_Categoria = ddlCategoria.SelectedValue;
                entidadProducto.Imagen = txtImagen.Text;
                entidadProducto.Stock = Convert.ToInt32(txtStock.Text);
                entidadProducto.Precio = Convert.ToInt32(txtPrecio.Text);
                entidadProducto.Estado = Convert.ToInt32(ddlId_Estado.SelectedValue);
            }
            catch (Exception Error)
            {
                lblError.Text = (Error.Message);
            }
        }

        private void Guardar()
        {
            try
            {
                AsignarEntidadProductos();

                DataTable dtInsertarProyectos = new DataTable();
                dtInsertarProyectos = objRN.ProductosCrud("INSERTAR", entidadProducto);

                if (dtInsertarProyectos.Rows.Count > 0)
                {
                    if (dtInsertarProyectos.Rows[0]["SW"].ToString() != "0")
                    {
                        lblError.Text = (dtInsertarProyectos.Rows[0]["Mensaje"].ToString());
                        LimpiarCampos();
                        return;
                    }

                    lblError.Text = (dtInsertarProyectos.Rows[0]["Mensaje"].ToString());
                    LimpiarCampos();
                }
                
            }
            catch (Exception Error)
            {
                lblError.Text = (Error.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;            
            ddlCategoria.SelectedValue = "0";
            //imagen
            txtStock.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            ddlId_Estado.SelectedValue = "0";

        }

        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtId.Visible = false;
                CargarDdl_Productos();
                CargarGrid();
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //Guardar();
            //CargarGrid();
            //mpeSalidaActivos.Show();
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#exampleModalCenter').modal();", true);
        }

        #endregion
        
    }
}