<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Solucion_ObligatorioP2.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link type="text/css" rel="stylesheet" href="Estilos.css"/>
    <script type="text/javascript" src="scripts/jquery-1.11.3.min.js"></script>
    <script type="text/javascript">

        function CheckHideErrorMsg() {
            if (!$("#txt_password").val()) {
                $("#p_inicioErr_messageServer").hide();
            }
        }

        function validarNroEnvio() {
            retorno = false;

            if ($("#txt_home_nroEnvio").val() != "") {
                if (isNaN($("#txt_home_nroEnvio").val())) {
                    $("#lbl_error_grv").text("El código debe contener sólo números");
                }
                else retorno = true;
            }
            else $("#lbl_error_grv").text("Ingresa un número de envío");

            return retorno;
        }

    </script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="div_home_contenedora">
            <p style="font-size:22px; font-family:Verdana;" class="letrasLinks">Bienvenido a EmpresaPostal</p>
            <div id="div_home_central">
                <p style="font-size:13px; font-family:Verdana;" class="letrasLinks">Registrate como cliente o ingresa si ya estás registrado para simular o seguir tus envíos</p>
            
                <div id="div_login_cliente">
                    <p id="p_inicio_iniciarSesion">Inicio de sesión</p>
                    <div id="div_ursrname">
                        <asp:Label ID="lbl_usuario_login" runat="server" Text="Nombre de usuario" AssociatedControlID="txt_username_login"></asp:Label>
                        <asp:TextBox ID="txt_username_login" runat="server" CausesValidation="True" ValidateRequestMode="Enabled" ValidationGroup="val_login"></asp:TextBox>                     
                        <asp:RequiredFieldValidator ID="valid1_txt_username_inicio" runat="server" ControlToValidate="txt_username_login" ForeColor="Red" ValidationGroup="val_login" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </div>
                    <div>
                        <asp:Label ID="lbl_password" runat="server" Text="Contraseña" AssociatedControlID="txt_password"></asp:Label>
                        <asp:TextBox ID="txt_password" TextMode="Password" runat="server" CausesValidation="True" ValidateRequestMode="Enabled" ValidationGroup="val_login"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valid2_txtpassword_inicio" runat="server" ControlToValidate="txt_password" ForeColor="Red" ValidationGroup="val_login" SetFocusOnError="True">*</asp:RequiredFieldValidator>

                    </div>
                    <br />
                    <asp:LinkButton ID="lnk_home_registrarCliente" CssClass="letrasLinks" runat="server" PostBackUrl="~/Registro_Cliente.aspx" >No tienes usuario?</asp:LinkButton>
                    <div id="div_validationSummary_inicio" style="height:40px">
                        <p id="p_inicioErr_messageServer" runat="server" style="color:red; margin:0px" visible="false" class="letrasLinks">El usuario o contraseña son inválidos</p>
                        <asp:ValidationSummary ID="valid_summary_inicio" runat="server" CssClass="letrasLinks" DisplayMode="List" ForeColor="Red" HeaderText="Debes introducir los campos señalados" ValidationGroup="val_login" />
                    </div>
                    <div id="div_btnLogin_inicio">
                        <asp:Button ID="btn_login_inicio" runat="server" Text="Iniciar sesión" ValidationGroup="val_login" OnClientClick="CheckHideErrorMsg()" OnClick="btn_login_inicio_Click" /></div>
                </div>
            </div>

            <div id="div_home_accesoria">
                <p style="font-size:13px; font-family:Verdana;" class="letrasLinks">O rastrea un envío como usuario no registrado con el código del envío deseado</p>
                <div id="div_seguirEnvio">
                    <p id="p_inicio_rastreo">Rastreo de envíos</p>
                    <div id="div_nroEnvio">
                        <asp:Label ID="lbl_home_nroEnvio" runat="server" Text="Código de envío "></asp:Label>
                        <asp:TextBox ID="txt_home_nroEnvio" runat="server"></asp:TextBox>
                    </div>
                    <div id="div_btnHome_seguirEnvio">
                        <asp:Button ID="btn_home_seguirEnvio" runat="server" Text="Rastrear envío" OnClientClick="return validarNroEnvio();" OnClick="btn_home_seguirEnvio_Click" />
                    </div>
                    <div id="div_error_rastreo" style="margin-top: 15px; height:68px; clear:both;" runat="server">
                        <asp:Label ID="lbl_error_grv" CssClass="letrasLinks" style="color:red" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                </div>
            </div>
            <div id="div_messageSuccess">
                <p id="p_Inicio_messageServer" runat="server" style="color:red; text-align:center; clear:both" class="letrasLinks"></p>
            </div>
            <div style="margin:auto; clear:both; vertical-align:central">
                <p id="p_inicioRastreo_nroEnv" visible="false" runat="server" style="padding-top:5px;padding-bottom:5px;; clear:both;color:white; background-color:blue" class="labels"></p>
                <asp:GridView ID="gv_inicio_rastreo" style="margin:auto; vertical-align:central" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Height="16px" Width="722px" CssClass="labels">
                    <Columns>
                        <asp:BoundField DataField="Etapa" HeaderText="Estado" />
                        <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha" />
                        <asp:TemplateField HeaderText="Oficina">
                            <ItemTemplate>
                                <%# Eval("Ubicacion.NroOficina") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Calle">
                        <ItemTemplate>
                            <%# Eval("Ubicacion.DireccionOfiPostal.Calle") %>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Puerta">
                            <ItemTemplate>
                                <%# Eval("Ubicacion.DireccionOfiPostal.Numero") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ciudad">
                            <ItemTemplate>
                                <%# Eval("Ubicacion.DireccionOfiPostal.Ciudad") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pais">
                            <ItemTemplate>
                                <%# Eval("Ubicacion.DireccionOfiPostal.Pais") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
