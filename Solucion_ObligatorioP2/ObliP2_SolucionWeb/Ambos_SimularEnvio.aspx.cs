using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Solucion_ObligatorioP2
{
    public partial class Ambos_SimularEnvio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioLogueado"].ToString() == "")
            {
                Response.Redirect("~/Inicio.aspx");
            }

            if (this.IsPostBack)
            {
                p_simularEnvio_errores.InnerText = "";
            }
        }

        protected void radiobtn_simularEnvio_esPaqueteODocCheckedChanged(object sender, EventArgs e)
        {
            if (this.radiobtn_simularEnvio_esDoc.Checked)
            {
                this.simular_PanelDocumento.Visible = true;
                this.simular_PanelPaquete.Visible = false;
            }

            if (this.radiobtn_simularEnvio_esPaquete.Checked)
            {
                this.simular_PanelPaquete.Visible = true;
                this.simular_PanelDocumento.Visible = false;
            }
        }

        protected void btn_simular_Click(object sender, EventArgs e)
        {
            p_simularEnvio_errores.InnerText = "Algoooo Error";
        }
    }
}