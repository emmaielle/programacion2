<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Admin_crearEnvio.aspx.cs" Inherits="Solucion_ObligatorioP2.Admin_crearEnvio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Ingresa los datos del envio:</p>
    <p id="lbl_crearEnvio_nroEnvio">
        &nbsp;Nro. Envio: </p>
    <p id="lbl_crearEnvio_peso">
        Peso:
        <asp:TextBox ID="txt_crearEnvio_peso" runat="server"></asp:TextBox>
    </p>
    <p id="lbl_crearEnvio_nomDestinatario">
        Nombre de destinatario:
        <asp:TextBox ID="txt_crearEnvio_nomDest" runat="server"></asp:TextBox>
    </p>
    <p id="lbl_crearEnvio_direcDestinatario">
        Datos de destino:</p>
    <p id="lbl_crearEnvio_calle">
        Calle:
        <asp:TextBox ID="txt_crearEnvio_calle" runat="server"></asp:TextBox>
    </p>
    <p id="lbl_crearEnvio_numero">
        Numero de puerta:<asp:TextBox ID="txt_crearEnvio_numPuerta" runat="server"></asp:TextBox>
    </p>
    <p id="lbl_crearEnvio_pais">
        Pais:<asp:TextBox ID="txt_crearEnvio_pais" runat="server"></asp:TextBox>
    </p>
    <p id="lbl_crearEnvio_ciudad">
        Ciudad:<asp:TextBox ID="txt_crearEnvio_ciudad" runat="server"></asp:TextBox>
    </p>
    <p id="lbl_crearEnvio_codigoPostal">
        Codigo Postal:<asp:TextBox ID="txt_crearEnvio_codPostal" runat="server"></asp:TextBox>
    </p>
    <p>
        &nbsp;</p>
    <asp:Panel ID="PanelRadioButtons" runat="server">
        <asp:RadioButton ID="radiobtn_crearEnvio_esPaquete" runat="server" OnCheckedChanged="radiobtn_crearEnvio_esPaqueteCheckedChanged" Text="Paquete" />
        &nbsp;
        <asp:RadioButton ID="radiobtn_crearEnvio_esDoc" runat="server" OnCheckedChanged="radiobtn_crearEnvio_esDoc_CheckedChanged" Text="Documento" />
    </asp:Panel>
    <br />
    <asp:Panel ID="PanelPaquete" runat="server" Visible="False">
        <p id="lbl_crearEnvio_largoPaquete">
            Largo:<asp:TextBox ID="txt_crearEnvio_largoPaquete" runat="server"></asp:TextBox>
        </p>
        <p id="lbl_crearEnvio_anchoPaquete">
            Ancho:<asp:TextBox ID="txt_crearEnvio_anchoPaquete" runat="server"></asp:TextBox>
        </p>
        <p id="lbl_crearEnvio_altoPaquete1">
            Alto:<asp:TextBox ID="txt_crearEnvio_altoPaquete" runat="server"></asp:TextBox>
        </p>
        <p id="lbl_crearEnvio_descripcion">
            Descripcion:
            <asp:TextBox ID="txt_crearEnvio_DescripPaquete" runat="server"></asp:TextBox>
        </p>
        <p id="lbl_crearEnvio_valorDeclarado">
            Valor Declarado:<asp:TextBox ID="txt_crearEnvio_valorDeclaradoPaquete" runat="server"></asp:TextBox>
        </p>
        <asp:CheckBox ID="chkbox_crearEnvio_seguro" runat="server" Text="Tiene seguro" />
    </asp:Panel>
    <br />
    <br />
    <asp:Panel ID="PanelDocumento" runat="server" Visible="False">
        <br />
        <asp:CheckBox ID="chkbox_crearEnvio_esDocLegal" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" Text="Es documento legal" />
        <br />
        Datos de direccion de origen:<br /> &nbsp;<p id="lbl_crearEnvio_calleOrigen">
            Calle:<asp:TextBox ID="txt_crearEnvio_calleOrigen" runat="server"></asp:TextBox>
        </p>
        <p id="lbl_crearEnvio_numOrigen">
            Numero:<asp:TextBox ID="txt_crearEnvio_nroOrigen" runat="server" OnTextChanged="txt_crearEnvio_calleOrigen0_TextChanged"></asp:TextBox>
        </p>
        <p id="lbl_crearEnvio_paisOrigen">
            Pais:<asp:TextBox ID="txt_crearEnvio_paisOrigen" runat="server" OnTextChanged="txt_crearEnvio_calleOrigen0_TextChanged"></asp:TextBox>
        </p>
        <p id="lbl_crearEnvio_ciudadOrigen">
            Ciudad:<asp:TextBox ID="txt_crearEnvio_ciudadOrigen" runat="server" OnTextChanged="txt_crearEnvio_calleOrigen0_TextChanged"></asp:TextBox>
        </p>
        <p id="lbl_crearEnvio_codPostalOrigen">
            Codigo Postal:<asp:TextBox ID="txt_crearEnvio_codPostalOrigen" runat="server" OnTextChanged="txt_crearEnvio_calleOrigen0_TextChanged"></asp:TextBox>
        </p>
    </asp:Panel>
    <p>
        <asp:Button ID="btn_crearEnvio_crearEnvio" runat="server" OnClick="btn_crearEnvio_crearEnvio_Click" Text="Crear Envio" />
    </p>
    <asp:Label ID="lbl_crearEnvio_muestraNroEnvio" runat="server" Text="Label"></asp:Label>
    <p>
        &nbsp;</p>
   
</asp:Content>
