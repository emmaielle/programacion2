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
                this.p_Inicio_messageServer.InnerText = "Usted se ha registrado como cliente de forma exitosa";
            }

            if (!this.IsPostBack)
            {
                if (Request.QueryString["logout"] == "1")
                {
                    Session.Abandon();
                }
            }
            else
            {
                this.lbl_error_grv.Visible = false;
                this.p_inicioErr_messageServer.Visible = false;
                this.gv_inicio_rastreo.DataSource = null;
                this.gv_inicio_rastreo.DataBind();
                this.p_inicioRastreo_nroEnv.Visible = false;
            }

        }

        protected void btn_login_inicio_Click(object sender, EventArgs e)
        {
           bool mensajeErr = false;
           if (this.txt_password.Text != "" && this.txt_username_login.Text != "")
           {
               Usuario elUsr = elSis.BuscarUsuarioPorUsername(this.txt_username_login.Text);

               if (elUsr != null)
               {
                   if (elUsr.EsAdmin == true)
                   {
                       if (this.txt_password.Text == elUsr.Password)
                       {
                           Session["esAdmin"] = true;
                           Session["UsuarioLogueado"] = elUsr.User;
                           Response.Redirect("~/Ambos_Home.aspx");
                       }
                       else mensajeErr = true;
                   }
                   else
                   {
                       if (this.txt_password.Text == elUsr.Password)
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
                   this.p_inicioErr_messageServer.Visible = true;
               }
           }

        }

        protected void btn_home_seguirEnvio_Click(object sender, EventArgs e)
        {
            cargarDatosRastreo();
        }

        private void cargarDatosRastreo()
        {
            /*Tengo que usar el TryParse para convertir el string que saco del textbox a un 
             int, que es lo que me pide el metodo para recibir*/

            int numero;
            bool result = Int32.TryParse(this.txt_home_nroEnvio.Text, out numero);

            List<EtapaEnvio> listaEnvRastreado = new List<EtapaEnvio>();

            if (result)
            {
                listaEnvRastreado = elSis.RastrearEnvio(numero);

                if (listaEnvRastreado.Count != 0)
                {
                    this.p_inicioRastreo_nroEnv.Visible = true;
                    this.p_inicioRastreo_nroEnv.InnerText = "Envío número " + numero + ": ";
                    this.gv_inicio_rastreo.DataSource = listaEnvRastreado;
                    this.gv_inicio_rastreo.DataBind();
                }
                else
                {
                    this.lbl_error_grv.Visible = true;
                    this.lbl_error_grv.Text = "El envio seleccionado no existe";
                }
            }
            else
            {
                this.lbl_error_grv.Visible = true;
                this.lbl_error_grv.Text = "El envio ingresado debe ser un número";
            }
        }
    }
}