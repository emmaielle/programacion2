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
                this.ddl_crearEnvio_etapa.DataSource = Enum.GetNames(EtapaEnvio.Etapas.EnOrigen.GetType());
                this.ddl_crearEnvio_etapa.DataBind();
                this.ddl_crearEnvio_etapa.Enabled = false;
            }
        }

        protected void btn_crearEnvio_crearEnvio_Click(object sender, EventArgs e)
        {
            string pesoEnv = this.txt_crearEnvio_peso.Text;
            if (pesoEnv == null || pesoEnv == "")
            {
                throw new Exception("Peso vacio");
            }

            float peso;
            bool resultado = float.TryParse(pesoEnv, out peso);
            if (!resultado)
            {
                throw new Exception("No pude convertir");
            }

            string idCliente = this.txt_crearEnvio_idCliente.Text;
            if (idCliente == null || idCliente == "")
            {
                throw new Exception("Cliente vacio");
            }
            string nombre = this.txt_crearEnvio_nomDest.Text;
            if (nombre == null || nombre == "")
            {
                throw new Exception("Nombre vacio");
            }
            string calle = this.txt_crearEnvio_calle.Text;
            if (calle == null || calle == "")
            {
                throw new Exception("Calle vacio");
            }
            string nroPuerta = this.txt_crearEnvio_numPuerta.Text;
            if (nroPuerta == null || nroPuerta == "")
            {
                throw new Exception("nroPuerta vacio");

            }
            if (!Utilidades.ChequearEsSoloNumero(nroPuerta))
            {
                throw new Exception("No Pude convertir");
            }


            string pais = this.txt_crearEnvio_pais.Text;
            if (pais == null || pais == "")
            {
                throw new Exception("Pais vacio");
            }
            string ciudad = this.txt_crearEnvio_ciudad.Text;
            if (ciudad == null || ciudad == "")
            {
                throw new Exception("Ciudad vacio");
            }
            string codPostal = this.txt_crearEnvio_codPostal.Text;
            if (codPostal == null || codPostal == "")
            {
                throw new Exception("codPostal vacio");
            }

            bool tieneSeguro;
            //
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
                throw new Exception("Nombre destinatario vacio");
            }

            DateTime fechaIngreso = this.calendar_crearEnvio.SelectedDate;
            if (fechaIngreso == null)
            {
                throw new Exception("Debe especificar una fecha de ingreso");
            }

            if (this.ddl_crearEnvio_nroOficina.SelectedValue == null)
            {
                //ex
            }
            int nroOficina;
            bool resultOfi = Int32.TryParse(this.ddl_crearEnvio_nroOficina.SelectedValue, out nroOficina);

            int numeroEnvio;

            if (this.radiobtn_crearEnvio_esPaquete.Checked == true)
            {
                string largoEnv = this.txt_crearEnvio_largoPaquete.Text;
                if (largoEnv == null || largoEnv == "")
                {
                    throw new Exception("Largo vacio");
                }
                float largo;
                bool resultLargo = float.TryParse(largoEnv, out largo);
                if (resultLargo == false)
                {
                    throw new Exception("No se pudo convertir");
                }

                string anchoEnv = this.txt_crearEnvio_anchoPaquete.Text;
                if (anchoEnv == null || anchoEnv == "")
                {
                    throw new Exception("Ancho vacio");
                }
                float ancho;
                bool resultAncho = float.TryParse(anchoEnv, out ancho);
                if (!resultAncho)
                {
                    throw new Exception("No se pudo convertir");
                }

                string altoEnv = this.txt_crearEnvio_altoPaquete.Text;
                if (altoEnv == null || altoEnv == "")
                {
                    throw new Exception("Alto vacio");
                }
                float alto;
                bool resultAlto = float.TryParse(altoEnv, out alto);
                if (!resultAlto)
                {
                    throw new Exception("No se pudo convertir");
                }


                string descrip = this.txt_crearEnvio_DescripPaquete.Text;
                if (descrip == null || descrip == "")
                {
                    throw new Exception("Descripcion vacio");
                }

                tieneSeguro = this.chkbox_crearEnvio_seguro.Checked;

                string costoBaseXgramoEnv = this.txt_crearEnvio_costoBase.Text;
                if (costoBaseXgramoEnv == null || costoBaseXgramoEnv == "")
                {
                    throw new Exception("Costo vacio");
                }
                decimal costoBaseXgramo;
                bool resultadoCosto = decimal.TryParse(costoBaseXgramoEnv, out costoBaseXgramo);

                string valorDecEnv = this.txt_crearEnvio_valorDeclaradoPaquete.Text;
                if (valorDecEnv == null || valorDecEnv == "")
                {
                    throw new Exception("Valor declarado vacio");
                }
                decimal valorDec;
                bool resultadoValorDec = decimal.TryParse(valorDecEnv, out valorDec);
                if (!resultadoValorDec)
                {
                    throw new Exception("No pude convertir valor");
                }

                numeroEnvio = elSis.AltaEnvioPaquete(idCliente, nombreDestinatario, calle, nroPuerta, codPostal, ciudad, pais, fechaIngreso,
                                nroOficina, alto, ancho, largo, costoBaseXgramo, valorDec, tieneSeguro, peso, descrip);

                this.lbl_crearEnvio_muestraNroEnvio.Text = numeroEnvio.ToString();

            }

            if (this.radiobtn_crearEnvio_esDoc.Checked == true)
            {
                esDocLegal = this.chkbox_crearEnvio_esDocLegal.Checked;
                string calleOrigen = this.txt_crearEnvio_calleOrigen.Text;
                
                if (calleOrigen == null || calleOrigen == "")
                {
                    throw new Exception("Calle  Origen vacio");
                }
                
                string nroPuertaOrigen = this.txt_crearEnvio_nroOrigen.Text;
                
                if (nroPuertaOrigen == null || nroPuertaOrigen == "")
                {
                    if (!Utilidades.ChequearEsSoloNumero(nroPuertaOrigen))
                    {
                        throw new Exception("Nro Puerta Origen vacio");
                    }
                }
                
                string paisOrigen = this.txt_crearEnvio_paisOrigen.Text;
                
                if (paisOrigen == null || paisOrigen == "")
                {
                    throw new Exception("Pais Origen vacio");
                }

                string ciudadOrigen = this.txt_crearEnvio_ciudadOrigen.Text;

                if (ciudadOrigen == null || ciudadOrigen == "")
                {
                    throw new Exception("Ciudad Origen vacio");
                }

                string codPostalOrigen = this.txt_crearEnvio_codPostalOrigen.Text;

                if (codPostalOrigen == null || codPostalOrigen == "")
                {
                    throw new Exception("Cod Postal Origen  vacio");
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

