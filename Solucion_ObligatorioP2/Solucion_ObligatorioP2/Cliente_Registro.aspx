<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cliente_Registro.aspx.cs" Inherits="Solucion_ObligatorioP2.Registro_Usuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link type="text/css" rel="stylesheet" href="Estilos.css"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="LabelCI" runat="server" Text="C.I:"></asp:Label>
        &nbsp;<asp:TextBox ID="CITextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="LabelNombre" runat="server" Text="Nombres:"></asp:Label>
        <asp:TextBox ID="NombresTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="LabelApellido" runat="server" Text="Apellidos:"></asp:Label>
        <asp:TextBox ID="ApellidosTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="LabelTelefono" runat="server" Text="Telefono:"></asp:Label>
        <asp:TextBox ID="TelefonoTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="LabelDireccion" runat="server" Text="Direccion:"></asp:Label>
        <asp:TextBox ID="DireccionTextBox" runat="server"></asp:TextBox>
    </form>
</body>
</html>
