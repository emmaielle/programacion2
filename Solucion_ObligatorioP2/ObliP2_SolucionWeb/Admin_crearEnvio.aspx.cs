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
    public partial class Admin_crearEnvio : System.Web.UI.Page
    {
        Sistema elSis = Sistema.Instancia;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["esAdmin"] == false)
            {
                Response.Redirect("~/Inicio.aspx");
            }

            if (!this.IsPostBack)
            {
                this.ddl_crearEnvio_nroOficina.DataSource = elSis.TraerNrosDeOficinasPostales();
                this.ddl_crearEnvio_nroOficina.DataBind();
            }
            else this.p_crearEnvio_errores.InnerText = "";
        }

        protected void btn_crearEnvio_crearEnvio_Click(object sender, EventArgs e)
        {
            string idCliente = this.txt_crearEnvio_idCliente.Text;
            string nombre = this.txt_crearEnvio_nomDest.Text;
            string calle = this.txt_crearEnvio_calle.Text;
            string nroPuerta = this.txt_crearEnvio_numPuerta.Text;
            string pais = this.txt_crearEnvio_pais.Text;
            string ciudad = this.txt_crearEnvio_ciudad.Text;
            string codPostal = this.txt_crearEnvio_codPostal.Text;
            bool tieneSeguro = this.chkbox_crearEnvio_seguro.Checked;
            bool esDocLegal = this.chkbox_crearEnvio_esDocLegal.Checked;
            string nombreDestinatario = this.txt_crearEnvio_nomDest.Text;
            DateTime fechaIngreso = this.calendar_crearEnvio.SelectedDate;
            string descrip = this.txt_crearEnvio_DescripPaquete.Text;
            string calleOrigen = this.txt_crearEnvio_calleOrigen.Text;
            string nroPuertaOrigen = this.txt_crearEnvio_nroOrigen.Text;
            string paisOrigen = this.txt_crearEnvio_paisOrigen.Text;
            string ciudadOrigen = this.txt_crearEnvio_ciudadOrigen.Text;
            string codPostalOrigen = this.txt_crearEnvio_codPostalOrigen.Text;
            int numeroEnvio;

            string pesoEnv = this.txt_crearEnvio_peso.Text;
            float peso;
            bool resultadoPeso = float.TryParse(pesoEnv, out peso);

            int nroOficina;
            bool resultOfi = Int32.TryParse(this.ddl_crearEnvio_nroOficina.SelectedValue, out nroOficina);

            string largoEnv = this.txt_crearEnvio_largoPaquete.Text;
            float largo;
            bool resultLargo = float.TryParse(largoEnv, out largo);

            string anchoEnv = this.txt_crearEnvio_anchoPaquete.Text;
            float ancho;
            bool resultAncho = float.TryParse(anchoEnv, out ancho);

            string altoEnv = this.txt_crearEnvio_altoPaquete.Text;
            float alto;
            bool resultAlto = float.TryParse(altoEnv, out alto);

            string valorDecEnv = this.txt_crearEnvio_valorDeclaradoPaquete.Text;
            decimal valorDec;
            bool resultadoValorDec = decimal.TryParse(valorDecEnv, out valorDec);

            //chequeos comunes
            if (!String.IsNullOrEmpty(pesoEnv))
            {
                if (resultadoPeso)
                {
                    if (!String.IsNullOrEmpty(idCliente))
                    {
                        if (!String.IsNullOrEmpty(nombre))
                        {
                            if (!String.IsNullOrEmpty(calle))
                            {
                                if (!String.IsNullOrEmpty(nroPuerta))
                                {
                                    if (Utilidades.ChequearEsSoloNumero(nroPuerta))
                                    {
                                        if (!String.IsNullOrEmpty(pais))
                                        {
                                            if (!String.IsNullOrEmpty(ciudad))
                                            {
                                                if (!String.IsNullOrEmpty(codPostal))
                                                {
                                                    if (!String.IsNullOrEmpty(nombreDestinatario))
                                                    {
                                                        if (fechaIngreso != DateTime.MinValue)
                                                        {
                                                            //chequeos de paquete
                                                            if (this.radiobtn_crearEnvio_esPaquete.Checked == true)
                                                            {
                                                                if (!String.IsNullOrEmpty(largoEnv))
                                                                {
                                                                    if (resultLargo)
                                                                    {
                                                                        if (!String.IsNullOrEmpty(anchoEnv))
                                                                        {
                                                                            if (resultAncho)
                                                                            {
                                                                                if (!String.IsNullOrEmpty(altoEnv))
                                                                                {
                                                                                    if (!String.IsNullOrEmpty(descrip))
                                                                                    {
                                                                                        if (resultAlto)
                                                                                        {
                                                                                            if (!String.IsNullOrEmpty(valorDecEnv))
                                                                                            {
                                                                                                if (resultadoValorDec)
                                                                                                {
                                                                                                    numeroEnvio = elSis.AltaEnvioPaquete(idCliente, nombreDestinatario, calle, nroPuerta, codPostal, ciudad, pais, fechaIngreso,
                                                                                                     nroOficina, alto, ancho, largo, valorDec, tieneSeguro, peso, descrip);
                                                                                                    this.lbl_crearEnvio_muestraNroEnvio.Text = "El número de su envío es: #" + numeroEnvio.ToString();
                                                                                                }
                                                                                                else this.p_crearEnvio_errores.InnerText = "El valor declarado especificado no es un número";
                                                                                            }
                                                                                            else this.p_crearEnvio_errores.InnerText = "Debe especificar el valor declarado del paquete";
                                                                                        }
                                                                                        else this.p_crearEnvio_errores.InnerText = "El alto especificado no es un número";
                                                                                    }
                                                                                    else this.p_crearEnvio_errores.InnerText = "Debe especificar una descripción del paquete";
                                                                                }
                                                                                else this.p_crearEnvio_errores.InnerText = "Debe especificar el alto del paquete";
                                                                            }
                                                                            else this.p_crearEnvio_errores.InnerText = "El ancho especificado no es un numero";
                                                                        }
                                                                        else this.p_crearEnvio_errores.InnerText = "Debe especificar el ancho del paquete";
                                                                    }
                                                                    else this.p_crearEnvio_errores.InnerText = "El largo especificado no es un número";
                                                                }
                                                                else this.p_crearEnvio_errores.InnerText = "Debe especificar el largo del paquete";
                                                            }
                                                            //chequeos de documento
                                                            else if (this.radiobtn_crearEnvio_esDoc.Checked == true)
                                                            {
                                                                if (!String.IsNullOrEmpty(calleOrigen))
                                                                {
                                                                    if (!String.IsNullOrEmpty(nroPuertaOrigen))
                                                                    {
                                                                        if (Utilidades.ChequearEsSoloNumero(nroPuertaOrigen))
                                                                        {
                                                                            if (!String.IsNullOrEmpty(paisOrigen))
                                                                            {
                                                                                if (!String.IsNullOrEmpty(ciudadOrigen))
                                                                                {
                                                                                    if (!String.IsNullOrEmpty(codPostalOrigen))
                                                                                    {
                                                                                        numeroEnvio = elSis.AltaEnvioDocumento(idCliente, calleOrigen, nroPuertaOrigen, codPostalOrigen, ciudadOrigen, paisOrigen,
                                                                                        nombreDestinatario, calle, nroPuerta, codPostal, ciudad, pais, fechaIngreso, nroOficina,
                                                                                        peso, esDocLegal);
                                                                                        this.lbl_crearEnvio_muestraNroEnvio.Text = "El número de su envío es: #" + numeroEnvio.ToString();
                                                                                    }
                                                                                    else this.p_crearEnvio_errores.InnerText = "Debe especificar el codigo postal de origen";
                                                                                }
                                                                                else this.p_crearEnvio_errores.InnerText = "Debe especificar la ciudad de origen";
                                                                            }
                                                                            else this.p_crearEnvio_errores.InnerText = "Debe especificar el pais de origen";
                                                                        }
                                                                        else this.p_crearEnvio_errores.InnerText = "El nro de puerta especificado no es un numero";
                                                                    }
                                                                    else this.p_crearEnvio_errores.InnerText = "Debe especificar el nro de puerta de origen";
                                                                }
                                                                else this.p_crearEnvio_errores.InnerText = "Debe especificar la calle de origen";
                                                            }
                                                            else this.p_crearEnvio_errores.InnerText = "Debe elegir un tipo de envio";

                                                            // fin chequeos documento
                                                        }
                                                        else this.p_crearEnvio_errores.InnerText = "Debe especificar una fecha de ingreso";
                                                    }
                                                    else this.p_crearEnvio_errores.InnerText = "Debe ingresar el nombre del destinatario";
                                                }
                                                else this.p_crearEnvio_errores.InnerText = "Debe ingresar el código postal de destino";
                                            }
                                            else this.p_crearEnvio_errores.InnerText = "Debe ingresar la ciudad de destino";
                                        }
                                        else this.p_crearEnvio_errores.InnerText = "Debe ingresar el país de destino";
                                    }
                                    else this.p_crearEnvio_errores.InnerText = "El nro de puerta especificado no es un numero";
                                }
                                else this.p_crearEnvio_errores.InnerText = "Debe ingresar el nro de puerta de destino";
                            }
                            else this.p_crearEnvio_errores.InnerText = "Debe ingresar la calle de destino";
                        }
                        else this.p_crearEnvio_errores.InnerText = "Debe ingresar el nombre del destinatario";
                    }
                    else this.p_crearEnvio_errores.InnerText = "Debe ingresar un Id de cliente";
                }
                else this.p_crearEnvio_errores.InnerText = "El peso debe ser un número";
            }
            else this.p_crearEnvio_errores.InnerText = "Debe ingresar el peso del envio";
        }

        protected void radiobtn_crearEnvio_esPaqueteODocCheckedChanged(object sender, EventArgs e)
        {
            if (this.radiobtn_crearEnvio_esDoc.Checked)
            {
                this.PanelDocumento.Visible = true;
                this.PanelPaquete.Visible = false;
            }

            if (this.radiobtn_crearEnvio_esPaquete.Checked)
            {
                this.PanelPaquete.Visible = true;
                this.PanelDocumento.Visible = false;
            }


        }

    }
}

