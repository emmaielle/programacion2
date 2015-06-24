using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Solucion_ObligatorioP2
{
    public partial class Ambos_SimularEnvio : System.Web.UI.Page
    {
        Sistema elSis = Sistema.Instancia;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioLogueado"].ToString() == "")
            {
                Response.Redirect("~/Inicio.aspx");
            }

            if (this.IsPostBack)
            {
                p_simularEnvio_errores.InnerText = "";
            }

            this.lbl_simularEnvio_muestraResultado.Visible = false;
        }

        protected void radiobtn_simularEnvio_esPaqueteODocCheckedChanged(object sender, EventArgs e)
        {
            if (this.radiobtn_simularEnvio_esDoc.Checked)
            {
                this.simular_PanelDocumento.Visible = true;
                this.simular_PanelPaquete.Visible = false;
            }
            if (this.radiobtn_simularEnvio_esPaquete.Checked)
                {
                    this.simular_PanelPaquete.Visible = true;
                    this.simular_PanelDocumento.Visible = false;
                }
        }

        protected void btn_simular_Click(object sender, EventArgs e)
        {
            string pesoPaq = this.txt_simularEnvio_altoPaquete.Text;
            string altoPaq = this.txt_simularEnvio_altoPaquete.Text;
            string anchoPaq = this.txt_simularEnvio_anchoPaquete.Text;
            string largoPaq = this.txt_simularEnvio_largoPaquete.Text;
            string valorDecPaq = this.txt_simularEnvio_valorDeclaradoPaquete.Text;
            bool tieneSeguro = this.chkbox_simularEnvio_seguro.Checked;
            bool esLegal = this.chkbox_simularEnvio_esDocLegal.Checked;

            float peso;
            bool resultPeso = float.TryParse(pesoPaq, out peso);

            float alto;
            bool resultAlto = float.TryParse(altoPaq, out alto);

            float ancho;
            bool resultAncho = float.TryParse(anchoPaq, out ancho);

            float largo;
            bool resultLargo = float.TryParse(largoPaq, out largo);

            decimal valorDeclarado;
            bool resultValor = decimal.TryParse(valorDecPaq, out valorDeclarado);

            if (!String.IsNullOrEmpty(pesoPaq))
            {
                if (resultPeso)
                {
                    if (this.radiobtn_simularEnvio_esPaquete.Checked)
                    {
                        if (!String.IsNullOrEmpty(altoPaq))
                        {
                            if (resultAlto)
                            {
                                if (!String.IsNullOrEmpty(anchoPaq))
                                {
                                    if (resultAncho)
                                    {
                                        if (!String.IsNullOrEmpty(largoPaq))
                                        {
                                            if (resultLargo)
                                            {
                                                if (!String.IsNullOrEmpty(valorDecPaq))
                                                {
                                                    if (resultValor)
                                                    {
                                                        decimal resultadoPaq = elSis.SimularEnvioPaquete(alto, ancho, largo, valorDeclarado, tieneSeguro, peso);
                                                        this.lbl_simularEnvio_muestraResultado.Visible = true;
                                                        lbl_simularEnvio_muestraResultado.Text = "Su envio tiene un valor de: #" + resultadoPaq.ToString();
                                                    }
                                                    else p_simularEnvio_errores.InnerText = "El valor especificado no es un numero";
                                                }
                                                else p_simularEnvio_errores.InnerText = "Debe especificar un valor declarado";
                                            }
                                            else p_simularEnvio_errores.InnerText = "El largo especificado no es un numero";
                                        }
                                        else p_simularEnvio_errores.InnerText = "Debe especificar el largo del paquete";
                                    }
                                    else p_simularEnvio_errores.InnerText = "El ancho especificado no es un numero";
                                }
                                else p_simularEnvio_errores.InnerText = "debe especificar el ancho del paquete";
                            }
                            else p_simularEnvio_errores.InnerText = "El alto especificado no es un numero";
                        }
                        else p_simularEnvio_errores.InnerText = "Debe especificar el alto del paquete";
                    }
                    else if (radiobtn_simularEnvio_esDoc.Checked)
                    {
                        decimal resultadoDoc = elSis.SimularEnvioDocumento(peso, esLegal);
                        this.lbl_simularEnvio_muestraResultado.Visible = true;
                        lbl_simularEnvio_muestraResultado.Text = "Su envio tiene un valor de: #" + resultadoDoc.ToString();
                    }
                }
                else p_simularEnvio_errores.InnerText = "El peso especificado no es un numero";
            }
            else p_simularEnvio_errores.InnerText = "Debe especificar el peso del envio";
        }
    }
}