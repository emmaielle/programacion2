using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Solucion_ObligatorioP2
{
    public partial class Admin_CrearAdmin : System.Web.UI.Page
    {

        Sistema elSis = Sistema.Instancia;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["esAdmin"] == false)
            {
                Response.Redirect("~/Inicio.aspx");
            }

           
        }

        protected void TextBoxNombre_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBoxDocumento_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btn_crearAdmin_altaAdmin_Click(object sender, EventArgs e)
        {
            string usrNm = txt_crearAdmin_usuario.Text;
            string passWd = txt_crearAdmin_password.Text;
            string documento = txt_crearAdmin_doc.Text;
            string nmbre = txt_crearAdmin_nombre.Text;
            string apellido = txt_crearAdmin_apellido.Text;
            string telefn = txt_crearAdmin_telefono.Text;
            string calleUsr = txt_crearAdmin_calle.Text;
            string nroPuerta = txt_crearAdmin_numero.Text;
            string codPostal = txt_crearAdmin_cp.Text;
            string ciudUsr = txt_crearAdmin_ciudad.Text;
            string paisUsr = txt_crearAdmin_pais.Text;

            //Chequeos
             if (passWd != "" && nmbre != "" && apellido != "" && telefn != "" && calleUsr != "" && nroPuerta != "" && codPostal != "" && ciudUsr != "" &&
                paisUsr != "")
            {
                if (elSis.ChequearEsSoloNumero(telefn))
                {
                    if (elSis.ChequearEsSoloNumero(nroPuerta))
                    {
                        deshabilitarTxtBox();
                        elSis.AltaAdministrador(usrNm,passWd,documento,nmbre,
                            apellido, telefn, calleUsr,nroPuerta,codPostal,ciudUsr, paisUsr);
                       
                    }
                }
             }
            //        else p_CrearAdmin_messageServer.InnerText = "El número de puerta debe contener solo números";
            //    }
            //    else p_CrearAdmin_messageServer.InnerText = "El teléfono sólo puede contener números";
            //}
        }

        protected void deshabilitarTxtBox()
        {
            txt_crearAdmin_usuario.Enabled = false;
            txt_crearAdmin_password.Enabled = false;
            txt_crearAdmin_doc.Enabled = false;
            txt_crearAdmin_nombre.Enabled = false;
            txt_crearAdmin_apellido.Enabled = false;
            txt_crearAdmin_telefono.Enabled = false;
            txt_crearAdmin_calle.Enabled = false;
            txt_crearAdmin_numero.Enabled = false;
            txt_crearAdmin_cp.Enabled = false;
            txt_crearAdmin_ciudad.Enabled = false;
            txt_crearAdmin_pais.Enabled = false;

            btn_crearAdmin_altaAdmin.Visible = true;
           
        }

        protected void habilitarTxtBox()
        {

            txt_crearAdmin_usuario.Enabled = true;
            txt_crearAdmin_password.Enabled = true;
            txt_crearAdmin_doc.Enabled = true;
            txt_crearAdmin_nombre.Enabled = true;
            txt_crearAdmin_apellido.Enabled = true;
            txt_crearAdmin_telefono.Enabled = true;
            txt_crearAdmin_calle.Enabled = true;
            txt_crearAdmin_numero.Enabled = true;
            txt_crearAdmin_cp.Enabled = true;
            txt_crearAdmin_ciudad.Enabled = true;
            txt_crearAdmin_pais.Enabled = true;


            btn_crearAdmin_altaAdmin.Visible = true;

          

        }

    

        }
    }
