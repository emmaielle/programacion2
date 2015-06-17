<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Ambos_RastrearEnvio.aspx.cs" Inherits="Solucion_ObligatorioP2.Ambos_RastrearEnvio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="div_rastrearEnvio_contenedora" class="labels">
        
        <p id="p_rastearEnvio_head" style="font-size:22px; font-family:Verdana;" runat="server" class="letrasLinks">Rastreo de envios</p>
        <div style="clear:both">
            <asp:Label ID="lbl_rastrearEnvio_nroEnvio" runat="server" Text="Ingrese numero de envio:"></asp:Label>
            <asp:TextBox ID="txt_rastrearEnvio_nroEnvio" style="margin-left:5px" runat="server"></asp:TextBox>
        </div>
        <div style="clear:both; margin-top:10px">
            <asp:Button ID="btn_rastrearEnvio_rastrear" runat="server" OnClick="btn_rastrearEnvio_rastrear_Click" Text="Rastrear" />
        </div>

        <div id="div_rastrearEnvio_maessagesError" style="clear:both; margin-top:10px; height:30px">
            <%--mensajes de error--%>
        </div>

        <div style="clear:both; margin-top:20px">
        </div>

        <asp:GridView ID="gvRastreo" runat="server" DataKeyNames="Codigo" AutoGenerateColumns="False" OnRowCommand="gvRastreo_RowCommand">
    <Columns>
        <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
        <asp:BoundField DataField="Estado" HeaderText="Estado" />
        <asp:BoundField DataField="Oficina Postal" HeaderText="Oficina Postal" />
    </Columns>
            </asp:GridView>
    </div>
</asp:Content>
