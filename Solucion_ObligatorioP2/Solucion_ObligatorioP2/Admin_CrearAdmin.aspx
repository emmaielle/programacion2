<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Admin_CrearAdmin.aspx.cs" Inherits="Solucion_ObligatorioP2.Admin_CrearAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p id="lblNombre">
        &nbsp;</p>
    <p>
        Ingrese los datos para crear un nuevo administrador:</p>
    <p id="Lbl_CrearAdmin_Doc">
        Documento:&nbsp;
        <asp:TextBox ID="txt_crearAdmin_doc" runat="server" OnTextChanged="TextBoxDocumento_TextChanged"></asp:TextBox>
    </p>
    <p id="LblNombre">
        Nombre:
        <asp:TextBox ID="txt_crearAdmin_nombre" runat="server" OnTextChanged="TextBoxNombre_TextChanged"></asp:TextBox>
    </p>
    <p id="LblApellido">
        Apellido: <asp:TextBox ID="txt_crearAdmin_apellido" runat="server"></asp:TextBox>
    </p>
    <p>
        Telefono:
        <asp:TextBox ID="txt_crearAdmin_telefono" runat="server"></asp:TextBox>
    </p>
    <p id="LblPais">
        Pais:
        <asp:TextBox ID="txt_crearAdmin_pais" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
    </p>
    <p id="LblCiudad">
        Ciudad:
        <asp:TextBox ID="txt_crearAdmin_ciudad" runat="server"></asp:TextBox>
    </p>
    <p id="LblCodigoPostal">
        Codigo Postal:
        <asp:TextBox ID="txt_crearAdmin_cp" runat="server"></asp:TextBox>
    </p>
    <p id="LblCalle">
        Calle:
        <asp:TextBox ID="txt_crearAdmin_calle" runat="server"></asp:TextBox>
    </p>
    <p id="lbl_crearAdmin_numero">
        Numero Puerta:
        <asp:TextBox ID="txt_crearAdmin_numero" runat="server"></asp:TextBox>
    </p>
    <p id="lbl_crearAdmin_usuario">
        Usuario:
        <asp:TextBox ID="txt_crearAdmin_usuario" runat="server"></asp:TextBox>
    </p>
    <p id="lbl_crearAdmin_password">
        Password:
        <asp:TextBox TextMode="Password" ID="txt_crearAdmin_password" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btn_crearAdmin_altaAdmin" runat="server" OnClick="btn_crearAdmin_altaAdmin_Click" Text="Crear Administrador" />
        <br />
    </p>
</asp:Content>
