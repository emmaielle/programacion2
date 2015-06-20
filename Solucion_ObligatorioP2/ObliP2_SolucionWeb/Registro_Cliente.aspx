<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro_Cliente.aspx.cs" Inherits="Solucion_ObligatorioP2.Registro_Usuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link type="text/css" rel="stylesheet" href="Estilos.css"/>
    <script type="text/javascript" src="scripts/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" src="scripts/registro_cliente.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:LinkButton CssClass="letrasLinks" style="float:right; height: 16px;" ID="link_registro_volver" runat="server" OnClick="link_registro_volver_Click">Volver</asp:LinkButton>
        <div id="div_registro_contenedora">
            <p style="font-size:22px; font-family:Verdana;" class="letrasLinks">Registro de Cliente</p>

            <div id="div_formulario_registro" style="margin-bottom:10px;">
                
                <div id="div_registro_top" style="width:520px; clear:both" class="cajitas">
                    
                    <div id="div_registro_izq" style="float:left; width:290px;">
                         <div style="margin-bottom:4px;  clear:both">
                            <asp:Label ID="LabelNombre_registro" style="float:left" CssClass="labels" runat="server" Text="Nombre " AssociatedControlID="txt_registro_nombre"></asp:Label>
                            <asp:TextBox ID="txt_registro_nombre" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                        </div>
                        <div style="margin-bottom:4px; clear:both">
                            <asp:Label ID="LabelCI_registro" style="float:left" CssClass="labels" runat="server" Text="Cédula de Identidad " AssociatedControlID="txt_registro_CI"></asp:Label>
                            <asp:TextBox ID="txt_registro_CI" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                        </div>
                         <div style="margin-bottom:4px;  clear:both">
                            <asp:Label ID="LabelPais_registro" style="float:left" CssClass="labels" runat="server" Text="País " AssociatedControlID="txt_registro_Pais"></asp:Label>
                             <asp:TextBox ID="txt_registro_Pais" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                         </div>
                         <div style="margin-bottom:4px;  clear:both">
                            <asp:Label ID="LabelCP_registro" style="float:left" CssClass="labels" runat="server" Text="Código postal " AssociatedControlID="txt_registro_CP"></asp:Label>
                             <asp:TextBox ID="txt_registro_CP" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                        </div>  
                        <div style="margin-bottom:4px;  clear:both">
                            <asp:Label ID="LabelNroPt_registro" style="float:left" CssClass="labels" runat="server" Text="Número de puerta " AssociatedControlID="txt_nroPt_registro"></asp:Label>
                            <asp:TextBox ID="txt_nroPt_registro" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                        </div>                        
                    </div>
                   
                    <div id="div_registro_der" style="float:right; width:205px;">
                        <div style="margin-bottom:4px;  clear:both">
                            <asp:Label ID="LabelApellido_registro" style="float:left" CssClass="labels" runat="server" Text="Apellido " AssociatedControlID="txt_registro_Apellido"></asp:Label>
                            <asp:TextBox ID="txt_registro_Apellido" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                        </div>
                         <div style="margin-bottom:4px;  clear:both">
                            <asp:Label ID="LabelTelefono_registro" style="float:left" CssClass="labels" runat="server" Text="Telefono " AssociatedControlID="txt_registro_tel"></asp:Label>
                             <asp:TextBox ID="txt_registro_tel" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                        </div>
                        <div style="margin-bottom:4px;  clear:both">
                            <asp:Label ID="LabelCiudad_registro" style="float:left" CssClass="labels" runat="server" Text="Ciudad " AssociatedControlID="txt_registro_ciudad"></asp:Label>
                            <asp:TextBox ID="txt_registro_ciudad" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                        </div> 
                        <div style="margin-bottom:4px;  clear:both">
                            <asp:Label ID="LabelCalle_registro" style="float:left" CssClass="labels" runat="server" Text="Calle " AssociatedControlID="txt_registro_Calle"></asp:Label>
                            <asp:TextBox ID="txt_registro_Calle" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                        </div>
                        <div style="margin-bottom:4px;  clear:both">
                            <asp:Label ID="LabelMail_registro" style="float:left" CssClass="labels" runat="server" Text="Mail"></asp:Label>
                            <asp:TextBox ID="txt_registro_mail" runat="server" style="float:right" CssClass="txt_fields_registro"></asp:TextBox>
                        </div> 
                    </div>
                    <div style="clear:both"></div>
                </div>

                <div id="div_registro_center" class="cajitas" style="width:380px; clear:both; margin:auto; margin-top:8px">
                    <div style="margin-bottom:4px;  clear:both">
                        <asp:Label ID="LabelUsuario_registro" style="float:left" CssClass="labels" runat="server" Text="Nombre de usuario " AssociatedControlID="txt_registro_Usuario"></asp:Label>
                        <asp:TextBox ID="txt_registro_Usuario" style="float:right" CssClass="txt_fields_registro" runat="server"></asp:TextBox>
                    </div>
                    <div style="margin-bottom:4px;  clear:both">
                        <asp:Label ID="LabelPassword_registro" style="float:left" CssClass="labels" runat="server" Text="Password " AssociatedControlID="txt_registro_passwd"></asp:Label>
                        <asp:TextBox ID="txt_registro_passwd" TextMode="Password" CssClass="txt_fields_registro" style="float:right" runat="server"></asp:TextBox>
                    </div>
                    <div style="clear:both"></div>
                </div>
            </div>
            <div style="height:20px;">
                <p id="p_registro_message" runat="server" style="color:red" class="letrasLinks"></p>
            </div>
            <div style="clear:both; padding-top:15px; ">
                <asp:Button ID="btn_registro_registrar" runat="server" Text="Registrarme" ValidationGroup="valid_registro_blank" OnClientClick="return validarNumerosyRangos();" OnClick="btn_registro_registrar_Click1" />
            </div>
        </div>
    </form>
</body>
</html>
