using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Solucion_ObligatorioP2
{
    public partial class Ambos_RastrearEnvio : System.Web.UI.Page

    {
        Sistema elSis = Sistema.Instancia;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioLogueado"].ToString() == "")
            {
                Response.Redirect("~/Inicio.aspx");
            }

            if (this.IsPostBack)
            {
                p_rastrearEnvio_error.InnerText = "";
                this.gvRastreo.DataSource = null;
                this.gvRastreo.DataBind();
            }
        }

        private void cargarDatosRastreo() 
        {
            /*Tengo que usar el TryParse para convertir el string que saco del textbox a un 
             int, que es lo que me pide el metodo para recibir*/

            int numero;
            bool result = Int32.TryParse(txt_rastrearEnvio_nroEnvio.Text, out numero);

            List<EtapaEnvio> listaEnvRastreado = new List<EtapaEnvio>();

            if (result)
            {
                listaEnvRastreado = elSis.RastrearEnvio(numero);

                if (listaEnvRastreado.Count != 0)
                {
                    this.gvRastreo.DataSource = listaEnvRastreado;
                    this.gvRastreo.DataBind();
                }
                else
                {
                    p_rastrearEnvio_error.Visible = true;
                    p_rastrearEnvio_error.InnerText = "El envio seleccionado no existe";
                }
            }
            else
            {
                p_rastrearEnvio_error.Visible = true;
                p_rastrearEnvio_error.InnerText = "El envio ingresado debe ser un número";
            }
        }

        protected void btn_rastrearEnvio_rastrear_Click(object sender, EventArgs e)
        {
            this.cargarDatosRastreo();
        }
    }
}