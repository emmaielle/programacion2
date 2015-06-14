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
            <asp:GridView ID="GridView1" style="margin:auto; vertical-align:central; clear:both" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="314px">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
             
            </asp:GridView>
        </div>
    </div>
</asp:Content>
