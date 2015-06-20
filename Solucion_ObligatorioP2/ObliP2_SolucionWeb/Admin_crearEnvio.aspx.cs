using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

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
                ddl_crearEnvio_nroOficina.DataSource = elSis.TraerNrosDeOficinasPostales();
                ddl_crearEnvio_nroOficina.DataBind();
                ddl_crearEnvio_etapa.DataSource = Enum.GetNames(EtapaEnvio.Etapas.EnOrigen.GetType());
                ddl_crearEnvio_etapa.DataBind();
                ddl_crearEnvio_etapa.Enabled = false;
            }
        }

        protected void btn_crearEnvio_crearEnvio_Click(object sender, EventArgs e)
        {
            /*<<<<<<< HEAD
                        float peso;
                        bool resultado = float.TryParse(txt_crearEnvio_peso.Text, out peso);

                        string nombre = txt_crearEnvio_nomDest.Text;
                        string calle = txt_crearEnvio_calle.Text;
                        string nroPuerta = txt_crearEnvio_numPuerta.Text;
                        string pais = txt_crearEnvio_pais.Text;
                        string ciudad = txt_crearEnvio_ciudad.Text;
                        string codPostal = txt_crearEnvio_codPostal.Text;
                        string descrip;
                        bool tieneSeguro;
                        bool esDocLegal;
                        string calleOrigen;
                        string nroPuertaOrigen;
                        string paisOrigen;
                        string ciudadOrigen;
                        string codPostalOrigen;
                        string nombreDestinatario = txt_crearEnvio_nomDest.Text;
                        DateTime fechaIngreso = calendar_crearEnvio.SelectedDate;

                        int nroOficina;
                        bool resultOfi = int.TryParse(ddl_crearEnvio_nroOficina.SelectedValue, out nroOficina);

                        int numeroEnvio;

                        if (radiobtn_crearEnvio_esPaquete.Checked == true)
                        {
                            float largo;
                            bool resultLargo = float.TryParse(txt_crearEnvio_largoPaquete.Text, out largo);
                
                            float ancho;
                            bool resultAncho = float.TryParse(txt_crearEnvio_anchoPaquete.Text, out ancho);
               
                            float alto;
                            bool resultAlto = float.TryParse(txt_crearEnvio_altoPaquete.Text, out alto);
               
                            descrip = txt_crearEnvio_DescripPaquete.Text;
                            tieneSeguro = chkbox_crearEnvio_seguro.Checked;

                            decimal costoBaseXgramo;
                            bool resultadoCosto = decimal.TryParse(txt_crearEnvio_costoBase.Text, out costoBaseXgramo);
                
                            decimal valorDec;
                            bool resultadoValorDec = decimal.TryParse(txt_crearEnvio_valorDeclaradoPaquete.Text, out valorDec);

                            numeroEnvio = elSis.AltaEnvioPaquete("1234567-8", nombreDestinatario, calle, nroPuerta, codPostal, ciudad, pais, fechaIngreso,
                                            nroOficina, alto, ancho, largo, costoBaseXgramo, valorDec, tieneSeguro, peso, descrip);
                
                            lbl_crearEnvio_muestraNroEnvio.Text = numeroEnvio.ToString();

                        }

                        if (radiobtn_crearEnvio_esDoc.Checked == true)
                        {
                            esDocLegal = chkbox_crearEnvio_esDocLegal.Checked;
                            calleOrigen = txt_crearEnvio_calleOrigen.Text;
                            nroPuertaOrigen = txt_crearEnvio_nroOrigen.Text;
                            paisOrigen = txt_crearEnvio_paisOrigen.Text;
                            ciudadOrigen = txt_crearEnvio_ciudadOrigen.Text;
                            codPostalOrigen = txt_crearEnvio_codPostalOrigen.Text;
                            nombreDestinatario = txt_crearEnvio_nomDest.Text;

                            numeroEnvio = elSis.AltaEnvioDocumento("1234567-8", calleOrigen, nroPuertaOrigen, codPostalOrigen, ciudadOrigen, paisOrigen, 
                                                                nombreDestinatario, calle, nroPuerta, codPostal, ciudad, pais, fechaIngreso, nroOficina, 
                                                                peso, esDocLegal);

                            lbl_crearEnvio_muestraNroEnvio.Text = numeroEnvio.ToString();
                        }
                    }

                    protected void radiobtn_crearEnvio_esPaqueteODocCheckedChanged(object sender, EventArgs e)
                    {
                        if (radiobtn_crearEnvio_esDoc.Checked)
                        {
                            PanelDocumento.Visible = true;
                            PanelPaquete.Visible = false;
                        }
                        if (radiobtn_crearEnvio_esPaquete.Checked)
                        {
                            PanelPaquete.Visible = true;
                            PanelDocumento.Visible = false;
                        }
                    }
    
                }

            }*/
            //=======

            string pesoEnv = txt_crearEnvio_peso.Text;
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

            string idCliente = txt_crearEnvio_idCliente.Text;
            if (idCliente == null || idCliente == "")
            {
                throw new Exception("Cliente vacio");
            }
            string nombre = txt_crearEnvio_nomDest.Text;
            if (nombre == null || nombre == "")
            {
                throw new Exception("Nombre vacio");
            }
            string calle = txt_crearEnvio_calle.Text;
            if (calle == null || calle == "")
            {
                throw new Exception("Calle vacio");
            }
            string nroPuerta = txt_crearEnvio_numPuerta.Text;
            if (nroPuerta == null || nroPuerta == "")
            {
                throw new Exception("nroPuerta vacio");

            }
            if (!elSis.ChequearEsSoloNumero(nroPuerta))
            {
                throw new Exception("No Pude convertir");
            }


            string pais = txt_crearEnvio_pais.Text;
            if (pais == null || pais == "")
            {
                throw new Exception("Pais vacio");
            }
            string ciudad = txt_crearEnvio_ciudad.Text;
            if (ciudad == null || ciudad == "")
            {
                throw new Exception("Ciudad vacio");
            }
            string codPostal = txt_crearEnvio_codPostal.Text;
            if (codPostal == null || codPostal == "")
            {
                throw new Exception("codPostal vacio");
            }
          
            bool tieneSeguro;
            //
            bool esDocLegal;

            //string calleOrigen = txt_crearEnvio_calleOrigen.Text;
            //if (calleOrigen == null || calleOrigen == "")
            //{
            //    throw new Exception("Calle Origen vacio");
            //}
            //string nroPuertaOrigen = txt_crearEnvio_nroOrigen.Text;
            //if (nroPuertaOrigen == null || nroPuertaOrigen == "")
            //{
            //    throw new Exception("Nro puerta Origen vacio");
            //}
            //string paisOrigen = txt_crearEnvio_paisOrigen.Text;
            //if (paisOrigen == null || paisOrigen == "")
            //{
            //    throw new Exception("Pais Origen vacio");
            //}
            //string ciudadOrigen = txt_crearEnvio_ciudadOrigen.Text;
            //if (ciudadOrigen == null || ciudadOrigen == "")
            //{
            //    throw new Exception("Ciudad Origen vacio");
            //}

            //string codPostalOrigen = txt_crearEnvio_codPostalOrigen.Text; ;
            //if (codPostalOrigen == null || codPostalOrigen == "")
            //{
            //    throw new Exception("Cod Postal Origen vacio");
            //}

            string nombreDestinatario = txt_crearEnvio_nomDest.Text;
            if (nombreDestinatario == null || nombreDestinatario == "")
            {
                throw new Exception("Nombre destinatario vacio");
            }

            DateTime fechaIngreso = calendar_crearEnvio.SelectedDate;
            if (fechaIngreso == null)
            {
                throw new Exception("Debe especificar una fecha de ingreso");
            }

            if (ddl_crearEnvio_nroOficina.SelectedValue == null)
            {
                //ex
            }
            int nroOficina;
            bool resultOfi = Int32.TryParse(ddl_crearEnvio_nroOficina.SelectedValue, out nroOficina);

            int numeroEnvio;

            if (radiobtn_crearEnvio_esPaquete.Checked == true)
            {
                string largoEnv = txt_crearEnvio_largoPaquete.Text;
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

                string anchoEnv = txt_crearEnvio_anchoPaquete.Text;
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

                string altoEnv = txt_crearEnvio_altoPaquete.Text;
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


                string descrip = txt_crearEnvio_DescripPaquete.Text;
                if (descrip == null || descrip == "")
                {
                    throw new Exception("Descripcion vacio");
                }

                tieneSeguro = chkbox_crearEnvio_seguro.Checked;

                string costoBaseXgramoEnv = txt_crearEnvio_costoBase.Text;
                if (costoBaseXgramoEnv == null || costoBaseXgramoEnv == "")
                {
                    throw new Exception("Costo vacio");
                }
                decimal costoBaseXgramo;
                bool resultadoCosto = decimal.TryParse(costoBaseXgramoEnv, out costoBaseXgramo);

                string valorDecEnv = txt_crearEnvio_valorDeclaradoPaquete.Text;
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

                lbl_crearEnvio_muestraNroEnvio.Text = numeroEnvio.ToString();


            }


            if (radiobtn_crearEnvio_esDoc.Checked == true)
            {
                esDocLegal = chkbox_crearEnvio_esDocLegal.Checked;
                string calleOrigen = txt_crearEnvio_calleOrigen.Text;
					if (calleOrigen == null || calleOrigen == "")
					{ 
                        throw new Exception("Calle  Origen vacio");
					}
                string nroPuertaOrigen = txt_crearEnvio_nroOrigen.Text;
					if (nroPuertaOrigen == null || nroPuertaOrigen == "")
					{
						if (!elSis.ChequearEsSoloNumero(nroPuertaOrigen))
						{
                            throw new Exception("Nro Puerta Origen vacio");
						}
					}
                string paisOrigen = txt_crearEnvio_paisOrigen.Text;
				if (paisOrigen == null || paisOrigen == "")
					{
                        throw new Exception("Pais Origen vacio");
					}

               string ciudadOrigen = txt_crearEnvio_ciudadOrigen.Text;
					if (ciudadOrigen == null || ciudadOrigen == "")
					{
                        throw new Exception("Ciudad Origen vacio");
					}

                string codPostalOrigen = txt_crearEnvio_codPostalOrigen.Text;
				if (codPostalOrigen == null || codPostalOrigen == "")
					{
                        throw new Exception("Cod Postal Origen  vacio");
					}
                
                        numeroEnvio = elSis.AltaEnvioDocumento(idCliente, calleOrigen, nroPuertaOrigen, codPostalOrigen, ciudadOrigen, paisOrigen,
                                              nombreDestinatario, calle, nroPuerta, codPostal, ciudad, pais, fechaIngreso, nroOficina,
                                              peso, esDocLegal);
                        lbl_crearEnvio_muestraNroEnvio.Text = numeroEnvio.ToString();
                    }
                
            }

 
    protected void radiobtn_crearEnvio_esPaqueteODocCheckedChanged(object sender, EventArgs e)
    {
        if (radiobtn_crearEnvio_esDoc.Checked)
        {
            PanelDocumento.Visible = true;
            PanelPaquete.Visible = false;
        }
        if (radiobtn_crearEnvio_esPaquete.Checked)
        {
            PanelPaquete.Visible = true;
            PanelDocumento.Visible = false;
        }


    }

    }
}



//>>>>>>> a1500b55ec9d188ef2140f5e865c83c8b587f847
