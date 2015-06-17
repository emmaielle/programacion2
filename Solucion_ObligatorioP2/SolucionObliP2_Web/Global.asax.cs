using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Solucion_ObligatorioP2
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            // instanciar clase controladora aca, asi no hay problemas de multiples usuarios instanciando a la vez
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["esAdmin"] = false;
            Session["esCliente"] = false;
            Session["UsuarioLogueado"] = "";
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}