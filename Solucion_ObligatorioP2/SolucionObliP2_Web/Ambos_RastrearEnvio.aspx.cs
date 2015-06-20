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

            //if (Session["UsuarioLogueado"].ToString() == "")
            //{
            //    Response.Redirect("~/Inicio.aspx");
            //}
            //else
            //{
            //    if ((bool)Session["esAdmin"] == true)
            //    {

            //    }
            //    else if ((bool)Session["esCliente"] == true)
            //    {

            //    }
            //}
            }



        private void cargarInfoRastreo()
        {
          
        }



        protected void gvRastreo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Pendiente validaciones

            int indice = int.Parse(e.CommandArgument.ToString());
            int codigo = (int)this.gvRastreo.DataKeys[indice].Value;

        

        //


        }


      //

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)

        {

            string envio = this.gvRastreo.SelectedDataKey.Value.ToString();
        


        }

        protected void btn_rastrearEnvio_rastrear_Click(object sender, EventArgs e)
        {
            int numeroEnvio;
            bool resultadoNumero = Int32.TryParse (txt_rastrearEnvio_nroEnvio.Text, out numeroEnvio);

            this.gvRastreo.DataSource = elSis.RastrearEnvio(numeroEnvio);
            this.gvRastreo.DataBind();
            
            
            if (elSis.BuscarEnvio(numeroEnvio) != null) {
                elSis.RastrearEnvio(numeroEnvio);
            }
        }
    }
}
