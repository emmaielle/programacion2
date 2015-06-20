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
            string usrNm = this.txt_crearAdmin_usuario.Text;
            string passWd = this.txt_crearAdmin_password.Text;
            string documento = this.txt_crearAdmin_doc.Text;
            string nmbre = this.txt_crearAdmin_nombre.Text;
            string apellido = this.txt_crearAdmin_apellido.Text;
            string telefn = this.txt_crearAdmin_telefono.Text;
            string calleUsr = this.txt_crearAdmin_calle.Text;
            string nroPuerta = this.txt_crearAdmin_numero.Text;
            string codPostal = this.txt_crearAdmin_cp.Text;
            string ciudUsr = this.txt_crearAdmin_ciudad.Text;
            string paisUsr = this.txt_crearAdmin_pais.Text;
            string mail = this.txt_crearAdmin_mail.Text;

            //Chequeos
            if (!String.IsNullOrEmpty(passWd) && !String.IsNullOrEmpty(nmbre) && !String.IsNullOrEmpty(apellido) &&
                !String.IsNullOrEmpty(telefn) && !String.IsNullOrEmpty(calleUsr) && !String.IsNullOrEmpty(nroPuerta) &&
                !String.IsNullOrEmpty(codPostal) && !String.IsNullOrEmpty(ciudUsr) && !String.IsNullOrEmpty(paisUsr) &&
                !String.IsNullOrEmpty(mail))
            {
                if (Utilidades.ChequearEsSoloNumero(telefn))
                {
                    if (Utilidades.ChequearEsSoloNumero(nroPuerta))
                    {
                        deshabilitarTxtBox();
                        elSis.AltaAdministrador(usrNm, passWd, documento, nmbre,
                            apellido, telefn, calleUsr, nroPuerta, codPostal, ciudUsr, paisUsr, mail);

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
            this.txt_crearAdmin_usuario.Enabled = false;
            this.txt_crearAdmin_password.Enabled = false;
            this.txt_crearAdmin_doc.Enabled = false;
            this.txt_crearAdmin_nombre.Enabled = false;
            this.txt_crearAdmin_apellido.Enabled = false;
            this.txt_crearAdmin_telefono.Enabled = false;
            this.txt_crearAdmin_calle.Enabled = false;
            this.txt_crearAdmin_numero.Enabled = false;
            this.txt_crearAdmin_cp.Enabled = false;
            this.txt_crearAdmin_ciudad.Enabled = false;
            this.txt_crearAdmin_pais.Enabled = false;

            btn_crearAdmin_altaAdmin.Visible = true;
        }

        protected void habilitarTxtBox()
        {

            this.txt_crearAdmin_usuario.Enabled = true;
            this.txt_crearAdmin_password.Enabled = true;
            this.txt_crearAdmin_doc.Enabled = true;
            this.txt_crearAdmin_nombre.Enabled = true;
            this.txt_crearAdmin_apellido.Enabled = true;
            this.txt_crearAdmin_telefono.Enabled = true;
            this.txt_crearAdmin_calle.Enabled = true;
            this.txt_crearAdmin_numero.Enabled = true;
            this.txt_crearAdmin_cp.Enabled = true;
            this.txt_crearAdmin_ciudad.Enabled = true;
            this.txt_crearAdmin_pais.Enabled = true;

            btn_crearAdmin_altaAdmin.Visible = true;
        }
    }
}


