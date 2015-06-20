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
            if (Request.QueryString["message"] == "true")
            {
                p_Inicio_messageServer.InnerText = "Usted se ha ingresado como cliente de forma exitosa";
            }

            if (!this.IsPostBack)
            {
                if (Request.QueryString["logout"] == "1")
                {
                    Session.Abandon();
                }
            }
            else p_inicioErr_messageServer.Visible = false;

        }

        protected void btn_login_inicio_Click(object sender, EventArgs e)
        {
           bool mensajeErr = false;
           if (txt_password.Text != "" && txt_username_login.Text != "")
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
                           Response.Redirect("~/Ambos_Home.aspx");
                       }
                       else mensajeErr = true;
                   }
                   else
                   {
                       if (txt_password.Text == elUsr.Password)
                       {
                           Session["esCliente"] = true;
                           Session["UsuarioLogueado"] = elUsr.User;
                           Response.Redirect("~/Ambos_Home.aspx");
                       }
                       else mensajeErr = true;
                   }
               }
               else { mensajeErr = true; }

               if (mensajeErr)
               {
                   p_inicioErr_messageServer.Visible = true;
               }
           }

        }

        protected void btn_home_seguirEnvio_Click(object sender, EventArgs e)
        {
            pnl_rastreo_USR.Visible = true;
        }


    }
}