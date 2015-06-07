<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Cliente_home.aspx.cs" Inherits="Solucion_ObligatorioP2.Cliente_home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="div_formulario_homeCli" style="margin-bottom:10px;">
                
        <div id="div_homeCli_top" style="width:520px; clear:both" class="cajitas">
                    
            <div id="div_registro_izq" style="float:left; width:290px;">
                    <div style="margin-bottom:4px;  clear:both">
                    <asp:Label ID="LabelNombre_homeCli" style="float:left" CssClass="labels" runat="server" Text="Nombre " AssociatedControlID="txt_homeCli_nombre"></asp:Label>
                        <asp:RequiredFieldValidator ID="valid_homeCli_nom" style="float:left" runat="server" ControlToValidate="txt_homeCli_nombre" ValidationGroup="valid_homeCli_blank" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    <asp:TextBox Enabled="false" ID="txt_homeCli_nombre" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                </div>
                <div style="margin-bottom:4px; clear:both">
                    <asp:Label ID="LabelCI_homeCli" style="float:left" CssClass="labels" runat="server" Text="Cédula de Identidad " AssociatedControlID="txt_homeCli_CI"></asp:Label>
                    <asp:TextBox Enabled="false" ID="txt_homeCli_CI" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                </div>
                    <div style="margin-bottom:4px;  clear:both">
                    <asp:Label ID="LabelPais_homeCli" style="float:left" CssClass="labels" runat="server" Text="País " AssociatedControlID="txt_homeCli_Pais"></asp:Label>
                        <asp:RequiredFieldValidator ID="valid_homeCli_pais" style="float:left" runat="server" ControlToValidate="txt_homeCli_Pais" ValidationGroup="valid_homeCli_blank" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>                                                        
                        <asp:TextBox Enabled="false" ID="txt_homeCli_Pais" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                    </div>
                    <div style="margin-bottom:4px;  clear:both">
                    <asp:Label ID="LabelCP_homeCli" style="float:left" CssClass="labels" runat="server" Text="Código postal " AssociatedControlID="txt_homeCli_CP"></asp:Label>
                        <asp:RequiredFieldValidator ID="valid_homeCli_CP" style="float:left" runat="server" ControlToValidate="txt_homeCli_CP" ValidationGroup="valid_homeCli_blank" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>                                                                                  
                        <asp:TextBox Enabled="false" ID="txt_homeCli_CP" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                </div>  
                <div style="margin-bottom:4px;  clear:both">
                    <asp:Label ID="LabelNroPt_homeCli" style="float:left" CssClass="labels" runat="server" Text="Número de puerta " AssociatedControlID="txt_nroPt_homeCli"></asp:Label>
                        <asp:RequiredFieldValidator ID="valid_homeCli_NroPt" style="float:left" runat="server" ControlToValidate="txt_nroPt_homeCli" ValidationGroup="valid_homeCli_blank" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>                                                                                                              
                    <asp:TextBox Enabled="false" ID="txt_nroPt_homeCli" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                </div> 
                        
            </div>
                   
            <div id="div_registro_der" style="float:right; width:205px;">
                <div style="margin-bottom:4px;  clear:both">
                    <asp:Label ID="LabelApellido_homeCli" style="float:left" CssClass="labels" runat="server" Text="Apellido " AssociatedControlID="txt_homeCli_Apellido"></asp:Label>
                        <asp:RequiredFieldValidator ID="valid_homeCli_apell" style="float:left" runat="server" ControlToValidate="txt_homeCli_Apellido" ValidationGroup="valid_homeCli_blank" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>                                                                                                                                          
                    <asp:TextBox Enabled="false" ID="txt_homeCli_Apellido" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                </div>
                    <div style="margin-bottom:4px;  clear:both">
                    <asp:Label ID="LabelTelefono_homeCli" style="float:left" CssClass="labels" runat="server" Text="Telefono " AssociatedControlID="txt_homeCli_tel"></asp:Label>
                        <asp:RequiredFieldValidator ID="valid_homeCli_tel" style="float:left" runat="server" ControlToValidate="txt_homeCli_tel" ValidationGroup="valid_homeCli_blank" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>                                                                                                                                                                      
                        <asp:TextBox Enabled="false"  ID="txt_homeCli_tel" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                </div>
                <div style="margin-bottom:4px;  clear:both">
                    <asp:Label ID="LabelCiudad_homeCli" style="float:left" CssClass="labels" runat="server" Text="Ciudad " AssociatedControlID="txt_homeCli_ciudad"></asp:Label>
                        <asp:RequiredFieldValidator ID="valid_homeCli_ciudad" style="float:left" runat="server" ControlToValidate="txt_homeCli_ciudad" ValidationGroup="valid_homeCli_blank" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>                                                                                                                                                                                                  
                    <asp:TextBox Enabled="false" ID="txt_homeCli_ciudad" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                </div> 
                <div style="margin-bottom:4px;  clear:both">
                    <asp:Label ID="LabelCalle_homeCli" style="float:left" CssClass="labels" runat="server" Text="Calle " AssociatedControlID="txt_homeCli_Calle"></asp:Label>
                        <asp:RequiredFieldValidator ID="valid_homeCli_calle" style="float:left" runat="server" ControlToValidate="txt_homeCli_Calle" ValidationGroup="valid_homeCli_blank" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>                                                                                                                                                                                                                              
                    <asp:TextBox Enabled="false" ID="txt_homeCli_Calle" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                </div> 
            </div>
            <div style="clear:both"></div>
        </div>

        <div id="div_registro_center" class="cajitas" style="width:380px; clear:both; margin:auto; margin-top:8px">
            <div style="margin-bottom:4px;  clear:both">
                <asp:Label ID="LabelUsuario_homeCli" style="float:left" CssClass="labels" runat="server" Text="Nombre de usuario " AssociatedControlID="txt_homeCli_Usuario"></asp:Label>
                <asp:TextBox Enabled="false" ID="txt_homeCli_Usuario" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
            </div>
            <div style="margin-bottom:4px;  clear:both">
                <asp:Label ID="LabelPassword_homeCli" style="float:left" CssClass="labels" runat="server" Text="Password " AssociatedControlID="txt_homeCli_passwd"></asp:Label>
                <asp:RequiredFieldValidator ID="valid_homeCli_passwd" style="float:left" runat="server" ControlToValidate="txt_homeCli_passwd" ValidationGroup="valid_homeCli_blank" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>                                                                                                                                                                                                                                                                              
                <asp:TextBox Enabled="false" ID="txt_homeCli_passwd" TextMode="Password" CssClass="txt_fields_registro" style="float:right" runat="server"></asp:TextBox>
            </div>
            <div style="clear:both"></div>
        </div>
        <div style="height:20px;">
            <p id="p_home_messageServer" runat="server" style="color:red" class="letrasLinks"></p>
        </div>
        <div style="height:25px; margin-top:10px">
                <asp:ValidationSummary ID="valid_summary_registro" runat="server" ValidationGroup="valid_homeCli_blank" CssClass="letrasLinks" ForeColor="Red" HeaderText="Debes completar los campos señalados" />
        </div>
    </div>
    <div style="clear:both; margin:auto; text-align:center">
        <asp:Button ID="btn_homeCli_guardar" runat="server" Text="Guardar" Visible="false" OnClick="btn_homeCli_guardar_Click" ValidationGroup="valid_homeCli_blank" />
        <asp:Button ID="btn_homeCli_modificar" style="" runat="server" Text="Modificar Datos" OnClick="btn_homeCli_modificar_Click" />
    </div>
</asp:Content>
