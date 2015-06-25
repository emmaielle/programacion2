<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Ambos_SimularEnvio.aspx.cs" Inherits="Solucion_ObligatorioP2.Ambos_SimularEnvio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="scripts/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" src="scripts/simularEnvio.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="div_simularEnvio_contenedora" class="labels">
        <p id="p_simularEnvio_head" style="font-size:22px; font-family:Verdana;" runat="server" class="letrasLinks">Simulación de envíos</p>

        <div style="padding-top:10px; clear:both; padding-bottom:20px; margin:auto; vertical-align:central;  padding-left:120px; padding-right:120px;  width:260px">
            <%-- el peso se ingresa en kg para todos los envios y para docs se guarda transformado a gramos --%>
            <asp:Label ID="lbl_simularEnvio_peso" style="float:left" CssClass="labels" runat="server" Text="Peso (Kg): "></asp:Label>
            <asp:TextBox ID="txt_simularEnvio_peso" style="width:100px;float:right; margin-left:6px" runat="server"></asp:TextBox>
        </div>
        <div style="padding-top:15px; padding-bottom:15px; clear:both; margin:auto; vertical-align:central; padding-left:110px; padding-right:110px; width:280px">
            <asp:Label ID="lbl_simularEnvio_chooseType" runat="server" CssClass="labels" style="float:left" Text="Tipo de envio: "></asp:Label>
            <asp:RadioButton ID="radiobtn_simularEnvio_esPaquete" CssClass="labels" style="float:right" runat="server" OnCheckedChanged="radiobtn_simularEnvio_esPaqueteODocCheckedChanged" Text="Paquete" GroupName="tipoEnvio" AutoPostBack="True" />
            <asp:RadioButton ID="radiobtn_simularEnvio_esDoc" CssClass="labels" style="float:right; margin-left:10px" runat="server" OnCheckedChanged="radiobtn_simularEnvio_esPaqueteODocCheckedChanged" Text="Documento" GroupName="tipoEnvio" AutoPostBack="True" />
        </div>
        <asp:Panel ID="simular_PanelPaquete" runat="server" CssClass="cajitas" style="margin:auto; vertical-align:central; margin-top:20px; padding-left:110px; padding-right:110px;  width:280px; clear:both" Visible="False">

            <div style="padding-top:15px; clear:both">
                <asp:Label ID="lbl_simularEnvio_largoPaquete" style="float:left" CssClass="labels" runat="server" Text="Largo (cm):"></asp:Label>
                <asp:TextBox ID="txt_simularEnvio_largoPaquete" style="width:100px ;float:right; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:15px; clear:both">
                <asp:Label ID="lbl_simularEnvio_anchoPaquete" style="float:left" CssClass="labels" runat="server" Text="Ancho (cm):"></asp:Label>
                <asp:TextBox ID="txt_simularEnvio_anchoPaquete" style="width:100px ;float:right; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:15px; clear:both">
                <asp:Label ID="lbl_simularEnvio_altoPaquete1" style="float:left" CssClass="labels" runat="server" Text="Alto (cm):"></asp:Label>
                <asp:TextBox ID="txt_simularEnvio_altoPaquete" style="width:100px ;float:right; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:15px; clear:both">
                <asp:Label ID="lbl_simularEnvio_valorDeclarado" style="float:left" CssClass="labels" runat="server" Text=" Valor Declarado:"></asp:Label>
                <asp:TextBox ID="txt_simularEnvio_valorDeclaradoPaquete" style="width:100px ;float:right; margin-left:6px" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:20px; padding-bottom:30px; clear:both">
                <asp:CheckBox ID="chkbox_simularEnvio_seguro" style="float:left" CssClass="labels" runat="server" Text="Tiene seguro" />
            </div>

        </asp:Panel>

        <asp:Panel ID="simular_PanelDocumento" CssClass="cajitas" style="margin:auto; margin-top:20px; padding-left:120px; padding-right:120px;  width:260px; clear:both"  runat="server" Visible="False">
            <div style="padding-top:10px; padding-bottom:25px; clear:both">
                <asp:CheckBox ID="chkbox_simularEnvio_esDocLegal" style="float:left" CssClass="labels" runat="server" Text="Es documento legal" />
            </div>
        </asp:Panel>
        <div style="padding-left:120px; margin:auto; vertical-align:central; padding-right:120px; padding-top:20px;  width:260px">
            <div>
                <asp:Button ID="btn_simular" style="margin:auto; vertical-align:central" CssClass="labels" runat="server" Text="Simular envío" OnClientClick="return validaciones();" OnClick="btn_simular_Click" /> <%--OnClientClick="return validaciones();"--%> 
            </div>
            <div id="div_simularEnvio_result" style="clear:both; margin:auto; vertical-align:central; margin-top:15px; margin-bottom:15px" runat="server">
                <asp:Label ID="lbl_simularEnvio_muestraResultado" runat="server" Text=""></asp:Label>
                <p id="p_simularEnvio_errores" runat="server" class="letrasLinks" style="color:red;font-family:Verdana"></p>
            </div>
        </div>
    </div>

</asp:Content>
