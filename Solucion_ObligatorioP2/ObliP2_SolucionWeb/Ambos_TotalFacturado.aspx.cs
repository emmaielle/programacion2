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

            // los if/else tienen que estar anidados, porque fijate que si la condicion no se cumple, igual le 
            // decis que llame a la funcion de calcular el total, lo unico que tambien te va a mostrar el msj que le digas
            
            if (nroCliente != null || nroCliente == "")
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