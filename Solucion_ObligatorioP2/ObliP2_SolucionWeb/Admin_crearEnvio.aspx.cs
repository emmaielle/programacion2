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
            else lbl_crearEnvio_muestraNroEnvio.Text = "";
        }

        protected void btn_crearEnvio_crearEnvio_Click(object sender, EventArgs e)
        {
            string pesoEnv = this.txt_crearEnvio_peso.Text;

            float peso;
            bool resultadoPeso = float.TryParse(pesoEnv, out peso);

            string idCliente = this.txt_crearEnvio_idCliente.Text;

            string nombre = this.txt_crearEnvio_nomDest.Text;

            string calle = this.txt_crearEnvio_calle.Text;

            string nroPuerta = this.txt_crearEnvio_numPuerta.Text;

            string pais = this.txt_crearEnvio_pais.Text;

            string ciudad = this.txt_crearEnvio_ciudad.Text;

            string codPostal = this.txt_crearEnvio_codPostal.Text;

            bool tieneSeguro = chkbox_crearEnvio_seguro.Checked;
            bool esDocLegal = chkbox_crearEnvio_esDocLegal.Checked;

            string nombreDestinatario = this.txt_crearEnvio_nomDest.Text;

            DateTime fechaIngreso = this.calendar_crearEnvio.SelectedDate;

            int nroOficina;
            bool resultOfi = Int32.TryParse(this.ddl_crearEnvio_nroOficina.SelectedValue, out nroOficina);

            int numeroEnvio;

            string largoEnv = this.txt_crearEnvio_largoPaquete.Text;

            float largo;
            bool resultLargo = float.TryParse(largoEnv, out largo);

            string anchoEnv = this.txt_crearEnvio_anchoPaquete.Text;

            float ancho;
            bool resultAncho = float.TryParse(anchoEnv, out ancho);

            string altoEnv = this.txt_crearEnvio_altoPaquete.Text;

            float alto;
            bool resultAlto = float.TryParse(altoEnv, out alto);
            string descrip = this.txt_crearEnvio_DescripPaquete.Text;
            string costoBaseXgramoEnv = this.txt_crearEnvio_costoBase.Text;

            decimal costoBaseXgramo;
            bool resultadoCosto = decimal.TryParse(costoBaseXgramoEnv, out costoBaseXgramo);

            string valorDecEnv = this.txt_crearEnvio_valorDeclaradoPaquete.Text;

            decimal valorDec;
            bool resultadoValorDec = decimal.TryParse(valorDecEnv, out valorDec);

            string calleOrigen = this.txt_crearEnvio_calleOrigen.Text;


            string nroPuertaOrigen = this.txt_crearEnvio_nroOrigen.Text;


            string paisOrigen = this.txt_crearEnvio_paisOrigen.Text;


            string ciudadOrigen = this.txt_crearEnvio_ciudadOrigen.Text;

            string codPostalOrigen = this.txt_crearEnvio_codPostalOrigen.Text;





            if (!String.IsNullOrEmpty(pesoEnv))
            {

                if (resultadoPeso)
               
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
                                                                if (this.radiobtn_crearEnvio_esPaquete.Checked == true)
                                                                {

                                                                    if (!String.IsNullOrEmpty(largoEnv))
                                                                    {
                                                                        if (resultLargo == true)
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
                                                                                                if (!String.IsNullOrEmpty(costoBaseXgramoEnv))
                                                                                                {
                                                                                                    if (!String.IsNullOrEmpty(valorDecEnv))
                                                                                                    {
                                                                                                        if (resultadoValorDec)
                                                                                                        {

                                                                                                            numeroEnvio = elSis.AltaEnvioPaquete(idCliente, nombreDestinatario, calle, nroPuerta, codPostal, ciudad, pais, fechaIngreso,
                                                                                                             nroOficina, alto, ancho, largo, costoBaseXgramo, valorDec, tieneSeguro, peso, descrip);
                                                                                                            this.lbl_crearEnvio_muestraNroEnvio.Text = "El número de su envío es: #" + numeroEnvio.ToString();
                                                                                                        }
                                                                                                        else p_crearEnvio_errores.InnerText = "El valor declarado especificado no es un numero";
                                                                                                    }
                                                                                                    else p_crearEnvio_errores.InnerText = "Debe especificar el valor declarado del paquete";
                                                                                                }
                                                                                                else p_crearEnvio_errores.InnerText = "Costo vacio";
                                                                                            }
                                                                                            else p_crearEnvio_errores.InnerText = "El alto especificado no es un número";

                                                                                        }
                                                                                        else p_crearEnvio_errores.InnerText = "Debe especificar una descripción del paquete";
                                                                                    }
                                                                                    else p_crearEnvio_errores.InnerText = "Debe especificar el alto del paquete";
                                                                                }
                                                                                else p_crearEnvio_errores.InnerText = "El ancho especificado no es un numero";
                                                                            }
                                                                            else p_crearEnvio_errores.InnerText = "Debe especificar el ancho del paquete";

                                                                        }
                                                                        else p_crearEnvio_errores.InnerText = "El largo especificado no es un número";
                                                                    }
                                                                    else p_crearEnvio_errores.InnerText = "Debe especificar el largo del paquete";

                                                                }
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
                                                                                            this.lbl_crearEnvio_muestraNroEnvio.Text = numeroEnvio.ToString();
                                                                                        }
                                                                                         else p_crearEnvio_errores.InnerText = "Debe especificar el codigo postal de origen";
                                                                                    }
                                                                                   else p_crearEnvio_errores.InnerText = "Debe especificar la ciudad de origen";
                                                                                }  
                                                                                else p_crearEnvio_errores.InnerText = "Debe especificar el pais de origen";
                                                                            } 
                                                                           
                                                                           else p_crearEnvio_errores.InnerText = "El nro de puerta especificado no es un numero";
                                                                        }
                                                                        else p_crearEnvio_errores.InnerText = "Debe especificar el nro de puerta de origen";
                                                                    }
                                                                    else p_crearEnvio_errores.InnerText = "Debe especificar la calle de origen";
                                                                }
                                                                 else p_crearEnvio_errores.InnerText = "Debe especificar una fecha de ingreso";
                                                            }
                                                             else p_crearEnvio_errores.InnerText = "Debe ingresar el nombre del destinatario";
                                                    }
                                                    else p_crearEnvio_errores.InnerText = "Debe ingresar el código postal de destino";
                                                }
                                                 else p_crearEnvio_errores.InnerText = "Debe ingresar la ciudad de destino"; 
                                            }
                                              else p_crearEnvio_errores.InnerText = "Debe ingresar el país de destino";
                                           
                                        }
                                         else p_crearEnvio_errores.InnerText = "El nro de puerta especificado no es un numero";
                                    }
                                  else p_crearEnvio_errores.InnerText = "Debe ingresar el nro de puerta de destino";
                                }
                                else p_crearEnvio_errores.InnerText = "Debe ingresar la calle de destino";
                            }
                            else p_crearEnvio_errores.InnerText = "Debe ingresar el nombre del cliente";
                        }
                        else p_crearEnvio_errores.InnerText = "Debe ingresar un Id de cliente";
                    } 
                    else p_crearEnvio_errores.InnerText = "El peso debe ser un número";
                    }
                 else p_crearEnvio_errores.InnerText = "Debe ingresar el peso del envio";
                }
    
        


        protected void radiobtn_crearEnvio_esPaqueteODocCheckedChanged(object sender, EventArgs e)
        {
            if (this.radiobtn_crearEnvio_esDoc.Checked)
            {
                PanelDocumento.Visible = true;
                PanelPaquete.Visible = false;
            }

            if (this.radiobtn_crearEnvio_esPaquete.Checked)
            {
                PanelPaquete.Visible = true;
                PanelDocumento.Visible = false;
            }


        }

    }
}

