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
            if (pesoEnv == null || pesoEnv == "")
            {
                p_crearEnvio_errores.InnerText = "Debe ingresar el peso del envío";
            }

            float peso;
            bool resultado = float.TryParse(pesoEnv, out peso);
            if (!resultado)
            {
                p_crearEnvio_errores.InnerText = "El peso debe ser un número";
            }

            string idCliente = this.txt_crearEnvio_idCliente.Text;
            if (idCliente == null || idCliente == "")
            {
                p_crearEnvio_errores.InnerText = "Debe ingresar un Id de cliente";
            }
            string nombre = this.txt_crearEnvio_nomDest.Text;
            if (nombre == null || nombre == "")
            {
                p_crearEnvio_errores.InnerText = "Debe ingresar el nombre del cliente";
            }
            string calle = this.txt_crearEnvio_calle.Text;
            if (calle == null || calle == "")
            {
                p_crearEnvio_errores.InnerText = "Debe ingresar la calle de destino";
            }
            string nroPuerta = this.txt_crearEnvio_numPuerta.Text;
            if (nroPuerta == null || nroPuerta == "")
            {
                p_crearEnvio_errores.InnerText = "Debe ingresar el nro de puerta de destino";

            }
            if (!Utilidades.ChequearEsSoloNumero(nroPuerta))
            {
                p_crearEnvio_errores.InnerText = "El nro de puerta especificado no es un numero";
            }


            string pais = this.txt_crearEnvio_pais.Text;
            if (pais == null || pais == "")
            {
                p_crearEnvio_errores.InnerText = "Debe ingresar el país de destino";
            }
            string ciudad = this.txt_crearEnvio_ciudad.Text;
            if (ciudad == null || ciudad == "")
            {
                p_crearEnvio_errores.InnerText = "Debe ingresar la ciudad de destino";
            }
            string codPostal = this.txt_crearEnvio_codPostal.Text;
            if (codPostal == null || codPostal == "")
            {
                p_crearEnvio_errores.InnerText = "Debe ingresar el código postal de destino";
            }

            bool tieneSeguro;
            bool esDocLegal;

            //string calleOrigen = this.txt_crearEnvio_calleOrigen.Text;
            //if (calleOrigen == null || calleOrigen == "")
            //{
            //    throw new Exception("Calle Origen vacio");
            //}
            //string nroPuertaOrigen = this.txt_crearEnvio_nroOrigen.Text;
            //if (nroPuertaOrigen == null || nroPuertaOrigen == "")
            //{
            //    throw new Exception("Nro puerta Origen vacio");
            //}
            //string paisOrigen = this.txt_crearEnvio_paisOrigen.Text;
            //if (paisOrigen == null || paisOrigen == "")
            //{
            //    throw new Exception("Pais Origen vacio");
            //}
            //string ciudadOrigen = this.txt_crearEnvio_ciudadOrigen.Text;
            //if (ciudadOrigen == null || ciudadOrigen == "")
            //{
            //    throw new Exception("Ciudad Origen vacio");
            //}

            //string codPostalOrigen = this.txt_crearEnvio_codPostalOrigen.Text; ;
            //if (codPostalOrigen == null || codPostalOrigen == "")
            //{
            //    throw new Exception("Cod Postal Origen vacio");
            //}

            string nombreDestinatario = this.txt_crearEnvio_nomDest.Text;
            if (nombreDestinatario == null || nombreDestinatario == "")
            {
                p_crearEnvio_errores.InnerText = "Debe ingresar el nombre del destinatario";
            }

            DateTime fechaIngreso = this.calendar_crearEnvio.SelectedDate;
            if (fechaIngreso == null)
            {
                p_crearEnvio_errores.InnerText = "Debe especificar una fecha de ingreso";
            }

            if (this.ddl_crearEnvio_nroOficina.SelectedValue == null)
            {
                //
            }
            int nroOficina;
            bool resultOfi = Int32.TryParse(this.ddl_crearEnvio_nroOficina.SelectedValue, out nroOficina);

            int numeroEnvio;

            if (this.radiobtn_crearEnvio_esPaquete.Checked == true)
            {
                string largoEnv = this.txt_crearEnvio_largoPaquete.Text;
                if (largoEnv == null || largoEnv == "")
                {
                    p_crearEnvio_errores.InnerText = "Debe especificar el largo del paquete";
                }
                float largo;
                bool resultLargo = float.TryParse(largoEnv, out largo);
                if (resultLargo == false)
                {
                    p_crearEnvio_errores.InnerText = "El largo especificado no es un número";
                }

                string anchoEnv = this.txt_crearEnvio_anchoPaquete.Text;
                if (anchoEnv == null || anchoEnv == "")
                {
                    p_crearEnvio_errores.InnerText = "Debe especificar el ancho del paquete";
                }
                float ancho;
                bool resultAncho = float.TryParse(anchoEnv, out ancho);
                if (!resultAncho)
                {
                    p_crearEnvio_errores.InnerText = "El ancho especificado no es un numero";
                }

                string altoEnv = this.txt_crearEnvio_altoPaquete.Text;
                if (altoEnv == null || altoEnv == "")
                {
                    p_crearEnvio_errores.InnerText = "Debe especificar el alto del paquete";
                }
                float alto;
                bool resultAlto = float.TryParse(altoEnv, out alto);
                if (!resultAlto)
                {
                    p_crearEnvio_errores.InnerText = "El alto especificado no es un número";
                }


                string descrip = this.txt_crearEnvio_DescripPaquete.Text;
                if (descrip == null || descrip == "")
                {
                    p_crearEnvio_errores.InnerText = "Debe especificar una descripción del paquete";
                }

                tieneSeguro = this.chkbox_crearEnvio_seguro.Checked;

                string costoBaseXgramoEnv = this.txt_crearEnvio_costoBase.Text;
                if (costoBaseXgramoEnv == null || costoBaseXgramoEnv == "")
                {
                    p_crearEnvio_errores.InnerText = "Costo vacio";
                }
                decimal costoBaseXgramo;
                bool resultadoCosto = decimal.TryParse(costoBaseXgramoEnv, out costoBaseXgramo);

                string valorDecEnv = this.txt_crearEnvio_valorDeclaradoPaquete.Text;
                if (valorDecEnv == null || valorDecEnv == "")
                {
                    p_crearEnvio_errores.InnerText = "Debe especificar el valor declarado del paquete";
                }
                decimal valorDec;
                bool resultadoValorDec = decimal.TryParse(valorDecEnv, out valorDec);
                if (!resultadoValorDec)
                {
                    p_crearEnvio_errores.InnerText = "El valor declarado especificado no es un numero";
                }

                numeroEnvio = elSis.AltaEnvioPaquete(idCliente, nombreDestinatario, calle, nroPuerta, codPostal, ciudad, pais, fechaIngreso,
                                nroOficina, alto, ancho, largo, costoBaseXgramo, valorDec, tieneSeguro, peso, descrip);

                this.lbl_crearEnvio_muestraNroEnvio.Text = "El número de su envío es: #" + numeroEnvio.ToString();

            }

            if (this.radiobtn_crearEnvio_esDoc.Checked == true)
            {
                esDocLegal = this.chkbox_crearEnvio_esDocLegal.Checked;
                string calleOrigen = this.txt_crearEnvio_calleOrigen.Text;
                
                if (calleOrigen == null || calleOrigen == "")
                {
                    p_crearEnvio_errores.InnerText = "Debe especificar la calle de origen";
                }
                
                string nroPuertaOrigen = this.txt_crearEnvio_nroOrigen.Text;
                
                if (nroPuertaOrigen == null || nroPuertaOrigen == "")
                
                {
                    p_crearEnvio_errores.InnerText = "Debe especificar el nro de puerta de origen";
                }

                if (!Utilidades.ChequearEsSoloNumero(nroPuertaOrigen))
                {
                    p_crearEnvio_errores.InnerText = "El nro de puerta especificado no es un numero";
                }
                
                string paisOrigen = this.txt_crearEnvio_paisOrigen.Text;
                
                if (paisOrigen == null || paisOrigen == "")
                {
                    p_crearEnvio_errores.InnerText = "Debe espeficar el pais de origen";
                }

                string ciudadOrigen = this.txt_crearEnvio_ciudadOrigen.Text;

                if (ciudadOrigen == null || ciudadOrigen == "")
                {
                    p_crearEnvio_errores.InnerText = "Debe especificar la ciudad de origen";
                }

                string codPostalOrigen = this.txt_crearEnvio_codPostalOrigen.Text;

                if (codPostalOrigen == null || codPostalOrigen == "")
                {
                    p_crearEnvio_errores.InnerText = "Debe especificar el codigo postal de origen";
                }

                numeroEnvio = elSis.AltaEnvioDocumento(idCliente, calleOrigen, nroPuertaOrigen, codPostalOrigen, ciudadOrigen, paisOrigen,
                                      nombreDestinatario, calle, nroPuerta, codPostal, ciudad, pais, fechaIngreso, nroOficina,
                                      peso, esDocLegal);
                this.lbl_crearEnvio_muestraNroEnvio.Text = numeroEnvio.ToString();
            }

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

