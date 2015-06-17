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
            //if (Session["UsuarioLogueado"].ToString() == "")
            //{
            //    Response.Redirect("~/Inicio.aspx");
            //}
            //else
            //{
            //    if ((bool)Session["esAdmin"] == true)
            //    {
                    div_superanMonto_elegirCliente.Visible = true;
                    div_listarEnvios_enTransito5dias_elegirCli.Visible = true;
            //    }
            //}

            if (this.IsPostBack)
            {
                p_superanMonto_messageServer.Visible = false;
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
            List<EnvioDocumento> nuevaListaEnviosDoc = new List<EnvioDocumento>();
            List<EnvioPaquete> nuevaListaEnviosPaquete = new List<EnvioPaquete>();
            List<Envio> nuevaListaEnvios = new List<Envio>();

            //foreach (Envio env in pEnviosSolicitados)
            //{
            //    if (env.GetType() == typeof(EnvioDocumento))
            //    {
            //        EnvioDocumento envDoc = env as EnvioDocumento;
            //        nuevaListaEnviosDoc.Add(envDoc);
            //    }
            //    else if (env.GetType() == typeof(EnvioPaquete))
            //    {
            //        EnvioPaquete envPaq = env as EnvioPaquete;
            //        nuevaListaEnviosPaquete.Add(envPaq);
            //    }
            //}

            foreach (Envio env in pEnviosSolicitados)
            {
                nuevaListaEnvios.Add(env);
            }

            if (nuevaListaEnvios.Count != 0)
            {
                div_grv_envDocumento.Visible = true;
            }
            else div_grv_envDocumento.Visible = false;

            //if (nuevaListaEnviosDoc.Count != 0)
            //{
            //    div_grv_envDocumento.Visible = true;
            //}
            //else div_grv_envDocumento.Visible = false;

            //if (nuevaListaEnviosPaquete.Count != 0)
            //{
            //    div_grv_envPaquete.Visible = true;
            //}
            //else div_grv_envPaquete.Visible = false;

            p_listarEnvio_headerResult.InnerText = pHeader;
            grid_superanMonto_enviosDoc.DataSource = nuevaListaEnvios;
            grid_superanMonto_enviosDoc.DataBind();

            //grid_superanMonto_enviosPaquete.DataSource = nuevaListaEnviosPaquete;
            //grid_superanMonto_enviosPaquete.DataBind();


        }

        protected void btn_listaeEnvTransito5_Click(object sender, EventArgs e)
        {
            Usuario cliente = ObtenerCliente(txt_listarEnvios_enTransito5_username);
            
            List<Envio> listaEnviosEnTransitoAtrasados = new List<Envio>();
            listaEnviosEnTransitoAtrasados = cliente.EnviosEnTransitoAtrasados();

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