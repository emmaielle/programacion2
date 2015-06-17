<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Admin_crearEnvio.aspx.cs" Inherits="Solucion_ObligatorioP2.Admin_crearEnvio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="div_crearEnvio_contenedora">
        <p id="p_crearEnv_head" style="font-size:22px; font-family:Verdana;" runat="server" class="letrasLinks">Creacion de envio</p>
        <div class="cajitas" style="margin:10px; padding-bottom:60px; padding-left:120px; padding-right:120px; width:260px; clear:both">  
              
            <div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Label ID="lbl_crearEnvio_fechaIngreso" style="float:left" CssClass="labels" runat="server" Text="Fecha: "></asp:Label>
                <asp:Calendar ID="calendar_crearEnvio" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="110px" Width="148px">
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
            <div style="padding-top:10px; clear:both">
                <asp:Label ID="lbl_crearEnvio_peso" style="float:left" CssClass="labels" runat="server" Text="Peso: "></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_peso" style="width:100px;float:right; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:10px; clear:both">
                <asp:Label ID="lbl_crearEnvio_nomDestinatario" style="float:left" CssClass="labels" runat="server" Text="Nombre destinatario:"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_nomDest" style="width:100px; float:right; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:15px; clear:both">
                <asp:Label ID="lbl_crearEnvio_direcDestinatario" style="color:blue; margin:auto; vertical-align:central" CssClass="labels" runat="server" Text="Datos de destino:"></asp:Label>
            </div>
            <div style="padding-top:10px; clear:both">
                <asp:Label ID="lbl_crearEnvio_calle" CssClass="labels" runat="server" style="float:left" Text="Calle: "></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_calle" style="width:100px ;float:right; margin-left:6px" runat="server"></asp:TextBox>        
            </div>
            <div style="padding-top:10px; clear:both">
                <asp:Label ID="lbl_crearEnvio_numero" CssClass="labels" runat="server" style="float:left" Text="Numero de puerta:"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_numPuerta" style="width:100px ;float:right;margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:10px; clear:both">
                <asp:Label ID="lbl_crearEnvio_pais" style="float:left" CssClass="labels" runat="server" Text="Pais:"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_pais" style="width:100px ;float:right; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:10px; clear:both">
                <asp:Label ID="lbl_crearEnvio_ciudad" CssClass="labels" style="float:left" runat="server" Text="Ciudad:"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_ciudad" style="width:100px ;float:right; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:10px; clear:both">
                <asp:Label ID="lbl_crearEnvio_codigoPostal" style="float:left" CssClass="labels" runat="server" Text="Codigo Postal:"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_codPostal" style="width:100px ;float:right; margin-left:6px" runat="server"></asp:TextBox>
            </div>

        </div>
        <div style="padding-top:15px; padding-bottom:15px; clear:both; margin:auto; vertical-align:central; padding-left:110px; padding-right:110px; width:280px">
            <asp:Label ID="lbl_crearEnvio_chooseType" runat="server" CssClass="labels" style="float:left" Text="Tipo de envio: "></asp:Label>
            <asp:RadioButton ID="radiobtn_crearEnvio_esPaquete" CssClass="labels" style="float:right" runat="server" OnCheckedChanged="radiobtn_crearEnvio_esPaqueteODocCheckedChanged" Text="Paquete" GroupName="tipoEnvio" AutoPostBack="True" />
            <asp:RadioButton ID="radiobtn_crearEnvio_esDoc" CssClass="labels" style="float:right; margin-left:10px" runat="server" OnCheckedChanged="radiobtn_crearEnvio_esPaqueteODocCheckedChanged" Text="Documento" GroupName="tipoEnvio" AutoPostBack="True" />
        </div>
        <asp:Panel ID="PanelPaquete" runat="server" CssClass="cajitas" style="margin:10px; margin-top:30px; padding:10px; padding-left:120px; padding-right:120px;  width:260px; clear:both" Visible="False">

            <div style="padding-top:15px; clear:both">
                <asp:Label ID="lbl_crearEnvio_largoPaquete" style="float:left" CssClass="labels" runat="server" Text="Largo:"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_largoPaquete" style="width:100px ;float:right; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:15px; clear:both">
                <asp:Label ID="lbl_crearEnvio_anchoPaquete" style="float:left" CssClass="labels" runat="server" Text="Ancho:"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_anchoPaquete" style="width:100px ;float:right; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:15px; clear:both">
                <asp:Label ID="lbl_crearEnvio_altoPaquete1" style="float:left" CssClass="labels" runat="server" Text="Alto:"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_altoPaquete" style="width:100px ;float:right; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:15px; clear:both">
                <asp:Label ID="lbl_crearEnvio_descripcion" style="float:left" CssClass="labels" runat="server" Text="Descripcion:"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_DescripPaquete" TextMode="MultiLine" Rows="3" style="width:150px; resize:none; float:right; margin-left:4px" runat="server"></asp:TextBox>
            </div>
            
            <div style="padding-top:15px; clear:both">
                 <asp:Label ID="lbl_crearEnvio_costoBaseXGramo" style="float:left" CssClass="labels" runat="server" Text=" Costo base /gramo:"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_costoBase" style="width:100px ;float:right; margin-left:6px" runat="server"></asp:TextBox>
            </div>

            <div style="padding-top:15px; clear:both">
                <asp:Label ID="lbl_crearEnvio_valorDeclarado" style="float:left" CssClass="labels" runat="server" Text=" Valor Declarado:"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_valorDeclaradoPaquete" style="width:100px ;float:right; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:20px; padding-bottom:30px; clear:both">
                <asp:CheckBox ID="chkbox_crearEnvio_seguro" style="float:left" CssClass="labels" runat="server" Text="Tiene seguro" />
            </div>

        </asp:Panel>

        <asp:Panel ID="PanelDocumento" CssClass="cajitas" style="margin:10px; margin-top:30px; padding:10px; padding-left:120px; padding-right:120px;  width:260px; clear:both"  runat="server" Visible="False">
            <div style="padding-top:15px; clear:both">
                <asp:CheckBox ID="chkbox_crearEnvio_esDocLegal" style="float:left" CssClass="labels" runat="server" Text="Es documento legal" />
            </div>
            <div style="padding-top:15px; clear:both">
                <asp:Label ID="lbl_crearEnvio_datosDirOri" style="margin:auto; vertical-align:central; color:blue" CssClass="labels" runat="server" Text=" Datos de direccion de origen:"></asp:Label>
            </div>
           <div style="padding-top:15px; clear:both">
               <asp:Label ID="lbl_crearEnvio_calleOrigen" style="float:left" CssClass="labels" runat="server" Text="Calle:"></asp:Label>
               <asp:TextBox ID="txt_crearEnvio_calleOrigen" style="width:100px ;float:right; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:15px; clear:both">
                <asp:Label ID="lbl_crearEnvio_numOrigen" style="float:left" CssClass="labels" runat="server" Text="Numero:"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_nroOrigen" style="width:100px ;float:right; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:15px; clear:both">
                <asp:Label ID="lbl_crearEnvio_paisOrigen" style="float:left" CssClass="labels" runat="server" Text="Pais:"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_paisOrigen" style="width:100px ;float:right; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:15px; clear:both">
                <asp:Label ID="lbl_crearEnvio_ciudadOrigen" style="float:left" CssClass="labels" runat="server" Text="Ciudad:"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_ciudadOrigen" style="width:100px ;float:right; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:15px;padding-bottom:30px; clear:both">
                <asp:Label ID="lbl_crearEnvio_codPostalOrigen" style="float:left" CssClass="labels" runat="server" Text="Codigo Postal:"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_codPostalOrigen" style="width:100px ;float:right; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div> 
            </div>
        </asp:Panel>
        <div style="padding-top:15px; clear:both">
            <asp:Panel ID="Panel1" runat="server">
                Ingrese etapa y nro. de oficina:
                <br />
                <br />
                <asp:DropDownList ID="ddl_crearEnvio_etapa" runat="server">
                </asp:DropDownList>
                <asp:DropDownList ID="ddl_crearEnvio_nroOficina" runat="server">
                </asp:DropDownList>
            </asp:Panel>
            <br />
            <asp:Button ID="btn_crearEnvio_crearEnvio" CssClass="labels" runat="server" OnClick="btn_crearEnvio_crearEnvio_Click" Text="Crear Envio" />
            <br />
            <br />
                <asp:Label ID="lbl_crearEnvio_nroEnvio0" style="float:left;color:blue" CssClass="labels" runat="server" Text="Número de envio generado: "></asp:Label>
        </div>
        <div style="padding-top:15px; clear:both">
            <asp:Label ID="lbl_crearEnvio_muestraNroEnvio" CssClass="labels" runat="server" Text="Label"></asp:Label>
        </div>
   </div>
</asp:Content>
