<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Ambos_ListarEnvios.aspx.cs" Inherits="Solucion_ObligatorioP2.Ambos_EnvSuperanMonto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="div_superanMonto_contenedora" style="padding-bottom:40px" class="labels">
        <p id="p_superanMonto_head" style="font-size:22px; font-family:Verdana;" runat="server" class="letrasLinks">Listado de envios</p>
        
        <div style="clear:both">
            <div class="cajitas" style="padding-bottom:20px; width:240px; float:left">
                <p id="p_listarEnv_head_superanMonto">Envios cuyo precio supera un monto dado</p>
                <div id="div_superanMonto_elegirCliente" runat="server" Visible="false" style="clear:both; padding-top:15px">
                    <asp:Label ID="lbl_superanMonto_usuario" style="float:left" runat="server" Text="Username cliente: "></asp:Label>
                    <asp:RequiredFieldValidator style="float:left" ID="valid_superanMonto_emptyUsr" runat="server" Text="*" ControlToValidate="txt_superanMonto_usrName" ValidationGroup="emptyField" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txt_superanMonto_usrName" style="width:100px; float:right; margin-left:5px" runat="server"></asp:TextBox>
                </div>
                <div style="clear:both; padding-top:15px">
                    <asp:Label ID="lbl_superanMonto_monto" runat="server" style="float:left" Text="Ingresar monto: "></asp:Label>
                    <asp:RequiredFieldValidator style="float:left" ID="valid_superanMonto_emptyMonto" runat="server" ValidationGroup="emptyField" Text="*" ControlToValidate="txt_superanMonto_monto" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txt_superanMonto_monto" style="width:100px; float:right; margin-left:5px" runat="server"></asp:TextBox>
                </div>
                <div id="div_superanMonto_errorMesages" style="height:25px; clear:both; padding-top:10px">
                    <p id="p_superanMonto_messageServer" runat="server" style="color:red; margin:0px" visible="false" class="letrasLinks"></p>
                    <asp:ValidationSummary ID="valid_superanMonto_empty" runat="server" ValidationGroup="emptyField" ForeColor="Red" HeaderText="Los campos indicados son requeridos" />
                </div>
                <div style="clear:both; margin:auto; vertical-align:central; padding-top:10px">
                    <asp:Button ID="btn_superanMonto_listar" runat="server" Text="Calcular" ValidationGroup="emptyField" OnClick="btn_superanMonto_listar_Click" />
                </div>
            </div>
            <div class="cajitas" style="padding-bottom:20px;  width:240px; float:right">
                <p id="p_listarEnv_head_enTransito5d">Envios en tránsito con más de 5 días de enviados</p>
                <div id="div_listarEnvios_enTransito5dias_elegirCli" runat="server" Visible="false" style="clear:both; padding-top:15px">
                    <asp:Label ID="lbl_listarEnv_EnTrans5dias_username" style="float:left" runat="server" Text="Username cliente: "></asp:Label>
                    <asp:RequiredFieldValidator style="float:left" ID="valid_listarEnvios_EnTrans5" runat="server" Text="*" ControlToValidate="txt_listarEnvios_enTransito5_username" ValidationGroup="emptyField_5dias" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txt_listarEnvios_enTransito5_username" style="width:100px; float:right; margin-left:5px" runat="server"></asp:TextBox>
                </div>
                <div style="height:35px; clear:both"></div>
                <div id="div_listarEnvTransito5d_errorMsgs" style="height:25px; clear:both; padding-top:10px">
                    <p id="p1" runat="server" style="color:red; margin:0px" visible="false" class="letrasLinks"></p>
                    <asp:ValidationSummary ID="valid_listarEnv_summary" runat="server" ValidationGroup="emptyField_5dias" ForeColor="Red" HeaderText="Los campos indicados son requeridos" />
                </div>
                <div style="clear:both; margin:auto; vertical-align:central; padding-top:10px">
                    <asp:Button ID="btn_listarEnvTransito5d" runat="server" Text="Obtener envios" ValidationGroup="emptyField_5dias" OnClick="btn_listaeEnvTransito5_Click" />
                </div>
            </div>
        </div>
        <div style="clear:both"></div>
    </div>
    <div id="div_superanMonto_gridresult" class="labels" runat="server" style="margin:auto; vertical-align:central; width:900px; padding-bottom:30px">
        <div id="div_grv_envDocumento" style="margin:auto; vertical-align:central; clear:both" runat="server" visible="false"> 
            <p id="p_listarEnvio_headerResult" style="background-color: #042bc4; font-family: Verdana; color: white; padding-left:5px; padding-top:5px; padding-bottom:5px;" runat="server"></p> 
            <div>   
                <asp:GridView ID="grid_superanMonto_enviosDoc" CssClass="labels" style="clear:both;margin:auto; margin-top:20px; vertical-align:central" runat="server" BackColor="#EDF6F5" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" Height="16px" Width="770px" Font-Size="Smaller">
                    <Columns>
                        <asp:BoundField DataField="NroEnvio" HeaderText="Nº" />
                        <asp:BoundField DataField="NombreRecibio" HeaderText="Recibio" />
                        <asp:BoundField DataField="FirmaRecibio" HeaderText="Firma Recibio" />
                        <asp:BoundField DataField="NombreDestinatario" HeaderText="Destinatario" />
                        <asp:BoundField DataField="Peso" HeaderText="Peso (Kg)" />
                        <asp:BoundField DataField="PrecioFinal" HeaderText="Precio ($U)" />
                        <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha Ingreso" />
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
            <div id="div_grv_envPaquete" style="padding-top:30px" runat="server" visible="false">
                <asp:Label ID="lbl_superanMonto_envPaqs" style="padding-top:50px; padding-bottom:30px" runat="server" Text="Envios tipo paquete: "></asp:Label>

                <asp:GridView ID="grid_superanMonto_enviosPaquete" CssClass="labels" style="clear:both;margin:auto;vertical-align:central;margin-top:20px" runat="server" BackColor="#EDF6F5" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" Width="770px" Height="16px" Font-Size="Smaller">
                    <Columns>
                        <asp:BoundField DataField="NroEnvio" HeaderText="Nº" />
                        <asp:BoundField DataField="NombreRecibio" HeaderText="Recibió" />
                        <asp:BoundField DataField="FirmaRecibio" HeaderText="Firma Recibio" />
                        <asp:BoundField DataField="NombreDestinatario" HeaderText="Destinatario" />
                        <asp:BoundField DataField="Alto" HeaderText="Alto (cm)" />
                        <asp:BoundField DataField="Ancho" HeaderText="Ancho (cm)" />
                        <asp:BoundField DataField="Largo" HeaderText="Largo (cm)" />
                        <asp:BoundField DataField="CostoBasePorGramo" HeaderText="Costo/gr ($U)" />
                        <asp:BoundField DataField="ValorDeclarado" HeaderText="Valor declarado ($U)" />
                        <asp:BoundField DataField="TieneSeguro" HeaderText="Seguro?" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                        <asp:BoundField DataField="PrecioFinal" HeaderText="Precio ($U)" />
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
