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
                div_actualizarEnv_messageDiv.Visible = false;
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

            Envio envioDeseado = null;

            if (resultNroEnvio)
            {
                envioDeseado = elSis.BuscarEnvio(nroEnvio);
            }
            else 
            {   
                div_actualizarEnv_messageDiv.Visible = true;
                p_actualizarEnv_messageServer.InnerText = "El número de envío ingresado no existe";
            }

            bool exito = false;

            if (envioDeseado != null)
            {
                if (resultOfi)
                {
                    if (resultEtapa)
                    {
                       exito = envioDeseado.AgregarEtapa(fechaIngreso, etapaIngresada, oficinaEntrante, nombreRecibio);
                    }
                    else
                    {
                        div_actualizarEnv_messageDiv.Visible = true;
                        p_actualizarEnv_messageServer.InnerText = "error2";
                    }
                }
                else
                {
                    div_actualizarEnv_messageDiv.Visible = true;
                    p_actualizarEnv_messageServer.InnerText = "error3";
                }
            }
            else
            {
                div_actualizarEnv_messageDiv.Visible = true;
                p_actualizarEnv_messageServer.InnerText = "error3";
            }

            if (exito)
            {
                div_actualizarEnv_messageDiv.Visible = true;
                p_actualizarEnv_messageServer.InnerText = "exito!!";
            }
            else
            {
                div_actualizarEnv_messageDiv.Visible = true;
                p_actualizarEnv_messageServer.InnerText = "El nombre de destinatario no coincide con el nombre de quien lo recibe";
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
                }
                else
                {
                    div_actualizarEnv_nomRecibio.Visible = false;
                }
            }

            else
            {
                div_actualizarEnv_messageDiv.Visible = true;
                p_actualizarEnv_messageServer.InnerText = "error";
            }

        }
    }
}