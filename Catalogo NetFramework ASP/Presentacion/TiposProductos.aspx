<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TiposProductos.aspx.cs" Inherits="Matricula_de_Proyectos.TiposProyectos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Table ID="Table1" runat="server"></asp:Table>
            <asp:Label ID="Label1" runat="server" Text="TIPOS DE PROYECTOS"></asp:Label>
            <br />
            <br />
        <asp:Label ID="Label3" runat="server" Text="Tipo de Proyecto : "></asp:Label>
        <asp:TextBox ID="txtTipo_Proyecto" runat="server"></asp:TextBox>
            <br />
        <asp:Label ID="Label4" runat="server" Text="Estado : "></asp:Label>
        <asp:DropDownList ID="ddlEstado" runat="server"></asp:DropDownList>
            <br />
            <br />
        <asp:LinkButton ID="lkbTipos_Proyectos" runat="server" OnClick="lkbTipos_Proyectos_Click">Ir a Proyectos</asp:LinkButton>
            <br />
            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            <br />
            <br />
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        </div>
    </form>
</body>
</html>
