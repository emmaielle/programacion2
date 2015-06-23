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
                if (nroCliente == null || nroCliente == "")
                {
                    p_totalFacturado_errores.InnerText = "Debe ingresar un nro de cliente";
                }

            DateTime fechaDesde = this.calendar_totalFacturado_fechaDesde.SelectedDate;

                if (fechaDesde == null) 
                 {
                 p_totalFacturado_errores.InnerText = "Debe seleccionar fecha de Inicio";

                 }
            DateTime fechaHasta = this.calendar_totalFacturado_fechaHasta.SelectedDate;

            
                if (fechaDesde == null) 
                 {
                 p_totalFacturado_errores.InnerText = "Debe seleccionar fecha de fin";
                 }

            elSis.TotalFacturadoAClientePorIntervalo(nroCliente, fechaDesde, fechaHasta);
        }
    }
}