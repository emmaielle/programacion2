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
                ddl_crearEnvio_etapa.DataSource =  Enum.GetNames(EtapaEnvio.Etapas.EnOrigen.GetType());
                ddl_crearEnvio_etapa.DataBind();
                ddl_crearEnvio_etapa.Enabled = false;
            }
            
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btn_crearEnvio_crearEnvio_Click(object sender, EventArgs e)
        {


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
           

            string cliente = Session["UsuarioLogueado"].ToString(); /*ask! */

            if (radiobtn_crearEnvio_esPaquete.Checked == true) {


                float largo;
                bool resultLargo = float.TryParse(txt_crearEnvio_largoPaquete.Text, out largo);
                float ancho;
                bool resultAncho = float.TryParse(txt_crearEnvio_anchoPaquete.Text, out ancho);
                float alto;
                bool resultAlto = float.TryParse(txt_crearEnvio_altoPaquete.Text, out alto);
                descrip = txt_crearEnvio_DescripPaquete.Text;
                decimal costoBaseXgramo;
                bool resultadoCosto = decimal.TryParse(txt_crearEnvio_costoBase.Text, out costoBaseXgramo);
                decimal valorDec;
                bool resultadoValorDec = decimal.TryParse(txt_crearEnvio_valorDeclaradoPaquete.Text, out valorDec);
                tieneSeguro = chkbox_crearEnvio_seguro.Checked;


                numeroEnvio = elSis.AltaEnvioPaquete(cliente, nombreDestinatario, calle, nroPuerta, codPostal, ciudad, pais, fechaIngreso,
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


               
               numeroEnvio = elSis.AltaEnvioDocumento(cliente, calleOrigen, nroPuertaOrigen, codPostalOrigen, ciudadOrigen, paisOrigen, nombreDestinatario,
                   calle, nroPuerta, codPostal, ciudad, pais, fechaIngreso, nroOficina, peso, esDocLegal);
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


        //protected void ddl_crearEnvio_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    EtapaEnvio.Etapas etapaIngresada;
        //    etapaIngresada = EtapaEnvio.Etapas.EnOrigen;

        //    ddl_crearEnvio_etapa.Enabled = false;
                
        //}

        protected void txt_crearEnvio_calleOrigen_TextChanged(object sender, EventArgs e)
        {

        }

        protected void calendar_crearEnvio_SelectionChanged(object sender, EventArgs e)
        {

        }

       
    
    }

}