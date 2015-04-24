<%@ Page Title="" Language="C#" MasterPageFile="~/Pags_Admin.Master" AutoEventWireup="true" CodeBehind="Admin_ControlPanel.aspx.cs" Inherits="Solucion_ObligatorioP2.Admin_ControlPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div id="contenedora_centrarMaster">
            <asp:button ID="btn_linkcrearAdmin" cssClass="botones_Admin letrasLinks" runat="server" text="Crear Administrador" BorderStyle="None" /><br />
            <asp:button ID="btn_linkrastreoAdmin" cssClass="botones_Admin letrasLinks" runat="server" text="Rastreo de envíos" BorderStyle="None" /><br />
            <asp:button ID="btn_linkcrearEnvio" cssClass="botones_Admin letrasLinks" runat="server" text="Creación de envíos" BorderStyle="None" /><br />
            <asp:button ID="btn_linkingresoInfoEnvio" cssClass="botones_Admin letrasLinks" runat="server" text="Ingreso de información sobre envíos existentes" BorderStyle="None" /><br />
            <asp:button ID="btn_linksimulacionAdmin" cssClass="botones_Admin letrasLinks" runat="server" text="Simulación de envíos" BorderStyle="None" /><br />
            <asp:button ID="btn_linklistarEnviosEntregados" cssClass="botones_Admin letrasLinks" runat="server" text="Listar envíos entregados a un cliente" BorderStyle="None" />
        </div>


     </div>
</asp:Content>
