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
                this.ddl_crearEnvio_etapa.DataSource =  Enum.GetNames(EtapaEnvio.Etapas.EnOrigen.GetType());
                this.ddl_crearEnvio_etapa.DataBind();
                this.ddl_crearEnvio_etapa.Enabled = false;
            }
        }

        protected void btn_crearEnvio_crearEnvio_Click(object sender, EventArgs e)
        {
/*<<<<<<< HEAD
            float peso;
            bool resultado = float.TryParse(this.txt_crearEnvio_peso.Text, out peso);

            string nombre = this.txt_crearEnvio_nomDest.Text;
            string calle = this.txt_crearEnvio_calle.Text;
            string nroPuerta = this.txt_crearEnvio_numPuerta.Text;
            string pais = this.txt_crearEnvio_pais.Text;
            string ciudad = this.txt_crearEnvio_ciudad.Text;
            string codPostal = this.txt_crearEnvio_codPostal.Text;
            string descrip;
            bool tieneSeguro;
            bool esDocLegal;
            string calleOrigen;
            string nroPuertaOrigen;
            string paisOrigen;
            string ciudadOrigen;
            string codPostalOrigen;
            string nombreDestinatario = this.txt_crearEnvio_nomDest.Text;
            DateTime fechaIngreso = calendar_crearEnvio.SelectedDate;

            int nroOficina;
            bool resultOfi = int.TryParse(this.ddl_crearEnvio_nroOficina.SelectedValue, out nroOficina);

            int numeroEnvio;

            if (radiobtn_crearEnvio_esPaquete.Checked == true)
            {
                float largo;
                bool resultLargo = float.TryParse(this.txt_crearEnvio_largoPaquete.Text, out largo);
                
                float ancho;
                bool resultAncho = float.TryParse(this.txt_crearEnvio_anchoPaquete.Text, out ancho);
               
                float alto;
                bool resultAlto = float.TryParse(this.txt_crearEnvio_altoPaquete.Text, out alto);
               
                descrip = this.txt_crearEnvio_DescripPaquete.Text;
                tieneSeguro = chkbox_crearEnvio_seguro.Checked;

                decimal costoBaseXgramo;
                bool resultadoCosto = decimal.TryParse(this.txt_crearEnvio_costoBase.Text, out costoBaseXgramo);
                
                decimal valorDec;
                bool resultadoValorDec = decimal.TryParse(this.txt_crearEnvio_valorDeclaradoPaquete.Text, out valorDec);

                numeroEnvio = elSis.AltaEnvioPaquete("1234567-8", nombreDestinatario, calle, nroPuerta, codPostal, ciudad, pais, fechaIngreso,
                                nroOficina, alto, ancho, largo, costoBaseXgramo, valorDec, tieneSeguro, peso, descrip);
                
                lbl_crearEnvio_muestraNroEnvio.Text = numeroEnvio.ToString();

            }

            if (radiobtn_crearEnvio_esDoc.Checked == true)
            {
                esDocLegal = chkbox_crearEnvio_esDocLegal.Checked;
                calleOrigen = this.txt_crearEnvio_calleOrigen.Text;
                nroPuertaOrigen = this.txt_crearEnvio_nroOrigen.Text;
                paisOrigen = this.txt_crearEnvio_paisOrigen.Text;
                ciudadOrigen = this.txt_crearEnvio_ciudadOrigen.Text;
                codPostalOrigen = this.txt_crearEnvio_codPostalOrigen.Text;
                nombreDestinatario = this.txt_crearEnvio_nomDest.Text;

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

            string pesoEnv = this.txt_crearEnvio_peso.Text;
            if (pesoEnv == null || pesoEnv == "")
            {
                //ex
            }
                
            float peso;
            bool resultado = float.TryParse(pesoEnv, out peso);
            if (!resultado) 
             {
                  //deberia tirar una excepcion
             }
            

           
            
            string idCliente = this.txt_crearEnvio_idCliente.Text;
            if (idCliente == null || idCliente == "") {
                //exception
            }
            string nombre = this.txt_crearEnvio_nomDest.Text;
            if (nombre == null || nombre == "")
            {
            //exception
            }
            string calle = this.txt_crearEnvio_calle.Text;
            if (calle == null ||calle =="")
            {
            //exception
            }
            string nroPuerta = this.txt_crearEnvio_numPuerta.Text;
            if (nroPuerta == null || nroPuerta == "")
            {
                //exception
               
            }
                if (!Utilidades.ChequearEsSoloNumero(nroPuerta)) 
                {
                //ex
                }


            string pais = this.txt_crearEnvio_pais.Text;
            if (pais == null || pais != "") 
            {
                //exception
            }
            string ciudad = this.txt_crearEnvio_ciudad.Text;
                if (ciudad == null || ciudad ==  "")
                {
                    //exception
                }
            string codPostal = this.txt_crearEnvio_codPostal.Text;
                if (codPostal == null || codPostal == "") 
                {
                //exception
                }
            string descrip = this.txt_crearEnvio_DescripPaquete.Text;
                if (descrip == null || descrip == "") 
                {
                //exception
                }

            bool tieneSeguro;
            bool esDocLegal;

            string calleOrigen = this.txt_crearEnvio_calleOrigen.Text;
                if (calleOrigen == null || calleOrigen == "")
                {
                //exception
                }
            string nroPuertaOrigen = this.txt_crearEnvio_nroOrigen.Text;
                if (nroPuertaOrigen == null || nroPuertaOrigen == "")
                {
                //ex
                }
            string paisOrigen = this.txt_crearEnvio_paisOrigen.Text;
                if (paisOrigen == null || paisOrigen == "")
                {
                //ex
                }
            string ciudadOrigen = this.txt_crearEnvio_ciudadOrigen.Text;
                if (ciudadOrigen == null || ciudadOrigen == "")
                {
                //ex
                }

            string codPostalOrigen = this.txt_crearEnvio_codPostalOrigen.Text;;
                if (codPostalOrigen == null || codPostalOrigen == "")
                {
                //ex
                }
            string nombreDestinatario = this.txt_crearEnvio_nomDest.Text;
                if (nombreDestinatario == null || nombreDestinatario == "")
                {
                //ex
                }
            DateTime fechaIngreso = calendar_crearEnvio.SelectedDate;
            if (fechaIngreso == null) 
            {
            //ex
            }

           if (this.ddl_crearEnvio_nroOficina.SelectedValue == null) {
           //ex
           }
            int nroOficina;
            bool resultOfi = Int32.TryParse(this.ddl_crearEnvio_nroOficina.SelectedValue, out nroOficina);

            int numeroEnvio;

            if (radiobtn_crearEnvio_esPaquete.Checked == true)
            {
                string largoEnv = this.txt_crearEnvio_largoPaquete.Text;
                    if (largoEnv == null || largoEnv == "")
                    {
                        //ex
                    }
                    float largo;
                    bool resultLargo = float.TryParse(largoEnv, out largo);
                        if (resultLargo == false) {
                        //ex
                        }
                                     
                string anchoEnv = this.txt_crearEnvio_anchoPaquete.Text;
                    if (anchoEnv == null || anchoEnv == "")
                    {
                        //ex
                    }
                    float ancho;
                    bool resultAncho = float.TryParse(anchoEnv, out ancho);
                        if (!resultAncho) {
                        //ex
                        }

                string altoEnv = this.txt_crearEnvio_altoPaquete.Text;
                if (altoEnv == null || altoEnv == "")
                {
                //env
                }
                float alto;
                bool resultAlto = float.TryParse(altoEnv, out alto);


                descrip = this.txt_crearEnvio_DescripPaquete.Text;
                if (descrip == null || descrip == "")
                {
                //ex
                }

                tieneSeguro = chkbox_crearEnvio_seguro.Checked;

                string costoBaseXgramoEnv = this.txt_crearEnvio_costoBase.Text;
                    if (costoBaseXgramoEnv == null || costoBaseXgramoEnv == "")
                    {
                    //ex
                    }
                decimal costoBaseXgramo;
                bool resultadoCosto = decimal.TryParse(costoBaseXgramoEnv, out costoBaseXgramo);

                string valorDecEnv = this.txt_crearEnvio_valorDeclaradoPaquete.Text;
                    if(valorDecEnv == null || valorDecEnv == "")
                    {
                    //ex
                    }
                decimal valorDec;
                bool resultadoValorDec = decimal.TryParse(valorDecEnv, out valorDec);

                numeroEnvio = elSis.AltaEnvioPaquete(idCliente, nombreDestinatario, calle, nroPuerta, codPostal, ciudad, pais, fechaIngreso,
                                nroOficina, alto, ancho, largo, costoBaseXgramo, valorDec, tieneSeguro, peso, descrip);

                lbl_crearEnvio_muestraNroEnvio.Text = numeroEnvio.ToString();

               
            }


                    //ACA ME QUEDE!!!!

                    if (radiobtn_crearEnvio_esDoc.Checked == true)
                    {
                        esDocLegal = chkbox_crearEnvio_esDocLegal.Checked;
                        calleOrigen = this.txt_crearEnvio_calleOrigen.Text;
                        nroPuertaOrigen = this.txt_crearEnvio_nroOrigen.Text;
                        paisOrigen = this.txt_crearEnvio_paisOrigen.Text;
                        ciudadOrigen = this.txt_crearEnvio_ciudadOrigen.Text;
                        codPostalOrigen = this.txt_crearEnvio_codPostalOrigen.Text;
                        nombreDestinatario = this.txt_crearEnvio_nomDest.Text;

                        if (calleOrigen != "" && nroPuertaOrigen != "" && paisOrigen != "" && ciudadOrigen != ""
                                        && codPostalOrigen != "")
                        {
                            if (Utilidades.ChequearEsSoloNumero(nroPuertaOrigen))
                            {

                                numeroEnvio = elSis.AltaEnvioDocumento(idCliente, calleOrigen, nroPuertaOrigen, codPostalOrigen, ciudadOrigen, paisOrigen,
                                                      nombreDestinatario, calle, nroPuerta, codPostal, ciudad, pais, fechaIngreso, nroOficina,
                                                      peso, esDocLegal);
                                lbl_crearEnvio_muestraNroEnvio.Text = numeroEnvio.ToString();
                            }
                        }
                    }

                
            }

        }



        //protected void radiobtn_crearEnvio_esPaqueteODocCheckedChanged(object sender, EventArgs e)
        //{
        //    if (radiobtn_crearEnvio_esDoc.Checked)
        //    {
        //        PanelDocumento.Visible = true;
        //        PanelPaquete.Visible = false;
        //    }
        //    if (radiobtn_crearEnvio_esPaquete.Checked)
        //    {
        //        PanelPaquete.Visible = true;
        //        PanelDocumento.Visible = false;
        //    }


        //}
    
}


//>>>>>>> a1500b55ec9d188ef2140f5e865c83c8b587f847
