﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Solucion_ObligatorioP2
{
    public partial class Pags_Cliente : System.Web.UI.MasterPage
    {
        // instanciar clase controladora aca, asi no hay que instanciarlo todas las veces?

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string usr = Session["UsuarioLogueado"].ToString();
                this.p_bienvenidoNombreCliente.InnerHtml = "Bienvenido " + usr;
                CargarMenuItems();
            }
        }

        protected void link_logout_cliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio.aspx?logout=1");
        }

        private void CargarMenuItems()
        {
            Control menuMaster = this.FindControl("Menu_master");
            MenuItemCollection menuItems = ((Menu)menuMaster).Items;

            MenuItem envio = new MenuItem("Envio");
            menuItems.Add(envio);

            MenuItem crearEnvio = new MenuItem("Crear");
            envio.ChildItems.Add(crearEnvio);
            crearEnvio.NavigateUrl = "~/Admin_crearEnvio.aspx";

            MenuItem actualizar = new MenuItem("Actualizar");
            envio.ChildItems.Add(actualizar);
            actualizar.NavigateUrl = "~/Admin_ActualizarEnvio.aspx";

            MenuItem simular = new MenuItem("Simular");
            envio.ChildItems.Add(simular);
            simular.NavigateUrl = "~/Ambos_SimularEnvio.aspx";

            MenuItem rastrear = new MenuItem("Rastrear");
            envio.ChildItems.Add(rastrear);
            rastrear.NavigateUrl = "~/Ambos_RastrearEnvio.aspx";

            MenuItem ttlFact = new MenuItem("Total Facturado");
            envio.ChildItems.Add(ttlFact);
            ttlFact.NavigateUrl = "~/Ambos_TotalFacturado.aspx";

            MenuItem listadoEnvios = new MenuItem("Listado de envios");
            envio.ChildItems.Add(listadoEnvios);
            listadoEnvios.NavigateUrl = "~/Ambos_ListarEnvios.aspx";

            MenuItem crearAdmin = new MenuItem("Crear administrador");
            menuItems.Add(crearAdmin);
            crearAdmin.NavigateUrl = "~/Admin_CrearAdmin.aspx"; 

            if ((bool)Session["esAdmin"] == false && (bool)Session["esCliente"] == true)
            {
                menuItems.Remove(crearAdmin);
                envio.ChildItems.Remove(crearEnvio);
                envio.ChildItems.Remove(actualizar);
            }
        }

    }
}