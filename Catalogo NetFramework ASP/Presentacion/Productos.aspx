<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Matricula_de_Proyectos.Proyectos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
                    <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
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
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left">&nbsp;</td>
                <td style="text-align: left">
                    &nbsp;</td>
                <td style="text-align: left">&nbsp;</td>
                <td style="text-align: left">
                    &nbsp;</td>
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
                    <asp:DropDownList ID="ddlId_Estado" runat="server">
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
                    1<br />
                    </td>
            </tr>
            <tr>
                <td style="text-align: center" colspan="4">
                    <br />
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" /></td>
            </tr>

            <tr>
                <td style="text-align: center" colspan="4">
                    <asp:GridView ID="gvDatos" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" PageSize="20" Style="font-size: 9pt" Width="100%">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>                            
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                            <asp:BoundField DataField="Id_Categoria" HeaderText="Categoría" />
                            <asp:BoundField DataField="imagen" HeaderText="Imagen" />
                            <asp:BoundField DataField="Stock" HeaderText="Stock" />
                            <asp:BoundField DataField="Precio" HeaderText="Precio" />  

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="btnEditar" ImageUrl="~/Imagenes/view_report.png" ToolTip="Editar Proyecto" />
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
    </form>
</body>
</html>

