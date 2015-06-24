using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Solucion_ObligatorioP2
{
    public partial class Admin_ActualizarEnvio : System.Web.UI.Page
    {
        Sistema elSis = Sistema.Instancia;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioLogueado"].ToString() == "")
            {
                Response.Redirect("~/Inicio.aspx");
            }

            if (!this.IsPostBack)
            {
                this.ddl_actualizarEnv_Oficinas.DataSource = elSis.TraerNrosDeOficinasPostales();
                this.ddl_actualizarEnv_Oficinas.DataBind();

                this.ddl_actualizarEnv_etapaEnv.DataSource = Enum.GetNames(EtapaEnvio.Etapas.EnOrigen.GetType());
                this.ddl_actualizarEnv_etapaEnv.DataBind();
            }
            else
            {
                this.p_actualizarEnv_message.InnerText = "";
            }

        }

        protected void btn_actualizarEnv_AgregarEtapa_Click(object sender, EventArgs e)
        {
            int nroEnvio;
            bool resultNroEnvio = int.TryParse(this.txt_actualizarEnv_nroEnv.Text, out nroEnvio);

            DateTime fechaIngreso = this.calendar_actualizarEnv_fchIngreso.SelectedDate;
            
            int nroOficina;
            bool resultOfi = int.TryParse(this.ddl_actualizarEnv_Oficinas.SelectedValue, out nroOficina);
            OficinaPostal oficinaEntrante = elSis.BuscarOficinaXID(nroOficina);

            EtapaEnvio.Etapas etapaIngresada; 
            bool resultEtapa = Enum.TryParse<EtapaEnvio.Etapas>(this.ddl_actualizarEnv_etapaEnv.SelectedValue, out etapaIngresada);

            string nombreRecibio = this.txt_actualizarEnv_nomRecibio.Text;
            string firmaRecibio = "";
            string path = "";
            string nomArchivo = "";

            if (this.fileup_actualizarEnvio_firma.HasFile)
            {
                firmaRecibio = this.fileup_actualizarEnvio_firma.FileName;
                path = HttpRuntime.AppDomainAppPath + "/fotosFirmas/";
                nomArchivo = nroEnvio.ToString() + firmaRecibio.Substring(firmaRecibio.LastIndexOf(".")); 
            }

            Envio envioDeseado = null;

            if (resultNroEnvio)
            {
                envioDeseado = elSis.BuscarEnvio(nroEnvio);
           
                bool exito = false;

                if (envioDeseado != null)
                {
                    if (fechaIngreso.ToString() != "01/01/0001 12:00:00 a.m.")
                    {
                        if (resultOfi) // esto siempre va a dar true porque es de un ddl
                        {
                            if (resultEtapa) // esto siempre va a dar true porque es de un ddl
                            {
                                if ((etapaIngresada == EtapaEnvio.Etapas.Entregado && path != "") || etapaIngresada != EtapaEnvio.Etapas.Entregado)
                                {
                                    this.fileup_actualizarEnvio_firma.SaveAs(path + nomArchivo);
                                    string mensajeError = null;
                                    exito = envioDeseado.AgregarEtapa(fechaIngreso, etapaIngresada, oficinaEntrante, nomArchivo, nombreRecibio, out mensajeError);

                                    if (exito)
                                    {
                                        this.p_actualizarEnv_message.InnerText = "Exito!!";
                                    }
                                    else
                                    {
                                        this.p_actualizarEnv_message.InnerText = mensajeError;
                                    }
                                }
                                else this.p_actualizarEnv_message.InnerText = "Debe ingresar un archivo";
                            }
                            else this.p_actualizarEnv_message.InnerText = "Debe seleccionar una etapa para el envio";
                        }
                        else this.p_actualizarEnv_message.InnerText = "Debe seleccionar una oficina postal";
                    }
                    else this.p_actualizarEnv_message.InnerText = "Debe seleccionar una fecha";
                }
                else this.p_actualizarEnv_message.InnerText = "El número de envío ingresado no existe";
            }
            else this.p_actualizarEnv_message.InnerText = "El número de envío debe tener sólo números";
        }

        protected void ddl_actualizarEnv_etapaEnv_SelectedIndexChanged(object sender, EventArgs e)
        {
            EtapaEnvio.Etapas etapaIngresada;
            bool resultEtapa = Enum.TryParse<EtapaEnvio.Etapas>(this.ddl_actualizarEnv_etapaEnv.SelectedValue, out etapaIngresada);

            if (resultEtapa)
            {
                if (etapaIngresada == EtapaEnvio.Etapas.Entregado)
                {
                    this.div_actualizarEnv_nomRecibio.Visible = true;
                    this.div_actualizarEnv_firmaRecibio.Visible = true;
                }
                else
                {
                    this.div_actualizarEnv_nomRecibio.Visible = false;
                    this.div_actualizarEnv_firmaRecibio.Visible = false;

                }
            }
        }

        protected void txt_actualizarEnv_nroEnv_TextChanged(object sender, EventArgs e)
        {
            this.div_actualizarEnv_datosEnv.Visible = true;

            int nroEnvio;
            bool resultNroEnvio = int.TryParse(this.txt_actualizarEnv_nroEnv.Text, out nroEnvio);

            if (resultNroEnvio)
            {
                Envio envShowData = elSis.BuscarEnvio(nroEnvio);
                if (envShowData != null)
                {
                    EtapaEnvio etapaActual = envShowData.ObtenerEtapaActual();

                    this.lbl_actualizarEnv_shortInfoEnv.Text = "Envío " + envShowData.NroEnvio + ": "
                        + etapaActual.Etapa.ToString() + "; Oficina Nº: " + etapaActual.Ubicacion.NroOficina.ToString();
                }
                else this.lbl_actualizarEnv_shortInfoEnv.Text = "El envio " + nroEnvio + " no existe";
            }

        }
    }
}