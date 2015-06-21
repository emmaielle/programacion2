using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Solucion_ObligatorioP2
{
    public partial class Ambos_TotalFacturado : System.Web.UI.Page
    {
        Sistema elSis = Sistema.Instancia;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioLogueado"].ToString() == "")
            {
                Response.Redirect("~/Inicio.aspx");
            }
        }

        protected void btn_totalFacturado_ObtenerInfo_Click(object sender, EventArgs e)
        {
            string nroCliente = this.txt_totalFacturado_nroCliente.Text;
            DateTime fechaDesde = this.calendar_totalFacturado_fechaDesde.SelectedDate;
            DateTime fechaHasta = this.calendar_totalFacturado_fechaHasta.SelectedDate;

            elSis.TotalFacturadoAClientePorIntervalo(nroCliente, fechaDesde, fechaHasta);
        }
    }
}