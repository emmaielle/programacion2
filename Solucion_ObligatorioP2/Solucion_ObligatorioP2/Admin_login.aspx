<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_login.aspx.cs" Inherits="Solucion_ObligatorioP2.Admin_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link type="text/css" rel="stylesheet" href="Estilos.css"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="div_home_central">
            <asp:Login ID="login_admin" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderStyle="Solid" BorderWidth="2px" Font-Names="Arial" Font-Size="15px" LoginButtonText="Iniciar sesión" TitleText="Iniciar sesión como Administrador" BorderPadding="5" ForeColor="#333333" Width="300px" DestinationPageUrl="~/Admin_ControlPanel.aspx">
                <CheckBoxStyle Font-Size="10px" />
                <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
                <TextBoxStyle Font-Size="0.8em" />
                <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="#FFFFFF" Font-Size="0.9em" Wrap="True" />
            </asp:Login>
            <asp:LinkButton ID="lnk_loginAdmin_volver" CssClass="letrasLinks" PostBackUrl="~/Inicio.aspx" runat="server">Volver</asp:LinkButton>

        </div>

    </form>
</body>
</html>
