using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Solucion_ObligatorioP2
{
    public partial class Pags_Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // instanciar clase controladora acá, asi no hay que hacerlo todas las veces?
        }

        protected void link_logout_admin_Click(object sender, EventArgs e)
        {
            // restaurar la sesion y redireccionar a Inicio
            Response.Redirect("~/Inicio.aspx");
        }
    }
}