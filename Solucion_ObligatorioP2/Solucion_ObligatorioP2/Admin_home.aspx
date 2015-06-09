<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Admin_home.aspx.cs" Inherits="Solucion_ObligatorioP2.Admin_home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div id="div_formulario_homeAdmin" style="margin-bottom:10px;">
                
        <div id="div_homeAdmin_top" style="width:520px; clear:both" class="cajitas">
                    
            <div id="div_registro_izq" style="float:left; width:290px;">
                    <div style="margin-bottom:4px;  clear:both">
                    <asp:Label ID="LabelNombre_homeAdmin" style="float:left" CssClass="labels" runat="server" Text="Nombre " AssociatedControlID="txt_homeAdmin_nombre"></asp:Label>
                        <asp:RequiredFieldValidator ID="valid_homeAdmin_nom" style="float:left" runat="server" ControlToValidate="txt_homeAdmin_nombre" ValidationGroup="valid_homeAdmin_blank" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    <asp:TextBox Enabled="false" ID="txt_homeAdmin_nombre" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                </div>
                <div style="margin-bottom:4px; clear:both">
                    <asp:Label ID="LabelCI_homeAdmin" style="float:left" CssClass="labels" runat="server" Text="Cédula de Identidad " AssociatedControlID="txt_homeAdmin_CI"></asp:Label>
                    <asp:TextBox Enabled="false" ID="txt_homeAdmin_CI" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                </div>
                    <div style="margin-bottom:4px;  clear:both">
                    <asp:Label ID="LabelPais_homeAdmin" style="float:left" CssClass="labels" runat="server" Text="País " AssociatedControlID="txt_homeAdmin_Pais"></asp:Label>
                        <asp:RequiredFieldValidator ID="valid_homeAdmin_pais" style="float:left" runat="server" ControlToValidate="txt_homeAdmin_Pais" ValidationGroup="valid_homeAdmin_blank" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>                                                        
                        <asp:TextBox Enabled="false" ID="txt_homeAdmin_Pais" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                    </div>
                    <div style="margin-bottom:4px;  clear:both">
                    <asp:Label ID="LabelCP_homeAdmin" style="float:left" CssClass="labels" runat="server" Text="Código postal " AssociatedControlID="txt_homeAdmin_CP"></asp:Label>
                        <asp:RequiredFieldValidator ID="valid_homeAdmin_CP" style="float:left" runat="server" ControlToValidate="txt_homeAdmin_CP" ValidationGroup="valid_homeAdmin_blank" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>                                                                                  
                        <asp:TextBox Enabled="false" ID="txt_homeAdmin_CP" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                </div>  
                <div style="margin-bottom:4px;  clear:both">
                    <asp:Label ID="LabelNroPt_homeAdmin" style="float:left" CssClass="labels" runat="server" Text="Número de puerta " AssociatedControlID="txt_nroPt_homeAdmin"></asp:Label>
                        <asp:RequiredFieldValidator ID="valid_homeAdmin_NroPt" style="float:left" runat="server" ControlToValidate="txt_nroPt_homeAdmin" ValidationGroup="valid_homeAdmin_blank" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>                                                                                                              
                    <asp:TextBox Enabled="false" ID="txt_nroPt_homeAdmin" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                </div> 
                        
            </div>
                   
            <div id="div_registro_der" style="float:right; width:205px;">
                <div style="margin-bottom:4px;  clear:both">
                    <asp:Label ID="LabelApellido_homeAdmin" style="float:left" CssClass="labels" runat="server" Text="Apellido " AssociatedControlID="txt_homeAdmin_Apellido"></asp:Label>
                        <asp:RequiredFieldValidator ID="valid_homeAdmin_apell" style="float:left" runat="server" ControlToValidate="txt_homeAdmin_Apellido" ValidationGroup="valid_homeAdmin_blank" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>                                                                                                                                          
                    <asp:TextBox Enabled="false" ID="txt_homeAdmin_Apellido" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                </div>
                    <div style="margin-bottom:4px;  clear:both">
                    <asp:Label ID="LabelTelefono_homeAdmin" style="float:left" CssClass="labels" runat="server" Text="Telefono " AssociatedControlID="txt_homeAdmin_tel"></asp:Label>
                        <asp:RequiredFieldValidator ID="valid_homeAdmin_tel" style="float:left" runat="server" ControlToValidate="txt_homeAdmin_tel" ValidationGroup="valid_homeAdmin_blank" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>                                                                                                                                                                      
                        <asp:TextBox Enabled="false"  ID="txt_homeAdmin_tel" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                </div>
                <div style="margin-bottom:4px;  clear:both">
                    <asp:Label ID="LabelCiudad_homeAdmin" style="float:left" CssClass="labels" runat="server" Text="Ciudad " AssociatedControlID="txt_homeAdmin_ciudad"></asp:Label>
                        <asp:RequiredFieldValidator ID="valid_homeAdmin_ciudad" style="float:left" runat="server" ControlToValidate="txt_homeAdmin_ciudad" ValidationGroup="valid_homeAdmin_blank" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>                                                                                                                                                                                                  
                    <asp:TextBox Enabled="false" ID="txt_homeAdmin_ciudad" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                </div> 
                <div style="margin-bottom:4px;  clear:both">
                    <asp:Label ID="LabelCalle_homeAdmin" style="float:left" CssClass="labels" runat="server" Text="Calle " AssociatedControlID="txt_homeAdmin_Calle"></asp:Label>
                        <asp:RequiredFieldValidator ID="valid_homeAdmin_calle" style="float:left" runat="server" ControlToValidate="txt_homeAdmin_Calle" ValidationGroup="valid_homeAdmin_blank" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>                                                                                                                                                                                                                              
                    <asp:TextBox Enabled="false" ID="txt_homeAdmin_Calle" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                </div> 
            </div>
            <div style="clear:both"></div>
        </div>

        <div id="div_registro_center" class="cajitas" style="width:380px; clear:both; margin:auto; margin-top:8px">
            <div style="margin-bottom:4px;  clear:both">
                <asp:Label ID="LabelUsuario_homeAdmin" style="float:left" CssClass="labels" runat="server" Text="Nombre de usuario " AssociatedControlID="txt_homeAdmin_Usuario"></asp:Label>
                <asp:TextBox Enabled="false" ID="txt_homeAdmin_Usuario" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
            </div>
            <div style="margin-bottom:4px;  clear:both">
                <asp:Label ID="LabelPassword_homeAdmin" style="float:left" CssClass="labels" runat="server" Text="Password " AssociatedControlID="txt_homeAdmin_passwd"></asp:Label>
                <asp:RequiredFieldValidator ID="valid_homeAdmin_passwd" style="float:left" runat="server" ControlToValidate="txt_homeAdmin_passwd" ValidationGroup="valid_homeAdmin_blank" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>                                                                                                                                                                                                                                                                              
                <asp:TextBox Enabled="false" ID="txt_homeAdmin_passwd" TextMode="Password" CssClass="txt_fields_registro" style="float:right" runat="server"></asp:TextBox>
            </div>
            <div style="clear:both"></div>
        </div>
        <div style="height:20px;">
            <p id="p_homeAdmin_messageServer" runat="server" style="color:red" class="letrasLinks"></p>
        </div>
        <div style="height:25px; margin-top:10px; clear:both; margin:auto">
                <asp:ValidationSummary ID="valid_summary_registro" runat="server" ValidationGroup="valid_homeAdmin_blank" CssClass="letrasLinks" ForeColor="Red" HeaderText="Debes completar los campos señalados" />
        </div>
    </div>
    <div style="clear:both; margin:auto; text-align:center">
        <asp:Button ID="btn_homeAdmin_guardar" runat="server" Text="Guardar" Visible="false" OnClick="btn_homeAdmin_guardar_Click" ValidationGroup="valid_homeAdmin_blank" />
        <asp:Button ID="btn_homeAdmin_modificar" style="" runat="server" Text="Modificar Datos" OnClick="btn_homeAdmin_modificar_Click" />
    </div>

</asp:Content>
