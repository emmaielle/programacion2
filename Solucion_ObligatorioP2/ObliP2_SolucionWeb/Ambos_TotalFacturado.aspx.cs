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
            else
            {
                if ((bool)Session["esAdmin"] == true)
                {
                    this.div_totalFacturado_hidden4Cliente.Visible = true;
                }
            }

            if (this.IsPostBack)
            {
                this.p_totalFacturado_errores.InnerText = "";
            }

        }

        protected void btn_totalFacturado_ObtenerInfo_Click(object sender, EventArgs e)
        {
            string nroCliente;

            // chequeo si es admin o usuario par determinar el numero de documento del cliente en cada caso
            if ((bool)Session["esAdmin"] == true)
            {
                nroCliente = this.txt_totalFacturado_nroCliente.Text;
            }
            else
            {
                string username = Session["UsuarioLogueado"].ToString();
                nroCliente = elSis.BuscarUsuarioPorUsername(username).Documento;
            }

            int numCli;
            bool resultNro = int.TryParse(nroCliente, out numCli);

            if (!string.IsNullOrWhiteSpace(nroCliente))
            {
                if (resultNro)
                {
                    DateTime fechaDesde = this.calendar_totalFacturado_fechaDesde.SelectedDate;
                    DateTime fechaHasta = this.calendar_totalFacturado_fechaHasta.SelectedDate;

                    if (fechaDesde != DateTime.MinValue)
                    {
                        if (fechaHasta != DateTime.MinValue)
                        {
                            decimal total = elSis.TotalFacturadoAClientePorIntervalo(nroCliente, fechaDesde, fechaHasta);
                            lbl_totalFacturado_msjTotal.Text = "Total facturado por cliente " + nroCliente + ": U$S" + total.ToString();
                        }
                        else this.p_totalFacturado_errores.InnerText = "Debe seleccionar fecha de fin";
                    }
                    else this.p_totalFacturado_errores.InnerText = "Debe seleccionar fecha de inicio";
                }
                else this.p_totalFacturado_errores.InnerText = "El número de cliente debe contener sólo números";
            }
            else this.p_totalFacturado_errores.InnerText = "Debe ingresar un nro de cliente";
        }

    }

}
  

