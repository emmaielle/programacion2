<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Admin_crearEnvio.aspx.cs" Inherits="Solucion_ObligatorioP2.Admin_crearEnvio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="div_crearEnvio_contenedora">
        <p id="p_crearEnv_head" style="font-size:22px; font-family:Verdana;" runat="server" class="letrasLinks">Creación de envio</p>
        <div style="padding-top:10px; clear:both">
            <asp:Label ID="lbl_crearEnvio_nroEnvio" style="color:blue;float:left" CssClass="labels" runat="server" Text="Número de envio: "></asp:Label>
        </div>
        <div style="padding-top:10px; clear:both">
            <asp:Label ID="lbl_crearEnvio_peso" style="float:left" CssClass="labels" runat="server" Text="Peso: "></asp:Label>
            <asp:TextBox ID="txt_crearEnvio_peso" style="float:left; margin-left:6px" runat="server"></asp:TextBox>
        </div>
        <div style="padding-top:10px; clear:both">
            <asp:Label ID="lbl_crearEnvio_nomDestinatario" style="float:left" CssClass="labels" runat="server" Text="Nombre de destinatario:"></asp:Label>
            <asp:TextBox ID="txt_crearEnvio_nomDest" style="float:left; margin-left:6px" runat="server"></asp:TextBox>
        </div>
        <div style="padding-top:15px; clear:both">
            <asp:Label ID="lbl_crearEnvio_direcDestinatario" style="float:left" CssClass="labels" runat="server" Text="Datos de destino:"></asp:Label>
        </div>
        <div style="padding-top:10px; clear:both">
            <asp:Label ID="lbl_crearEnvio_calle" CssClass="labels" runat="server" style="float:left" Text="Calle: "></asp:Label>
            <asp:TextBox ID="txt_crearEnvio_calle" style="float:left; margin-left:6px" runat="server"></asp:TextBox>        
        </div>
        <div style="padding-top:10px; clear:both">
            <asp:Label ID="lbl_crearEnvio_numero" CssClass="labels" runat="server" style="float:left" Text="Numero de puerta:"></asp:Label>
            <asp:TextBox ID="txt_crearEnvio_numPuerta" style="float:left;margin-left:6px" runat="server"></asp:TextBox>
        </div>
        <div style="padding-top:10px; clear:both">
            <asp:Label ID="lbl_crearEnvio_pais" style="float:left" CssClass="labels" runat="server" Text="Pais:"></asp:Label>
            <asp:TextBox ID="txt_crearEnvio_pais" style="float:left; margin-left:6px" runat="server"></asp:TextBox>
        </div>
        <div style="padding-top:10px; clear:both">
            <asp:Label ID="lbl_crearEnvio_ciudad" CssClass="labels" style="float:left" runat="server" Text="Ciudad:"></asp:Label>
            <asp:TextBox ID="txt_crearEnvio_ciudad" style="float:left; margin-left:6px" runat="server"></asp:TextBox>
        </div>
        <div style="padding-top:10px; clear:both">
            <asp:Label ID="lbl_crearEnvio_codigoPostal" style="float:left" CssClass="labels" runat="server" Text="Codigo Postal:"></asp:Label>
            <asp:TextBox ID="txt_crearEnvio_codPostal" style="float:left; margin-left:6px" runat="server"></asp:TextBox>
        </div>
        
        <div style="padding-top:15px; clear:both">
            <asp:RadioButton ID="radiobtn_crearEnvio_esPaquete" CssClass="labels" style="float:left" runat="server" OnCheckedChanged="radiobtn_crearEnvio_esPaqueteCheckedChanged" Text="Paquete" GroupName="tipoEnvio" />
            <asp:RadioButton ID="radiobtn_crearEnvio_esDoc" CssClass="labels" style="float:left; margin-left:10px" runat="server" OnCheckedChanged="radiobtn_crearEnvio_esDoc_CheckedChanged" Text="Documento" GroupName="tipoEnvio" />
        </div>
        <asp:Panel ID="PanelPaquete" runat="server" Visible="False">
            <div style="padding-top:15px; clear:both">
                <asp:Label ID="lbl_crearEnvio_largoPaquete" style="float:left" CssClass="labels" runat="server" Text="Largo:"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_largoPaquete" style="float:left; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:15px; clear:both">
                <asp:Label ID="lbl_crearEnvio_anchoPaquete" style="float:left" CssClass="labels" runat="server" Text="Ancho:"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_anchoPaquete" style="float:left; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:15px; clear:both">
                <asp:Label ID="lbl_crearEnvio_altoPaquete1" style="float:left" CssClass="labels" runat="server" Text="Alto:"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_altoPaquete" style="float:left; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:15px; clear:both">
                <asp:Label ID="lbl_crearEnvio_descripcion" style="float:left" CssClass="labels" runat="server" Text="Descripcion:"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_DescripPaquete" style="float:left; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:15px; clear:both">
                <asp:Label ID="lbl_crearEnvio_valorDeclarado" style="float:left" CssClass="labels" runat="server" Text=" Valor Declarado:"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_valorDeclaradoPaquete" style="float:left; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:15px; clear:both">
                <asp:CheckBox ID="chkbox_crearEnvio_seguro" style="float:left" CssClass="labels" runat="server" Text="Tiene seguro" />
            </div>
        </asp:Panel>

        <asp:Panel ID="PanelDocumento" runat="server" Visible="False">
            <div style="padding-top:15px; clear:both">
                <asp:CheckBox ID="chkbox_crearEnvio_esDocLegal" style="float:left" CssClass="labels" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" Text="Es documento legal" />
            </div>
            <div style="padding-top:15px; clear:both">
                <asp:Label ID="lbl_crearEnvio_datosDirOri" style="float:left" CssClass="labels" runat="server" Text=" Datos de direccion de origen:"></asp:Label>
            </div>
           <div style="padding-top:15px; clear:both">
               <asp:Label ID="lbl_crearEnvio_calleOrigen" style="float:left" CssClass="labels" runat="server" Text="Calle:"></asp:Label>
               <asp:TextBox ID="txt_crearEnvio_calleOrigen" style="float:left; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:15px; clear:both">
                <asp:Label ID="lbl_crearEnvio_numOrigen" style="float:left" CssClass="labels" runat="server" Text="Numero:"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_nroOrigen" style="float:left; margin-left:6px" runat="server" OnTextChanged="txt_crearEnvio_calleOrigen0_TextChanged"></asp:TextBox>
            </div>
            <div style="padding-top:15px; clear:both">
                <asp:Label ID="lbl_crearEnvio_paisOrigen" style="float:left" CssClass="labels" runat="server" Text="Pais:"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_paisOrigen" style="float:left; margin-left:6px" runat="server" OnTextChanged="txt_crearEnvio_calleOrigen0_TextChanged"></asp:TextBox>
            </div>
            <div style="padding-top:15px; clear:both">
                <asp:Label ID="lbl_crearEnvio_ciudadOrigen" style="float:left" CssClass="labels" runat="server" Text="Ciudad:"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_ciudadOrigen" style="float:left; margin-left:6px" runat="server" OnTextChanged="txt_crearEnvio_calleOrigen0_TextChanged"></asp:TextBox>
            </div>
            <div style="padding-top:15px; clear:both">
                <asp:Label ID="lbl_crearEnvio_codPostalOrigen" style="float:left" CssClass="labels" runat="server" Text="Codigo Postal:"></asp:Label>
                <asp:TextBox ID="txt_crearEnvio_codPostalOrigen" style="float:left; margin-left:6px" runat="server" OnTextChanged="txt_crearEnvio_calleOrigen0_TextChanged"></asp:TextBox>
            </div>
        </asp:Panel>
        <div style="padding-top:15px; clear:both">
            <asp:Button ID="btn_crearEnvio_crearEnvio" CssClass="labels" runat="server" OnClick="btn_crearEnvio_crearEnvio_Click" Text="Crear Envio" />
        </div>
        <div style="padding-top:15px; clear:both">
            <asp:Label ID="lbl_crearEnvio_muestraNroEnvio" CssClass="labels" runat="server" Text="Label"></asp:Label>
        </div>
   </div>
</asp:Content>
