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
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void txt_crearEnvio_calleOrigen0_TextChanged(object sender, EventArgs e)
        {

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btn_crearEnvio_crearEnvio_Click(object sender, EventArgs e)
        {
            string peso = txt_crearEnvio_peso.Text;
            string nombre = txt_crearEnvio_nomDest.Text;
            string calle = txt_crearEnvio_calle.Text;
            string nroPuerta = txt_crearEnvio_numPuerta.Text;
            string pais = txt_crearEnvio_pais.Text;
            string ciudad = txt_crearEnvio_ciudad.Text;
            string codPostal = txt_crearEnvio_codPostal.Text;

            if (radiobtn_crearEnvio_esPaquete.Checked == true) {

                string largo = txt_crearEnvio_largoPaquete.Text;
                string ancho = txt_crearEnvio_anchoPaquete.Text;
                string alto = txt_crearEnvio_altoPaquete.Text;
                string descrip = txt_crearEnvio_DescripPaquete.Text;
                string valorDec = txt_crearEnvio_valorDeclaradoPaquete.Text;
                bool TieneSeguro = chkbox_crearEnvio_seguro.Checked; 
                
            }
            int numeroEnvio = 0; //elSis.AltaEnvioPaquete();
            lbl_crearEnvio_muestraNroEnvio.Text = "Su numero de envio es:" + numeroEnvio.ToString();
                 
           
            if (radiobtn_crearEnvio_esPaquete.Checked == true) 
            {
                bool esDocLegal = chkbox_crearEnvio_esDocLegal.Checked;
                string calleOrigen = txt_crearEnvio_calleOrigen.Text;
                string nroPuertaOrigen = txt_crearEnvio_nroOrigen.Text;
                string paisOrigen = txt_crearEnvio_paisOrigen.Text;
                string ciudadOrigen = txt_crearEnvio_ciudadOrigen.Text;
                string codPostalOrigen = txt_crearEnvio_codPostalOrigen.Text; 
            }
            numeroEnvio=0;//elSis.AltaEnvioDocumento();
            lbl_crearEnvio_muestraNroEnvio.Text = "Su numero de envio es:" + numeroEnvio.ToString(); //nroEnvio

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