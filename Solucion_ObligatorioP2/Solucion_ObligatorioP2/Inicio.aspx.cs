using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Solucion_ObligatorioP2
{
    public partial class Inicio : System.Web.UI.Page
    {
        Sistema elSis = Sistema.Instancia;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.WebForms;
            ScriptResourceDefinition jQuery = new ScriptResourceDefinition();
            jQuery.Path = "~/scripts/jquery-2.1.3.min.js";
            jQuery.DebugPath = "~/scripts/jquery-2.1.3.js";
            jQuery.CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-2.1.3.min.js";
            jQuery.CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-2.1.3.js";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", jQuery);

            if (Request.QueryString["message"] == "true")
            {
                p_Inicio_messageServer.InnerText = "Usted se ha ingresado como cliente de forma exitosa";
            }

            if (Request.QueryString["logout"] == "1")
            {
                Session.Abandon();
            }

        }

        protected void btn_login_inicio_Click(object sender, EventArgs e)
        {

           Usuario elUsr = elSis.BuscarUsuarioPorUsername(txt_username_login.Text);

           if (elUsr != null)
           {
               if (elUsr.EsAdmin == true)
               {
                   if (txt_password.Text == elUsr.Password)
                   {
                       Session["esAdmin"] = true;
                       Session["UsuarioLogueado"] = elUsr.User;
                       Response.Redirect("~/Admin_home.aspx");
                   }
                   else
                   {
                       //mensaje de error
                   }
               }
               else
               {
                   if (txt_password.Text == elUsr.Password)
                   {
                       Session["esCliente"] = true;
                       Session["UsuarioLogueado"] = elUsr.User;
                       Response.Redirect("~/Cliente_home.aspx");
                   }
                   else
                   {
                       //mensaje de error
                   }
               }
           }
        }

        protected void btn_home_seguirEnvio_Click(object sender, EventArgs e)
        {
            pnl_rastreo_USR.Visible = true;
        }


    }
}