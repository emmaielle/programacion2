<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Admin_crearEnvio.aspx.cs" Inherits="Solucion_ObligatorioP2.Admin_crearEnvio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="scripts/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" src="scripts/crearEnvio.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="div_crearEnvio_contenedora">
        <p id="p_crearEnv_head" style="font-size:22px; font-family:Verdana;" runat="server" class="letrasLinks">Creacion de envío</p>
        <div class="cajitas" style="margin:10px; padding-bottom:60px; padding-left:120px; padding-right:120px; width:260px; clear:both">  
              
            <div style="margin-bottom:10px">
                <div style="margin-bottom:8px">
                    <asp:Label ID="lbl_crearEnvio_fechaIngreso" style="clear:both" CssClass="labels" runat="server" Text="Fecha: "></asp:Label>
                </div>
                <asp:Calendar ID="calendar_crearEnvio" style="clear:both; vertical-align:central; margin:auto" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="171px" Width="189px">
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
                <asp:Label ID="lbl_crearEnvio_idCliente" style="float:left" CssClass="labels" runat="server" Text="Id Cliente: "></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_idCliente" style="width:100px;float:right; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:10px; clear:both">
                <%-- el peso se ingresa en kg para todos los envios y para docs se guarda transformado a gramos --%>
                <asp:Label ID="lbl_crearEnvio_peso" style="float:left" CssClass="labels" runat="server" Text="Peso (Kg): "></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_peso" style="width:100px;float:right; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:10px; clear:both">
                <asp:Label ID="lbl_crearEnvio_nomDestinatario" style="float:left" CssClass="labels" runat="server" Text="Nombre destinatario:"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_nomDest" style="width:100px; float:right; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:15px; clear:both">
                <asp:Label ID="lbl_crearEnvio_direcDestinatario" style="color:blue; margin:auto; vertical-align:central" CssClass="labels" runat="server" Text="Datos de dirección de destino:"></asp:Label>
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
                <asp:Label ID="lbl_crearEnvio_pais" style="float:left" CssClass="labels" runat="server" Text="País:"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_pais" style="width:100px ;float:right; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:10px; clear:both">
                <asp:Label ID="lbl_crearEnvio_ciudad" CssClass="labels" style="float:left" runat="server" Text="Ciudad:"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_ciudad" style="width:100px ;float:right; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:10px; clear:both">
                <asp:Label ID="lbl_crearEnvio_codigoPostal" style="float:left" CssClass="labels" runat="server" Text="Código Postal:"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_codPostal" style="width:100px ;float:right; margin-left:6px" runat="server"></asp:TextBox>
            </div>

        </div>
        <div style="padding-top:15px; padding-bottom:15px; clear:both; margin:auto; vertical-align:central; padding-left:110px; padding-right:110px; width:280px">
            <asp:Label ID="lbl_crearEnvio_chooseType" runat="server" CssClass="labels" style="float:left" Text="Tipo de envío: "></asp:Label>
            <asp:RadioButton ID="radiobtn_crearEnvio_esPaquete" CssClass="labels" style="float:right" runat="server" OnCheckedChanged="radiobtn_crearEnvio_esPaqueteODocCheckedChanged" Text="Paquete" GroupName="tipoEnvio" AutoPostBack="True" />
            <asp:RadioButton ID="radiobtn_crearEnvio_esDoc" CssClass="labels" style="float:right; margin-left:10px" runat="server" OnCheckedChanged="radiobtn_crearEnvio_esPaqueteODocCheckedChanged" Text="Documento" GroupName="tipoEnvio" AutoPostBack="True" />
        </div>
        <asp:Panel ID="PanelPaquete" runat="server" CssClass="cajitas" style="margin:10px; margin-top:30px; padding:10px; padding-left:120px; padding-right:120px;  width:260px; clear:both" Visible="False">

            <div style="padding-top:15px; clear:both">
                <asp:Label ID="lbl_crearEnvio_largoPaquete" style="float:left" CssClass="labels" runat="server" Text="Largo (cm):"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_largoPaquete" style="width:100px ;float:right; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:15px; clear:both">
                <asp:Label ID="lbl_crearEnvio_anchoPaquete" style="float:left" CssClass="labels" runat="server" Text="Ancho (cm):"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_anchoPaquete" style="width:100px ;float:right; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:15px; clear:both">
                <asp:Label ID="lbl_crearEnvio_altoPaquete1" style="float:left" CssClass="labels" runat="server" Text="Alto (cm):"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_altoPaquete" style="width:100px ;float:right; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:15px; clear:both">
                <asp:Label ID="lbl_crearEnvio_descripcion" style="float:left" CssClass="labels" runat="server" Text="Descripción:"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_DescripPaquete" TextMode="MultiLine" Rows="3" style="width:150px; resize:none; float:right; margin-left:4px" runat="server"></asp:TextBox>
            </div>
            
            <div style="padding-top:15px; clear:both">
                <asp:Label ID="lbl_crearEnvio_valorDeclarado" style="float:left" CssClass="labels" runat="server" Text=" Valor Declarado (U$S):"></asp:Label>
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
                <asp:Label ID="lbl_crearEnvio_datosDirOri" style="margin:auto; vertical-align:central; color:blue" CssClass="labels" runat="server" Text=" Datos de dirección de origen:"></asp:Label>
            </div>
           <div style="padding-top:15px; clear:both">
               <asp:Label ID="lbl_crearEnvio_calleOrigen" style="float:left" CssClass="labels" runat="server" Text="Calle:"></asp:Label>
               <asp:TextBox ID="txt_crearEnvio_calleOrigen" style="width:100px ;float:right; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:15px; clear:both">
                <asp:Label ID="lbl_crearEnvio_numOrigen" style="float:left" CssClass="labels" runat="server" Text="Número:"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_nroOrigen" style="width:100px ;float:right; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:15px; clear:both">
                <asp:Label ID="lbl_crearEnvio_paisOrigen" style="float:left" CssClass="labels" runat="server" Text="País:"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_paisOrigen" style="width:100px ;float:right; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:15px; clear:both">
                <asp:Label ID="lbl_crearEnvio_ciudadOrigen" style="float:left" CssClass="labels" runat="server" Text="Ciudad:"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_ciudadOrigen" style="width:100px ;float:right; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:15px;padding-bottom:30px; clear:both">
                <asp:Label ID="lbl_crearEnvio_codPostalOrigen" style="float:left" CssClass="labels" runat="server" Text="Código Postal:"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_codPostalOrigen" style="width:100px ;float:right; margin-left:6px" runat="server"></asp:TextBox>
            </div>

        </asp:Panel>
        <div style="padding-top:15px; clear:both">
            <div style="clear:both; width:250px; margin:auto;vertical-align:central" class="labels">
                <asp:Label ID="lbl_crearEnvio_nroOffice" style="float:left" runat="server" Text="Ingrese número de oficina:"></asp:Label>
                <asp:DropDownList ID="ddl_crearEnvio_nroOficina" style="float:right" runat="server">
                </asp:DropDownList>
            </div>
            <div style="clear:both">
                <asp:Button ID="btn_crearEnvio_crearEnvio" style="margin-top:20px;clear:both" CssClass="labels" runat="server" OnClientClick="return validaciones();" OnClick="btn_crearEnvio_crearEnvio_Click" Text="Crear Envio" />
            </div>
            <div>
                <p runat="server" id="p_crearEnvio_errores" class="letrasLinks" style="color:red;font-family:Verdana"></p>
            </div>
            <div style="padding-top:15px; margin-bottom:20px; clear:both">
                <asp:Label ID="lbl_crearEnvio_muestraNroEnvio" style="color:blue" CssClass="labels" runat="server"></asp:Label>
            </div>
        </div>
   </div>
</asp:Content>
