<%@ Page Title="" Language="C#" MasterPageFile="~/Pags_Cliente.Master" AutoEventWireup="true" CodeBehind="Cliente_Home.aspx.cs" Inherits="Solucion_ObligatorioP2.Cliente_Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="contenedora_centrarMaster">
        <asp:Button ID="btn_linkrastreo" CssClass="botones_Admin letrasLinks" runat="server" Text="Rastreo de envíos" BorderStyle="None" /><br />
        <asp:Button ID="Button1" runat="server" CssClass="botones_Admin letrasLinks" Text="Simulación de envío" BorderStyle="None" />
    </div>
</asp:Content>
