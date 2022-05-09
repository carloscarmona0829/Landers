<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Matricula_de_Proyectos.Proyectos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
     <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
        <table align="center" border="0" cellpadding="2" cellspacing="2" style="font-weight: normal; font-size: 9pt; font-family: Tahoma; background-color: #f5f5f5"
            width="98%">
            <tr>
                <td colspan="4" align="center">
                    <br />
                    <font size="3"><strong>REGISTRO DE PRODUCTOS               
                    </strong></font>
                    <br />
                </td>
            </tr>
            <tr style="color: #000000">
                <td style="text-align: left" colspan="4">
                    <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Names="Tahoma"
                        ForeColor="Red" Font-Size="10pt"></asp:Label>
                </td>
            </tr>
           <tr>
                <td style="text-align: center" colspan="4">
                    <br />
                    <asp:TextBox ID="txtIdBuscar" runat="server" Visible="False"></asp:TextBox>
                    <br />
                    </td>
            </tr>
            <tr>
                <td style="text-align: left">Nombre:</td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtNombreBuscar" runat="server"></asp:TextBox></td>
                <td style="text-align: left">Descripción:</td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtDescripcionBuscar" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align: left">Categoría:</td>
                <td style="text-align: left">
                    <asp:DropDownList ID="ddlCategoriaBuscar" runat="server"></asp:DropDownList></td>
                <td style="text-align: left"></td>
                <td style="text-align: left">
                    </td>
            </tr>
            
            
            <tr>
                <td style="text-align: center" colspan="4">
                    <br />
                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnGuardar_Click" />
                    </td>
            </tr>
            <tr>
                <td style="text-align: center" colspan="4">
                    <br />
                    </td>
            </tr>

            <tr>
                <td style="text-align: center" colspan="4">
                    <asp:GridView ID="gvDatos" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" PageSize="20" Style="font-size: 9pt" Width="100%">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>                            
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                            <asp:BoundField DataField="Categoria" HeaderText="Categoría" />                            
                            <%--<asp:BoundField DataField="imagen" HeaderText="Imagen" />--%>
                            <asp:BoundField DataField="Stock" HeaderText="Stock" />
                            <asp:BoundField DataField="Precio" HeaderText="Precio" />  

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="btnEditar" ImageUrl="~/Imagenes/view_report.png" ToolTip="Editar" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="btnEliminar" ImageUrl="~/Imagenes/icon-delete.gif" ToolTip="Eliminar" />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                </td>
            </tr>        


        </table>

         <!-- Modal -->
            <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h3 class="modal-title" id="exampleModalLongTitle">REGISTRO DE PRODUCTOS</h3> </div>
                        
                        <div class="modal-body">
                               <table align="center" border="0" cellpadding="2" cellspacing="2" style="font-weight: normal; font-size: 9pt; font-family: Tahoma; background-color: #f5f5f5"
            width="98%">
            
            <tr style="color: #000000">
                <td style="text-align: left" colspan="4">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Tahoma"
                        ForeColor="Red" Font-Size="10pt"></asp:Label>
                </td>
            </tr>
           <tr>
                <td style="text-align: center" colspan="4">
                    <br />
                    <asp:TextBox ID="txtId" runat="server" Visible="False"></asp:TextBox>
                    <br />
                    </td>
            </tr>
            <tr>
                <td style="text-align: left">Nombre:</td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></td>
                <td style="text-align: left">Descripción:</td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align: left">Categoría:</td>
                <td style="text-align: left">
                    <asp:DropDownList ID="ddlCategoria" runat="server"></asp:DropDownList></td>
                <td style="text-align: left">Imagen:</td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtImagen" runat="server"></asp:TextBox></td>
            </tr>
            
            <tr>
                <td style="text-align: left">Stock:</td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtStock" runat="server"></asp:TextBox></td>
                <td style="text-align: left">Precio:</td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align: left">Estado:</td>
                <td style="text-align: left">
                    <asp:DropDownList ID="ddlEstado" runat="server">
                        <asp:ListItem>Activo</asp:ListItem>
                        <asp:ListItem>Inactivo</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="text-align: left">&nbsp;</td>
                <td style="text-align: left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: center" colspan="4">
                    <br />
                    <br />
                    </td>
            </tr>
           

            <tr>
                <td style="text-align: center" colspan="4">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" PageSize="20" Style="font-size: 9pt" Width="100%">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>                            
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                            <asp:BoundField DataField="Categoria" HeaderText="Categoría" />                            
                            <%--<asp:BoundField DataField="imagen" HeaderText="Imagen" />--%>
                            <asp:BoundField DataField="Stock" HeaderText="Stock" />
                            <asp:BoundField DataField="Precio" HeaderText="Precio" />  

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="btnEditar" ImageUrl="~/Imagenes/view_report.png" ToolTip="Editar" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="btnEliminar" ImageUrl="~/Imagenes/icon-delete.gif" ToolTip="Eliminar" />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                </td>
            </tr>        


        </table>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="Button1" class="btn btn-success" runat="server" Text="Guardar" />
                                <asp:Button ID="btnCancelar" class="btn btn-primary" runat="server" Text="Cancelar" data-dismiss="modal" />
                            </div>
                        </div>
                    </div>
                </div>

    </form>
</body>
</html>

