<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Ambos_RastrearEnvio.aspx.cs" Inherits="Solucion_ObligatorioP2.Ambos_RastrearEnvio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="div_rastrearEnvio_contenedora" class="labels">
        
        <p id="p_rastearEnvio_head" style="font-size:22px; font-family:Verdana;" runat="server" class="letrasLinks">Rastreo de envios</p>
        <div style="clear:both">
            <asp:Label ID="lbl_rastrearEnvio_nroEnvio" runat="server" Text="Ingrese numero de envio:"></asp:Label>
            <asp:RequiredFieldValidator ID="valid_rastrearEnvio_nro" runat="server" CssClass="labels" ControlToValidate="txt_rastrearEnvio_nroEnvio" ForeColor="Red" ValidationGroup="empty_env"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txt_rastrearEnvio_nroEnvio" style="margin-left:5px" runat="server"></asp:TextBox>
        </div>
        <div id="div_rastrearEnvio_maessagesError" style="clear:both; margin-top:10px; height:30px">
            <p id="p_rastrearEnvio_error" runat="server" style="color:red" visible="false" class="letrasLinks"></p>
            <asp:ValidationSummary ID="valid_summ_rastrearEnvio" ForeColor="red" runat="server" CssClass="labels" ValidationGroup="empty_env" HeaderText="Debe ingresar un número de envio" />
        </div>
        <div style="clear:both; margin-top:10px">
            <asp:Button ID="btn_rastrearEnvio_rastrear" runat="server" OnClick="btn_rastrearEnvio_rastrear_Click" Text="Rastrear" ValidationGroup="empty_env" />
        </div>



        <div style="clear:both; margin-top:20px">
        </div>

        <asp:GridView ID="gvRastreo" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Height="16px">
            <Columns>
                <asp:BoundField DataField="etapa" HeaderText="Estado" />
                <asp:BoundField DataField="fechaIngreso" HeaderText="Fecha" />
                <asp:TemplateField HeaderText="Nro Oficina">
                    <ItemTemplate>
                        <%# Eval("Ubicacion.NroOficina") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Calle">
                <ItemTemplate>
                    <%# Eval("Ubicacion.DireccionOfiPostal.Calle") %>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nro puerta">
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
</asp:Content>
