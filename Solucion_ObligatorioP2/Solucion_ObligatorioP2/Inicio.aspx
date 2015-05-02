<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Solucion_ObligatorioP2.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link type="text/css" rel="stylesheet" href="Estilos.css"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="home_link_loginAdmin">
            <asp:LinkButton ID="link_loginAdmin"  CssClass="letrasLinks" runat="server" PostBackUrl="~/Admin_login.aspx">Login Administrador</asp:LinkButton></div>
        <div id="div_home_contenedora">
        <p style="font-size:22px; font-family:Verdana;" class="letrasLinks">Bienvenido a nom_EmpresaPostal</p>
        <p style="font-size:13px; font-family:Verdana;" class="letrasLinks">Registrate como cliente o ingresa si ya estás registrado para simular o seguir tus envíos</p>
        <div id="div_home_central">
             <asp:Login ID="login_cliente" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderStyle="Solid" BorderWidth="2px" Font-Names="Arial" Font-Size="15px" LoginButtonText="Iniciar sesión" TitleText="Iniciar sesión como Cliente" BorderPadding="5" ForeColor="#333333" Width="300px" DestinationPageUrl="~/Cliente_Home.aspx">
                <CheckBoxStyle Font-Size="10px" />
                <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
                <TextBoxStyle Font-Size="0.8em" />
                <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="#FFFFFF" Font-Size="0.9em" Wrap="True" />
            </asp:Login>
            <asp:LinkButton ID="lnk_home_registrarCliente" CssClass="letrasLinks" runat="server" PostBackUrl="~/Registro_Usuario.aspx" >No tienes usuario?</asp:LinkButton>
        </div>
    </div>
    </form>
</body>
</html>
