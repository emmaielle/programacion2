using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Dominio.Utilidades;

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
                this.lbl_superanMonto_messageServer.Text = "";
                this.p_listarEnvios_noSeEncontro.Visible = false;
            }
        }

        #region botones_click

        protected void btn_superanMonto_listar_Click(object sender, EventArgs e)
        {
            decimal monto;
            bool result = decimal.TryParse(this.txt_superanMonto_monto.Text, out monto);

            if (result)
            {
                bool existeCliente;
                List<Envio> enviosSolicitados = this.BuscarEnviosQueSuperanMonto(out existeCliente);
                this.CargarEnviosSolicitados(enviosSolicitados, "Lista de envíos cuyo precio supera " +
                                            this.txt_superanMonto_monto.Text + " pesos", existeCliente);
            }
            else
            {
                this.lbl_superanMonto_messageServer.Text = "El monto debe ser un decimal";
            }
        }


        protected void btn_listarEnvios_paraEntregar_listar_Click(object sender, EventArgs e)
        {
            List<Envio> listaEnviosParaEntregar = new List<Envio>();

            bool existeElCliente;
            listaEnviosParaEntregar = this.BuscarEnviosParaEntregar(out existeElCliente);

            this.CargarEnviosSolicitados(listaEnviosParaEntregar, "Lista de envíos para entregar o entregados, ordenados por decha de ingreso a estado 'ParaEntregar' de forma ASCENDENTE", existeElCliente);
        }


        protected void btn_listaeEnvTransito5_Click(object sender, EventArgs e)
        {
            List<Envio> listaEnviosEnTransitoAtrasados = new List<Envio>();
            listaEnviosEnTransitoAtrasados = elSis.EnviosEnTransitoAtrasados();

            this.CargarEnviosSolicitados(listaEnviosEnTransitoAtrasados, "Lista de envíos en tránsito por más de cinco días", true);

        }

        #endregion

        protected List<Envio> BuscarEnviosQueSuperanMonto(out bool pExisteElCliente)
        {
            // que el textbox este llenado solo con números ya esta controlado en ObtenerCliente()
            Usuario cliente = this.ObtenerCliente(this.txt_superanMonto_usrName, lbl_superanMonto_messageServer);

            // ya hice el TryParse antes de esto
            decimal monto = decimal.Parse(this.txt_superanMonto_monto.Text);
            
            List<Envio> enviosQueSuperanMonto = new List<Envio>();

            if (cliente != null)
            {
                enviosQueSuperanMonto = elSis.EnviosQueSuperanMontoParaCliente(cliente.Documento, monto);
                pExisteElCliente = true;
            }
            else
            {
                pExisteElCliente = false;
                this.lbl_superanMonto_messageServer.Text = "El cliente ingresado no existe";
            }

            return enviosQueSuperanMonto;
        }

        protected List<Envio> BuscarEnviosParaEntregar(out bool pExisteElCliente)
        {
            // que el textbox este llenado solo con números ya esta controlado en ObtenerCliente()
            Usuario cliente = this.ObtenerCliente(this.txt_listarEnv_paraEntregar_usrName, lbl_paraEntregar_messageServer);

            List<Envio> listaEnviosParaEntregaroEntregados = new List<Envio>();

            if (cliente != null)
            {
                listaEnviosParaEntregaroEntregados = elSis.ListarEnviosEntregados(cliente.Documento);
                pExisteElCliente = true;
            }
            else
            {
                this.lbl_paraEntregar_messageServer.Text = "El cliente ingresado no existe";
                pExisteElCliente = false;
            }

            return listaEnviosParaEntregaroEntregados;
        }

        // le paso un parametro para saber si existe el cliente, porque si no existe, el problema no es
        // que no hay envios para ese cliente
        protected void CargarEnviosSolicitados(List<Envio> pEnviosSolicitados, string pHeader, bool pExisteCli)
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
                
                if (pExisteCli)
                {
                    this.p_listarEnvios_noSeEncontro.Visible = true;
                }
            }

            this.p_listarEnvio_headerResult.InnerText = pHeader;
            this.grid_listarEnvios_env.DataSource = nuevaListaEnvios;
            this.grid_listarEnvios_env.DataBind();
        }


        // este metodo es comun para dos consultas; muestro mensajes aca, pasando el parametro de donde lo 
        // voy a mostrar
        protected Usuario ObtenerCliente(TextBox pControl_txtbox, Label pControlMensaje)
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
                    if (Utilidades.ChequearEsSoloNumero(pControl_txtbox.Text))
                    {
                        cliente = this.elSis.BuscarCliente(pControl_txtbox.Text);
                    }
                    else pControlMensaje.Text = "El documento debe contener sólo números";
                }
                else pControlMensaje.Text = "Debes ingresar un documento de cliente";

            }
            return cliente;
        }
    }
}