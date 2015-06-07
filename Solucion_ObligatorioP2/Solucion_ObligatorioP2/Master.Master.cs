using System;
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
                p_bienvenidoNombreCliente.InnerHtml = "Bienvenido " + usr;

                CargarMenuItems();
            }

        }

        protected void link_logout_cliente_Click(object sender, EventArgs e)
        {
            // restaurar la sesion y redireccionar a Inicio
            Session["esAdmin"] = false;
            Session["esCliente"] = false;
            Session["UsuarioLogueado"] = "";
            Response.Redirect("~/Inicio.aspx");
        }

        private void CargarMenuItems()
        {
            Control menuMaster = this.FindControl("Menu_master");
            MenuItemCollection menuItems = ((Menu)menuMaster).Items;

            MenuItem envio = new MenuItem("Envio");
            menuItems.Add(envio);

            MenuItem crearEnvio = new MenuItem("Crear");
            envio.ChildItems.Add(crearEnvio);
            MenuItem actualizar = new MenuItem("Actualizar");
            envio.ChildItems.Add(actualizar);
            MenuItem simular = new MenuItem("Simular");
            envio.ChildItems.Add(simular);
            MenuItem rastrear = new MenuItem("Rastrear");
            envio.ChildItems.Add(rastrear);
            MenuItem ttlFact = new MenuItem("Total Facturado");
            envio.ChildItems.Add(ttlFact);
            MenuItem envMAYmonto = new MenuItem("Envíos que superan monto dado");
            envio.ChildItems.Add(envMAYmonto);
            MenuItem transit5 = new MenuItem("En tránsito por más de cinco días");
            envio.ChildItems.Add(transit5);

            MenuItem crearAdmin = new MenuItem("Crear administrador");
            menuItems.Add(crearAdmin);
            crearAdmin.NavigateUrl = ""; // <<<<<<----------------------

            if ((bool)Session["esAdmin"] == false && (bool)Session["esCliente"] == true)
            {
                menuItems.Remove(crearAdmin);
                envio.ChildItems.Remove(crearEnvio);
                envio.ChildItems.Remove(actualizar);
            }
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {

        }


    }
}