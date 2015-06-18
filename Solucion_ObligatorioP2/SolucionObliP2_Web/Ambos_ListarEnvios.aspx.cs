using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Solucion_ObligatorioP2
{
    public partial class Ambos_EnvSuperanMonto : System.Web.UI.Page
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
                    div_superanMonto_elegirCliente.Visible = true;
                    div_listarEnvios_SoloAdmin_transito5d.Visible = true;
                }
                else if ((bool)Session["esCliente"] == true)
                {
                    div_listarEnvios_Ambos_superaMonto.Style.Add("clear", "both");
                    div_listarEnvios_Ambos_superaMonto.Style.Remove("float");
                    div_listarEnvios_Ambos_superaMonto.Style.Remove("width");
                }
            }

            if (this.IsPostBack)
            {
                p_superanMonto_messageServer.Visible = false;
                p_listarEnvios_noSeEncontro.Visible = false;
            }
        }

        protected void btn_superanMonto_listar_Click(object sender, EventArgs e)
        {
            decimal monto;
            bool result = decimal.TryParse(txt_superanMonto_monto.Text, out monto);
            
            if (result)
            {
                List<Envio> enviosSolicitados = this.BuscarEnviosSolicitados();
                this.CargarEnviosSolicitados(enviosSolicitados, "Lista de envios cuyo precio supera " + 
                                            txt_superanMonto_monto.Text + " pesos");
            }
            else
            {
                p_superanMonto_messageServer.Visible = true;
                p_superanMonto_messageServer.InnerText = "El monto debe ser un decimal";
            }
        }

        protected List<Envio> BuscarEnviosSolicitados()
        {
            Usuario cliente = ObtenerCliente(txt_superanMonto_usrName);

            // ya hice el TryParse antes de esto
            decimal monto = decimal.Parse(txt_superanMonto_monto.Text);
            List<Envio> enviosQueSuperanMonto = new List<Envio>();

            if (cliente != null)
            {
                  enviosQueSuperanMonto = elSis.EnviosQueSuperanMontoParaCliente(cliente.Documento, monto);
            }
            else
            {
                p_superanMonto_messageServer.Visible = true;
                p_superanMonto_messageServer.InnerText = "El usuario ingresado no existe";
            }

            return enviosQueSuperanMonto;
        }

        private void CargarEnviosSolicitados(List<Envio> pEnviosSolicitados, string pHeader)
        {
            List<Envio> nuevaListaEnvios = new List<Envio>();

            if (pEnviosSolicitados.Count != 0)
            {
                div_grv_envios.Visible = true;

                foreach (Envio env in pEnviosSolicitados)
                {
                    nuevaListaEnvios.Add(env);
                }
            }
            else
            {
                div_grv_envios.Visible = false;
                p_listarEnvios_noSeEncontro.Visible = true;
            }

            p_listarEnvio_headerResult.InnerText = pHeader;
            grid_listarEnvios_env.DataSource = nuevaListaEnvios;
            grid_listarEnvios_env.DataBind();
        }

        protected void btn_listaeEnvTransito5_Click(object sender, EventArgs e)
        {
            List<Envio> listaEnviosEnTransitoAtrasados = new List<Envio>();
            listaEnviosEnTransitoAtrasados = elSis.EnviosEnTransitoAtrasados();

            CargarEnviosSolicitados(listaEnviosEnTransitoAtrasados, "Lista de envios en tránsito por más de cinco dias");

        }


        protected Usuario ObtenerCliente(TextBox pControl_txtbox)
        {
            Usuario cliente = null;

            if ((bool)Session["esCliente"] == true)
            {
                cliente = this.elSis.BuscarUsuarioPorUsername(Session["UsuarioLogueado"].ToString());
            }
            else cliente = this.elSis.BuscarUsuarioPorUsername(pControl_txtbox.Text);

            return cliente;
        }
    }
}