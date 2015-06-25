<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Ambos_TotalFacturado.aspx.cs" Inherits="Solucion_ObligatorioP2.Ambos_TotalFacturado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="scripts/jquery-1.11.3.min.js"></script>
    <script type="text/javascript">
        function validar() {
            retorno = false;

            idCli = $("#ContentPlaceHolder1_txt_totalFacturado_nroCliente");
            p_error_msj = $("#ContentPlaceHolder1_p_totalFacturado_errores");

            if (idCli.length) {
                if (idCli.val().trim() != "") {
                    if (isNaN(idCli.val())) {
                        p_error_msj.text("El número de cliente especificado no es un número");
                    }
                    else retorno = true;
                }
                else p_error_msj.text("Debe ingresar un número de cliente");
            }
            else retorno = true;

            return retorno;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="div_totalFacturado_contenedor" class="labels">
        <p id="p_totalFacturado_head" style="font-size:22px; font-family:Verdana;" runat="server" class="letrasLinks">Calcular total facturado</p>
        
        <div style="margin:10px; margin-top:20px; padding-bottom:15px; padding-left:80px; padding-right:80px; clear:both">
            
            <div id="div_totalFacturado_hidden4Cliente" visible="false" runat="server">
                <p id="p_totalFacturado_intro" runat="server">Ingrese el número de cliente para saber su total facturado entre dos fechas</p>

                <div style="clear:both; padding-top:10px">
                    <asp:Label ID="lbl_totalFacturado_nroCliente" style="vertical-align:central; margin:auto" runat="server" Text="Nro Cliente:"></asp:Label>
                    <asp:TextBox ID="txt_totalFacturado_nroCliente" style="vertical-align:central; margin:auto; width:100px; margin-left:5px" runat="server"></asp:TextBox>
                </div>
            </div>
            <div style="clear:both; padding-top:20px">
                <div style="float:left">
                    <asp:Label ID="lbl_totalFacturado_fechaDesde" style="float:left; clear:both" runat="server" Text="Fecha Desde:"></asp:Label>
                    <asp:Calendar ID="calendar_totalFacturado_fechaDesde" style="clear:both" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="132px" Width="147px">
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
                <div style="float:right">
                    <asp:Label ID="lbl_totalFacturado_fechaHasta" style="float:left; clear:both" runat="server" Text="Fecha Hasta:"></asp:Label>
                    <asp:Calendar ID="calendar_totalFacturado_fechaHasta" style="clear:both" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="132px" Width="147px">
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
            <div id="div_totalFacturado_ErrorMessages" style="padding-top:10px; height:35px; clear:both">
                <p runat="server" id="p_totalFacturado_errores" style="color:red;font-family:Verdana"></p>
            </div>
            <div style="padding-top:15px; clear:both">
                <div style="clear:both">
                    <asp:Button ID="btn_totalFacturado_ObtenerInfo" style="clear:both" runat="server" OnClientClick ="return validar();" OnClick="btn_totalFacturado_ObtenerInfo_Click" Text="Obtener" />
                </div>
                <div style="clear:both; padding-top:15px">
                    <asp:Label ID="lbl_totalFacturado_msjTotal" style="color:blue" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
