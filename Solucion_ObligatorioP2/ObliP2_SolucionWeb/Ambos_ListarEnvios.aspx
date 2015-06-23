<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Ambos_ListarEnvios.aspx.cs" Inherits="Solucion_ObligatorioP2.Ambos_EnvSuperanMonto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="scripts/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" src="scripts/ListarEnvios.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="div_superanMonto_contenedora" runat="server" style=" width:780px; margin:auto; text-align:center; padding-bottom:40px" class="labels">
        <p id="p_superanMonto_head" style="font-size:22px; font-family:Verdana;" runat="server" class="letrasLinks">Listado de envios</p>
        
        <div style="clear:both">
            <div id="div_listarEnvios_Ambos_superaMonto" runat="server" class="cajitas" style="padding-bottom:20px; width:240px; float:left">
                <p id="p_listarEnv_head_superanMonto">Envíos cuyo precio supera un monto dado</p>
                <div id="div_superanMonto_elegirCliente" runat="server" Visible="false" style="clear:both; padding-top:15px">
                    <asp:Label ID="lbl_superanMonto_usuario" style="float:left" runat="server" Text="Documento cliente: "></asp:Label>
                    <asp:TextBox ID="txt_superanMonto_usrName" style="width:90px; float:right; margin-left:5px" runat="server"></asp:TextBox>
                </div>
                <div style="width:236px; margin:auto; vertical-align:central; clear:both; padding-top:15px">
                    <asp:Label ID="lbl_superanMonto_monto" runat="server" style="float:left" Text="Ingresar monto: "></asp:Label>
                    <asp:TextBox ID="txt_superanMonto_monto" style="width:90px; float:right; margin-left:5px" runat="server"></asp:TextBox>
                </div>
                <div id="div_superanMonto_errorMesages" style="height:25px; clear:both; padding-top:10px">
                    <asp:Label ID="lbl_superanMonto_messageServer" runat="server" style="color:red; margin:0px" class="letrasLinks"></asp:Label>
                </div>
                <div style="clear:both; margin:auto; vertical-align:central; padding-top:10px">
                    <asp:Button ID="btn_superanMonto_listar" runat="server" Text="Obtener envíos" OnClientClick="return validarNros();" ValidationGroup="emptyField" OnClick="btn_superanMonto_listar_Click" />
                </div>
            </div>
            
            <div id="div_listarEnvios_Ambos_envParaEntregar" runat="server" class="cajitas" style="padding-bottom:45px; margin-left:5px;  width:240px; float:left">
                <p id="p_listarEnv_head_paraEntregar">Envíos para entregar o ya entregados</p>
                
                <div id="div_listarEnvios_paraEntregar_elegirCliente" runat="server" Visible="false" style="clear:both; padding-top:15px">
                    <asp:Label ID="Label1" style="float:left" runat="server" Text="Documento cliente: "></asp:Label>
                    <asp:TextBox ID="txt_listarEnv_paraEntregar_usrName" style="width:90px; float:right; margin-left:5px" runat="server"></asp:TextBox>
                </div>

                <div id="div1" style="height:35px; clear:both; padding-top:10px">
                    <asp:Label ID="lbl_paraEntregar_messageServer" runat="server" style="color:red; margin:0px" class="letrasLinks"></asp:Label>
                </div>

                <div style="clear:both; margin:auto; vertical-align:central; padding-top:10px">
                    <asp:Button ID="btn_listarEnvios_paraEntregar_listar" runat="server" Text="Obtener envíos" ValidationGroup="emptyField_paraEntregar" OnClientClick="return validarCli_nro();" OnClick="btn_listarEnvios_paraEntregar_listar_Click" />
                </div>
            </div>

            <div id="div_listarEnvios_SoloAdmin_transito5d" runat="server" visible="false" class="cajitas" style="padding-bottom:126px; margin-left:5px; width:200px; float:left">
                <p id="p_listarEnv_head_enTransito5d">Envíos en tránsito con más de 5 días de enviados</p>
                <div style="clear:both; margin:auto; vertical-align:central; padding-top:10px">
                    <asp:Button ID="btn_listarEnvTransito5d" runat="server" Text="Obtener envíos" ValidationGroup="emptyField_5dias" OnClick="btn_listaeEnvTransito5_Click" />
                </div>
            </div>
        </div>
        <div style="clear:both"></div>
    </div>
    <div id="div_superanMonto_gridresult" class="labels" runat="server" style="margin:auto; vertical-align:central; width:900px; padding-bottom:30px">
        <p id="p_listarEnvios_noSeEncontro" style="font-family: Verdana; text-align:center" runat="server" visible="false">No hay envios para esta consulta</p>
        <div id="div_grv_envios" style="margin:auto; vertical-align:central; clear:both" runat="server" visible="false"> 
            <p id="p_listarEnvio_headerResult" style="background-color: #042bc4; font-family: Verdana; color: white; padding-left:5px; padding-top:5px; padding-bottom:5px;" runat="server"></p> 
            <div>   
                <asp:GridView ID="grid_listarEnvios_env" CssClass="labels" style="clear:both;margin:auto; margin-top:20px; vertical-align:central" runat="server" BackColor="#EDF6F5" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" Height="16px" Width="770px" Font-Size="Smaller">
                    <Columns>
                        <asp:BoundField DataField="NroEnvio" HeaderText="Nº" />
                        <asp:BoundField DataField="TipoEnvio" HeaderText="Tipo" />
                        <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha Ingreso" />
                        <asp:BoundField DataField="DocCliente" HeaderText="Doc Cliente" />
                        <asp:BoundField DataField="NombreDestinatario" HeaderText="Destinatario" />
                        <asp:BoundField DataField="PesoEnKG" HeaderText="Peso (Kg)" />
                        <asp:BoundField DataField="PrecioFinal" HeaderText="Precio (U$S)" />
                        <asp:BoundField DataField="NombreRecibio" HeaderText="Recibio" />
                        <asp:ImageField DataImageUrlField="FirmaRecibio" DataImageUrlFormatString="./fotosFirmas/{0}" HeaderText="Firma Recibio">
                        </asp:ImageField>
                        <asp:BoundField DataField="Etapa" HeaderText="Etapa" />
                        <asp:BoundField DataField="FechaIngresoParaEntregar" HeaderText="Para entregar desde:" />
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
    </div>
</asp:Content>
