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
            if (this.IsPostBack)
            {
                p_crearAdmin_mensajes.InnerText = "";
            }
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
                        if (Utilidades.ChequearEsSoloNumero(documento))
                        {
                            if (Utilidades.EsMail(mail))
                            {
                                if (!elSis.MailYaUsado(mail, ""))
                                {
                                    if (elSis.BuscarAdmin(documento) == null)
                                    {
                                        if (elSis.BuscarUsuarioPorUsername(usrNm) == null)
                                        {
                                            elSis.AltaAdministrador(usrNm, passWd, documento, nmbre,
                                                apellido, telefn, calleUsr, nroPuerta, codPostal, ciudUsr, paisUsr, mail);

                                            this.p_crearAdmin_mensajes.InnerText = "El administrador " + usrNm + " ha sido creado";
                                        }
                                        else this.p_crearAdmin_mensajes.InnerText = "El usuario ingresado ya fue utilizado";
                                    }
                                    else this.p_crearAdmin_mensajes.InnerText = "El documento ingresado ya existe";
                                }
                                else this.p_crearAdmin_mensajes.InnerText = "El mail ingresado ya existe";
                            }
                            else this.p_crearAdmin_mensajes.InnerText = "El mail debe estar en el formato adecuado";
                        }
                        else this.p_crearAdmin_mensajes.InnerText = "El documento sólo debe contener números";
                    }
                    else this.p_crearAdmin_mensajes.InnerText = "El número de puerta sólo debe contener números";
                }
                else this.p_crearAdmin_mensajes.InnerText = "El teléfono sólo debe contener números";
            }
        }
    }
}


