<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Ambos_TotalFacturado.aspx.cs" Inherits="Solucion_ObligatorioP2.Ambos_TotalFacturado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        &nbsp;</p>
    <p>
        Ingrese los datos para obtener el total facturado por un cliente entre dos fechas:</p>
    <p id="lbl_totalFacturado_nroCliente">
        Nro Cliente:
        <asp:TextBox ID="txt_totalFacturado_nroCliente" runat="server"></asp:TextBox>
    </p>
    <p id="lbl_totalFacturado_fechaDesde">
        Fecha Desde:
        <asp:Calendar ID="calendar_totalFacturado_fechaDesde" runat="server"></asp:Calendar>
    </p>
    <p id="lbl_totalFacturado_fechaHasta">
&nbsp;Fecha Hasta:
        <br />
        <asp:Calendar ID="calendar_totalFacturado_fechaHasta" runat="server"></asp:Calendar>
    </p>
    <p>
        <asp:Button ID="btn_totalFacturado_ObtenerInfo" runat="server" OnClick="btn_totalFacturado_ObtenerInfo_Click" Text="Obtener" />
    </p>
</asp:Content>
