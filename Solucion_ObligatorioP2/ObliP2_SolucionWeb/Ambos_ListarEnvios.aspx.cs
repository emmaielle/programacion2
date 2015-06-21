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
                    this.div_superanMonto_elegirCliente.Visible = true;
                    this.div_listarEnvios_SoloAdmin_transito5d.Visible = true;
                    this.div_listarEnvios_paraEntregar_elegirCliente.Visible = true;
                }
                else if ((bool)Session["esCliente"] == true)
                {
                    this.div_superanMonto_contenedora.Style.Add("width", "541px");
                    this.div_listarEnvios_Ambos_envParaEntregar.Style.Add("float", "right");
                }
            }

            if (this.IsPostBack)
            {
                this.p_superanMonto_messageServer.InnerText = "";
                this.p_listarEnvios_noSeEncontro.Visible = false;
            }
        }

        protected void btn_superanMonto_listar_Click(object sender, EventArgs e)
        {
            decimal monto;
            bool result = decimal.TryParse(this.txt_superanMonto_monto.Text, out monto);

            if (result)
            {
                List<Envio> enviosSolicitados = this.BuscarEnviosQueSuperanMonto();
                this.CargarEnviosSolicitados(enviosSolicitados, "Lista de envíos cuyo precio supera " +
                                            this.txt_superanMonto_monto.Text + " pesos");
            }
            else
            {
                this.p_superanMonto_messageServer.InnerText = "El monto debe ser un decimal";
            }
        }

        protected void btn_listarEnvios_paraEntregar_listar_Click(object sender, EventArgs e)
        {
            List<Envio> listaEnviosParaEntregar = new List<Envio>();
            listaEnviosParaEntregar = this.BuscarEnviosParaEntregar();

            this.CargarEnviosSolicitados(listaEnviosParaEntregar, "Lista de envíos para entregar o entregados, ordenados por decha de ingreso a estado 'ParaEntregar' de forma ASCENDENTE");
        }

        protected void btn_listaeEnvTransito5_Click(object sender, EventArgs e)
        {
            List<Envio> listaEnviosEnTransitoAtrasados = new List<Envio>();
            listaEnviosEnTransitoAtrasados = elSis.EnviosEnTransitoAtrasados();

            this.CargarEnviosSolicitados(listaEnviosEnTransitoAtrasados, "Lista de envíos en tránsito por más de cinco días");

        }

        protected List<Envio> BuscarEnviosQueSuperanMonto()
        {
            Usuario cliente = this.ObtenerCliente(this.txt_superanMonto_usrName);

            // ya hice el TryParse antes de esto
            decimal monto = decimal.Parse(this.txt_superanMonto_monto.Text);
            List<Envio> enviosQueSuperanMonto = new List<Envio>();

            if (cliente != null)
            {
                enviosQueSuperanMonto = elSis.EnviosQueSuperanMontoParaCliente(cliente.Documento, monto);
            }
            else
            {
                this.p_superanMonto_messageServer.InnerText = "El usuario ingresado no existe";
            }

            return enviosQueSuperanMonto;
        }

        protected List<Envio> BuscarEnviosParaEntregar()
        {
            Usuario cliente = this.ObtenerCliente(this.txt_listarEnv_paraEntregar_usrName);

            List<Envio> listaEnviosParaEntregaroEntregados = new List<Envio>();

            if (cliente != null)
            {
                listaEnviosParaEntregaroEntregados = cliente.ListarEnviosEntregados();
            }

            return listaEnviosParaEntregaroEntregados;
        }

        protected void CargarEnviosSolicitados(List<Envio> pEnviosSolicitados, string pHeader)
        {
            List<Envio> nuevaListaEnvios = new List<Envio>();

            if (pEnviosSolicitados.Count != 0 && pEnviosSolicitados != null)
            {
                this.div_grv_envios.Visible = true;

                foreach (Envio env in pEnviosSolicitados)
                {
                    nuevaListaEnvios.Add(env);
                }
            }
            else
            {
                this.div_grv_envios.Visible = false;
                this.p_listarEnvios_noSeEncontro.Visible = true;
            }

            this.p_listarEnvio_headerResult.InnerText = pHeader;
            this.grid_listarEnvios_env.DataSource = nuevaListaEnvios;
            this.grid_listarEnvios_env.DataBind();
        }

        protected Usuario ObtenerCliente(TextBox pControl_txtbox)
        {
            Usuario cliente = null;

            if ((bool)Session["esCliente"] == true)
            {
                cliente = this.elSis.BuscarCliente(Session["UsuarioLogueado"].ToString());
            }
            else
            {
                if (!string.IsNullOrEmpty(pControl_txtbox.Text))
                {
                    cliente = this.elSis.BuscarCliente(pControl_txtbox.Text);
                }

            }
            return cliente;
        }
    }
}