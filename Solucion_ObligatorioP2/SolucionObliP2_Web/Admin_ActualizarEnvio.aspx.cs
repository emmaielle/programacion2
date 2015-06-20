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
            if (!this.IsPostBack)
            {
                ddl_actualizarEnv_Oficinas.DataSource = elSis.TraerNrosDeOficinasPostales();
                ddl_actualizarEnv_Oficinas.DataBind();

                ddl_actualizarEnv_etapaEnv.DataSource = Enum.GetNames(EtapaEnvio.Etapas.EnOrigen.GetType());
                ddl_actualizarEnv_etapaEnv.DataBind();
            }
            else
            {
                p_actualizarEnv_messageServer.Visible = false;
                p_actualizarEnv_messageServer.InnerText = "";

            }

        }

        protected void btn_actualizarEnv_AgregarEtapa_Click(object sender, EventArgs e)
        {
            int nroEnvio;
            bool resultNroEnvio = int.TryParse(txt_actualizarEnv_nroEnv.Text, out nroEnvio);

            DateTime fechaIngreso = calendar_actualizarEnv_fchIngreso.SelectedDate;
            
            int nroOficina;
            bool resultOfi = int.TryParse(ddl_actualizarEnv_Oficinas.SelectedValue, out nroOficina);
            OficinaPostal oficinaEntrante = elSis.BuscarOficinaXID(nroOficina);

            EtapaEnvio.Etapas etapaIngresada; 
            bool resultEtapa = Enum.TryParse<EtapaEnvio.Etapas>(this.ddl_actualizarEnv_etapaEnv.SelectedValue, out etapaIngresada);

            string nombreRecibio = txt_actualizarEnv_nomRecibio.Text;
            string firmaRecibio = "";
            string path = "";
            string nomArchivo = "";

            if (this.fileup_actualizarEnvio_firma.HasFile)
            {
                firmaRecibio = fileup_actualizarEnvio_firma.FileName;
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
                                string mensajeError = null;
                                exito = envioDeseado.AgregarEtapa(fechaIngreso, etapaIngresada, oficinaEntrante, nomArchivo, nombreRecibio, out mensajeError);
                                this.fileup_actualizarEnvio_firma.SaveAs(path + nomArchivo);

                                if (exito)
                                {
                                    p_actualizarEnv_messageServer.Visible = true;
                                    p_actualizarEnv_messageServer.InnerText = "exito!!";
                                }
                                else
                                {
                                    p_actualizarEnv_messageServer.Visible = true;
                                    p_actualizarEnv_messageServer.InnerText = mensajeError;
                                }
                            }
                            else
                            {
                                p_actualizarEnv_messageServer.Visible = true;
                                p_actualizarEnv_messageServer.InnerText = "Debe seleccionar una etapa para el envio";
                            }
                        }
                        else
                        {
                            p_actualizarEnv_messageServer.Visible = true;
                            p_actualizarEnv_messageServer.InnerText = "Debe seleccionar una oficina postal";
                        }
                    }
                    else
                    {
                        p_actualizarEnv_messageServer.Visible = true;
                        p_actualizarEnv_messageServer.InnerText = "Debe seleccionar una fecha";
                    }
                }
                else
                {
                    p_actualizarEnv_messageServer.Visible = true;
                    p_actualizarEnv_messageServer.InnerText = "El número de envío ingresado no existe";
                }
            }
            else
            {
                p_actualizarEnv_messageServer.Visible = true;
                p_actualizarEnv_messageServer.InnerText = "El número de envío debe tener sólo números";
            }
          
        }

        protected void ddl_actualizarEnv_etapaEnv_SelectedIndexChanged(object sender, EventArgs e)
        {
            EtapaEnvio.Etapas etapaIngresada;
            bool resultEtapa = Enum.TryParse<EtapaEnvio.Etapas>(this.ddl_actualizarEnv_etapaEnv.SelectedValue, out etapaIngresada);

            if (resultEtapa)
            {
                if (etapaIngresada == EtapaEnvio.Etapas.Entregado)
                {
                    div_actualizarEnv_nomRecibio.Visible = true;
                    div_actualizarEnv_firmaRecibio.Visible = true;
                }
                else
                {
                    div_actualizarEnv_nomRecibio.Visible = false;
                    div_actualizarEnv_firmaRecibio.Visible = false;
                }
            }


        }

        protected void txt_actualizarEnv_nroEnv_TextChanged(object sender, EventArgs e)
        {
            div_actualizarEnv_datosEnv.Visible = true;

            int nroEnvio;
            bool resultNroEnvio = int.TryParse(txt_actualizarEnv_nroEnv.Text, out nroEnvio);

            if (resultNroEnvio)
            {
                Envio envShowData = elSis.BuscarEnvio(nroEnvio);
                if (envShowData != null)
                {
                    EtapaEnvio etapaActual = envShowData.ObtenerEtapaActual();

                    lbl_actualizarEnv_shortInfoEnv.Text = "Envío " + envShowData.NroEnvio + ": "
                        + etapaActual.Etapa.ToString() + "; Oficina Nº: " + etapaActual.Ubicacion.NroOficina.ToString();
                }
                else lbl_actualizarEnv_shortInfoEnv.Text = "El envio " + nroEnvio + " no existe";
            }

        }
    }
}