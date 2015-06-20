﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Admin_CrearAdmin.aspx.cs" Inherits="Solucion_ObligatorioP2.Admin_CrearAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="div_crearAdmin_contenedora" class="labels">

        <p id="p_crearAdmin_head" style="font-size:22px; font-family:Verdana;" runat="server" class="letrasLinks">Crear un administrador</p>
        <asp:Label ID="lbl_crearAdmin_headtxt" runat="server" style="color:blue" Text="Ingrese los datos para crear un nuevo administrador"></asp:Label>

        <div class="cajitas" style="margin:10px; padding-bottom:40px; padding-left:140px; padding-right:140px; width:220px; clear:both">
            <div style="clear:both">
                <asp:Label ID="Lbl_CrearAdmin_Doc" style="float:left" runat="server" Text="Documento: "></asp:Label>
                <asp:TextBox ID="txt_crearAdmin_doc" style="width:100px; float:right" runat="server" OnTextChanged="TextBoxDocumento_TextChanged"></asp:TextBox>
            </div>
            <div style="padding-top:10px; clear:both">
                <asp:Label ID="lbl_crearAdmin_Nombre" runat="server" style="float:left" Text="Nombre:"></asp:Label>
                <asp:TextBox ID="txt_crearAdmin_nombre"  style="width:100px;float:right" runat="server" OnTextChanged="TextBoxNombre_TextChanged"></asp:TextBox>
            </div>
            <div style="padding-top:10px; clear:both">
                <asp:Label ID="lbl_crearAdmin_Apellido" style="float:left" runat="server" Text="Apellido:"></asp:Label>
                <asp:TextBox ID="txt_crearAdmin_apellido" style="width:100px; float:right" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:10px; clear:both">
                <asp:Label ID="lbl_crearAdmin_tel" style="float:left" runat="server" Text="Telefono: "></asp:Label>
                <asp:TextBox ID="txt_crearAdmin_telefono" style="width:100px; float:right" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:10px; clear:both">
                <asp:Label ID="lbl_crearAdmin_pais" style="float:left" runat="server" Text="Pais: "></asp:Label>
                <asp:TextBox ID="txt_crearAdmin_pais" style="width:100px; float:right" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            </div>
            <div style="padding-top:10px; clear:both">
                <asp:Label ID="lbl_crearAdmin_ciudad" style="float:left" runat="server" Text="Ciudad: "></asp:Label>
                <asp:TextBox ID="txt_crearAdmin_ciudad" style="width:100px; float:right" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:10px; clear:both">
                <asp:Label ID="lbl_crearAdmin_CP" style="float:left" runat="server" Text="Codigo Postal: "></asp:Label>
                <asp:TextBox ID="txt_crearAdmin_cp" style="width:100px; float:right" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:10px; clear:both">
                <asp:Label ID="lbl_crearAdmin_calle" style="float:left" runat="server" Text="Calle: "></asp:Label>
                <asp:TextBox ID="txt_crearAdmin_calle" style="width:100px; float:right" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:10px; clear:both"> 
                <asp:Label ID="lbl_crearAdmin_NroPta" runat="server" style="float:left" Text="Numero Puerta: "></asp:Label>
                <asp:TextBox ID="txt_crearAdmin_numero" style="width:100px; float:right" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:10px; clear:both"> 
                <asp:Label ID="lbl_crearAdmin_Usr" style="float:left" runat="server" Text="Usuario:"></asp:Label>
                <asp:TextBox ID="txt_crearAdmin_usuario" style="width:100px; float:right" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:10px; clear:both">
                <asp:Label ID="lbl_crearAdmin_password" style="float:left" runat="server" Text="Password:"></asp:Label>
                <asp:TextBox TextMode="Password" style="width:100px; float:right" ID="txt_crearAdmin_password" runat="server"></asp:TextBox>
            </div>
            <div style="padding-top:10px; clear:both">
                <asp:Label ID="lbl_crearAdmin_mail" style="float:left"  runat="server" Text="Mail:"></asp:Label>
                <asp:TextBox ID="txt_crearAdmin_mail" style="width:100px; float:right" runat="server"></asp:TextBox>
            </div>
        </div>
        <div id="div_crearAdmin_errorMessages" style="height:30px">

        </div>
        <div style="padding-top:10px; margin:auto; vertical-align:central; clear:both">
            <asp:Button ID="btn_crearAdmin_altaAdmin" runat="server" OnClick="btn_crearAdmin_altaAdmin_Click" Text="Crear Administrador" />
        </div>
    </div>

</asp:Content>