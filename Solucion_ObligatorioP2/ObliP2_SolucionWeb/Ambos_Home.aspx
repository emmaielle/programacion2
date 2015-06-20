<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Ambos_Home.aspx.cs" Inherits="Solucion_ObligatorioP2.Ambos_Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="div_formulario_homes" style="margin-bottom:10px;">
        <div id="div_homes_top" style="width:520px; clear:both" class="cajitas">
            <div id="div_registro_izq" style="float:left; width:290px;">
                <div style="margin-bottom:4px;  clear:both">
                    <asp:Label ID="LabelNombre_homes" style="float:left" CssClass="labels" runat="server" Text="Nombre " AssociatedControlID="txt_homes_nombre"></asp:Label>
                    <asp:RequiredFieldValidator ID="valid_homes_nom" style="float:left" runat="server" ControlToValidate="txt_homes_nombre" ValidationGroup="valid_homes_blank" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    <asp:TextBox Enabled="false" ID="txt_homes_nombre" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                </div>
                <div style="margin-bottom:4px; clear:both">
                    <asp:Label ID="LabelCI_homes" style="float:left" CssClass="labels" runat="server" Text="Cédula de Identidad " AssociatedControlID="txt_homes_CI"></asp:Label>
                    <asp:TextBox Enabled="false" ID="txt_homes_CI" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                </div>
                <div style="margin-bottom:4px;  clear:both">
                    <asp:Label ID="LabelPais_homes" style="float:left" CssClass="labels" runat="server" Text="País " AssociatedControlID="txt_homes_Pais"></asp:Label>
                    <asp:RequiredFieldValidator ID="valid_homes_pais" style="float:left" runat="server" ControlToValidate="txt_homes_Pais" ValidationGroup="valid_homes_blank" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    <asp:TextBox Enabled="false" ID="txt_homes_Pais" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                </div>
                <div style="margin-bottom:4px;  clear:both">
                    <asp:Label ID="LabelCP_homes" style="float:left" CssClass="labels" runat="server" Text="Código postal " AssociatedControlID="txt_homes_CP"></asp:Label>
                    <asp:RequiredFieldValidator ID="valid_homes_CP" style="float:left" runat="server" ControlToValidate="txt_homes_CP" ValidationGroup="valid_homes_blank" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    <asp:TextBox Enabled="false" ID="txt_homes_CP" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                </div>
                <div style="margin-bottom:4px;  clear:both">
                    <asp:Label ID="LabelNroPt_homes" style="float:left" CssClass="labels" runat="server" Text="Número de puerta " AssociatedControlID="txt_nroPt_homes"></asp:Label>
                    <asp:RequiredFieldValidator ID="valid_homes_NroPt" style="float:left" runat="server" ControlToValidate="txt_nroPt_homes" ValidationGroup="valid_homes_blank" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    <asp:TextBox Enabled="false" ID="txt_nroPt_homes" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                </div>
            </div>
            <div id="div_registro_der" style="float:right; width:205px;">
                <div style="margin-bottom:4px;  clear:both">
                    <asp:Label ID="LabelApellido_homes" style="float:left" CssClass="labels" runat="server" Text="Apellido " AssociatedControlID="txt_homes_Apellido"></asp:Label>
                    <asp:RequiredFieldValidator ID="valid_homes_apell" style="float:left" runat="server" ControlToValidate="txt_homes_Apellido" ValidationGroup="valid_homes_blank" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    <asp:TextBox Enabled="false" ID="txt_homes_Apellido" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                </div>
                <div style="margin-bottom:4px;  clear:both">
                    <asp:Label ID="LabelTelefono_homes" style="float:left" CssClass="labels" runat="server" Text="Telefono " AssociatedControlID="txt_homes_tel"></asp:Label>
                    <asp:RequiredFieldValidator ID="valid_homes_tel" style="float:left" runat="server" ControlToValidate="txt_homes_tel" ValidationGroup="valid_homes_blank" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    <asp:TextBox Enabled="false"  ID="txt_homes_tel" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                </div>
                <div style="margin-bottom:4px;  clear:both">
                    <asp:Label ID="LabelCiudad_homes" style="float:left" CssClass="labels" runat="server" Text="Ciudad " AssociatedControlID="txt_homes_ciudad"></asp:Label>
                    <asp:RequiredFieldValidator ID="valid_homes_ciudad" style="float:left" runat="server" ControlToValidate="txt_homes_ciudad" ValidationGroup="valid_homes_blank" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    <asp:TextBox Enabled="false" ID="txt_homes_ciudad" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                </div>
                <div style="margin-bottom:4px;  clear:both">
                    <asp:Label ID="LabelCalle_homes" style="float:left" CssClass="labels" runat="server" Text="Calle " AssociatedControlID="txt_homes_Calle"></asp:Label>
                    <asp:RequiredFieldValidator ID="valid_homes_calle" style="float:left" runat="server" ControlToValidate="txt_homes_Calle" ValidationGroup="valid_homes_blank" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    <asp:TextBox Enabled="false" ID="txt_homes_Calle" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                </div>
                <div style="margin-bottom:4px;  clear:both">
                    <asp:Label ID="LabelMail_homes" style="float:left" CssClass="labels" runat="server" Text="Mail " AssociatedControlID="txt_homes_Mail"></asp:Label>
                    <asp:RequiredFieldValidator ID="valid_homes_mail" style="float:left" runat="server" ControlToValidate="txt_homes_Mail" ValidationGroup="valid_homes_blank" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    <asp:TextBox Enabled="false" ID="txt_homes_Mail" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                </div>
            </div>
            <div style="clear:both">
            </div>
        </div>
        <div id="div_registro_center" class="cajitas" style="width:380px; clear:both; margin:auto; margin-top:8px">
            <div style="margin-bottom:4px;  clear:both">
                <asp:Label ID="LabelUsuario_homes" style="float:left" CssClass="labels" runat="server" Text="Nombre de usuario " AssociatedControlID="txt_homes_Usuario"></asp:Label>
                <asp:TextBox Enabled="false" ID="txt_homes_Usuario" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
            </div>
            <div style="margin-bottom:4px;  clear:both">
                <asp:Label ID="LabelPassword_homes" style="float:left" CssClass="labels" runat="server" Text="Password " AssociatedControlID="txt_homes_passwd"></asp:Label>
                <asp:RequiredFieldValidator ID="valid_homes_passwd" style="float:left" runat="server" ControlToValidate="txt_homes_passwd" ValidationGroup="valid_homes_blank" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                <asp:TextBox Enabled="false" ID="txt_homes_passwd" TextMode="Password" CssClass="txt_fields_registro" style="float:right" runat="server"></asp:TextBox>
            </div>
            <div style="clear:both">
            </div>
        </div>
        <div style="height:20px;">
            <p id="p_homes_messageServer" runat="server" style="color:red" class="letrasLinks">
            </p>
        </div>
        <div style="height:25px; margin-top:10px; clear:both; margin:auto">
            <asp:ValidationSummary ID="valid_summary_registro" runat="server" ValidationGroup="valid_homes_blank" CssClass="letrasLinks" ForeColor="Red" HeaderText="Debes completar los campos señalados" />
        </div>
    </div>
    <div style="clear:both; margin:auto; text-align:center">
        <asp:Button ID="btn_homes_guardar" runat="server" Text="Guardar" Visible="false" OnClick="btn_homes_guardar_Click" ValidationGroup="valid_homes_blank" />
        <asp:Button ID="btn_homes_modificar" style="" runat="server" Text="Modificar Datos" OnClick="btn_homes_modificar_Click" />
    </div>
</asp:Content>
