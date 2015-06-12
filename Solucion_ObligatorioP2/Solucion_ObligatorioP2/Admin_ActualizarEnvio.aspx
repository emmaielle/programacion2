<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Admin_ActualizarEnvio.aspx.cs" Inherits="Solucion_ObligatorioP2.Admin_ActualizarEnvio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="div_actualizarEnv_contenedora">
        <p id="p_actualidarEnv_head" style="font-size:22px; font-family:Verdana;" runat="server" class="letrasLinks">Actualizacion de envios</p>
        <div style="margin-top:40px">
            <div>
                <div style="float:left">
                    <asp:Label ID="lbl_actualizarEnv_nroEnv" runat="server" style="float:left" CssClass="labels" Text="Número envío: "></asp:Label>
                    <asp:TextBox ID="txt_actualizarEnv_nroEnv" style="float:right; margin-left:5px; width:80px" runat="server"></asp:TextBox>
                </div>
                <div style="float:right">    
                    <asp:Label ID="lbl_actualizarEnv_oficina" runat="server" style="float:left" CssClass="labels" Text="Número Oficina Postal: "></asp:Label>
                    <asp:DropDownList ID="ddl_actualizarEnv_Oficinas" style="float:right; margin-left:5px" CssClass="labels" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div style="clear:both">
                <asp:Label ID="lbl_actualizarEnv_etapaEnv" runat="server" style="float:left" CssClass="labels" Text="Ingrese la etapa de envio: "></asp:Label>
                <asp:DropDownList ID="ddl_actualizarEnv_etapaEnv" runat="server"></asp:DropDownList>
            </div>
            <div style="padding-top:15px">
                <div style="margin-top:25px; margin-bottom:5px; clear:both">
                    <asp:Label ID="lbl_actlualizarEnv_fechaIng" style="margin:auto" CssClass="labels" runat="server" Text="Fecha de Ingreso: "></asp:Label>
                </div>
                <div style="margin-top:10px">
                    <asp:Calendar ID="calendar_actualizarEnv_fchIngreso" runat="server" style="margin:auto" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
                        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                        <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                        <WeekendDayStyle BackColor="#CCCCFF" />
                    </asp:Calendar>
                </div>
            </div>
            <div style="clear:both; margin-top:30px">
                <asp:Button ID="btn_actualizarEnv_AgregarEtapa" runat="server" Text="Agregar Etapa" OnClick="btn_actualizarEnv_AgregarEtapa_Click" />
            </div>
        </div>
    </div>
</asp:Content>
