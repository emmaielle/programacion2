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
                //if ((bool)Session["esAdmin"] == true)
                //{
                    div_superanMonto_elegirCliente.Visible = true;
                //}
            //}

            if (this.IsPostBack)
            {
                p_superanMonto_messageServer.Visible = false;
            }
        }

        protected void btn_superanMonto_listar_Click(object sender, EventArgs e)
        {
            List <Envio> enviosSolicitados = this.BuscarEnviosSolicitados();
            this.CargarEnviosSolicitados(enviosSolicitados);
        }

        protected List<Envio> BuscarEnviosSolicitados()
        {
            Usuario cliente = null;

            if ((bool)Session["esCliente"] == true)
            {
                cliente = this.elSis.BuscarUsuarioPorUsername(Session["UsuarioLogueado"].ToString());
            }
            else cliente = this.elSis.BuscarUsuarioPorUsername(txt_superanMonto_usrName.Text);

            decimal monto = 0M;
            bool resultMonto = decimal.TryParse(txt_superanMonto_monto.Text, out monto);
            List<Envio> enviosQueSuperanMonto = new List<Envio>();

            if (cliente != null)
            {
                if (resultMonto)
                {
                    enviosQueSuperanMonto = elSis.EnviosQueSuperanMontoParaCliente(cliente.Documento, monto);
                }
                else
                {
                    p_superanMonto_messageServer.Visible = true;
                    p_superanMonto_messageServer.InnerText = "El monto debe ser un decimal";
                }
            }
            else
            {
                p_superanMonto_messageServer.Visible = true;
                p_superanMonto_messageServer.InnerText = "El usuario ingresado no existe";
            }

            return enviosQueSuperanMonto;
        }

        private void CargarEnviosSolicitados(List<Envio> pEnviosSolicitados)
        {
            List<EnvioDocumento> nuevaListaEnviosDoc = new List<EnvioDocumento>();
            List<EnvioPaquete> nuevaListaEnviosPaquete = new List<EnvioPaquete>();

            foreach (Envio env in pEnviosSolicitados)
            {
                if (env.GetType() == typeof(EnvioDocumento))
                {
                    EnvioDocumento envDoc = env as EnvioDocumento;
                    nuevaListaEnviosDoc.Add(envDoc);
                }
                else if (env.GetType() == typeof(EnvioPaquete))
                {
                    EnvioPaquete envPaq = env as EnvioPaquete;
                    nuevaListaEnviosPaquete.Add(envPaq);
                }
            }

            div_superanMonto_gridresult.Visible = true;
            grid_superanMonto_enviosDoc.DataSource = nuevaListaEnviosDoc;
            grid_superanMonto_enviosDoc.DataBind();

            grid_superanMonto_enviosPaquete.DataSource = nuevaListaEnviosPaquete;
            grid_superanMonto_enviosPaquete.DataBind();


        }
    }
}