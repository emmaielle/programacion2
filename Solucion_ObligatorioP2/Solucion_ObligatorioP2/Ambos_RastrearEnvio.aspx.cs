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
            //No controlo porque esto pueden hacerlo tanto clientes como admins
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cargarDatosRastreo() {

            /*Tengo que usar el TryParse para convertir el string que saco del textbox a un 
             int, que es lo que me pide el metodo para recibirs*/
            string nroEnvio = txt_rastrearEnvio_nroEnvio.Text;
            int numero;
            bool result = Int32.TryParse(nroEnvio, out numero);
            elSis.RastrearEnvio(numero);
            this.gvRastreo.DataSource = elSis.RastrearEnvio(numero);
            this.gvRastreo.DataBind();
        }

        //Para que me sirve esto? Boton de GridView?
        protected void gvRastreo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Pendiente validaciones
            }


        protected void btn_rastrearEnvio_rastrear_Click(object sender, EventArgs e)
        {
            
            this.cargarDatosRastreo();
        }
    }
}