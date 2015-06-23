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
    public partial class Ambos_Home : System.Web.UI.Page
    {
        Sistema elSis = Sistema.Instancia;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioLogueado"].ToString() == "")
            {
                Response.Redirect("~/Inicio.aspx");
            }

            if (!this.IsPostBack)
            {
                cargarCliente();
            }
            else this.p_homes_messageServer.InnerText = "";
        }

        protected void btn_homes_guardar_Click(object sender, EventArgs e)
        {
            string usrNm = this.txt_homes_Usuario.Text;
            string passWd = this.txt_homes_passwd.Text;
            string nmbre = this.txt_homes_nombre.Text;
            string apellido = this.txt_homes_Apellido.Text;
            string telefn = this.txt_homes_tel.Text;
            string calleUsr = this.txt_homes_Calle.Text;
            string nroPuerta = this.txt_nroPt_homes.Text;
            string codPostal = this.txt_homes_CP.Text;
            string ciudUsr = this.txt_homes_ciudad.Text;
            string paisUsr = this.txt_homes_Pais.Text;
            string mail = this.txt_homes_Mail.Text;

            Usuario usr = elSis.BuscarUsuarioPorUsername(usrNm);
            string mailAnterior = usr.Mail;
            bool mailUsado = elSis.MailYaUsado(mail, mailAnterior);

            if (!string.IsNullOrEmpty(passWd) && !string.IsNullOrEmpty(nmbre) && !string.IsNullOrEmpty(apellido) &&
                !string.IsNullOrEmpty(telefn) && !string.IsNullOrEmpty(calleUsr) && !string.IsNullOrEmpty(nroPuerta)
                && !string.IsNullOrEmpty(codPostal) && !string.IsNullOrEmpty(ciudUsr) && !string.IsNullOrEmpty(paisUsr) &&
                !string.IsNullOrEmpty(mail))
            {
                if (Utilidades.ChequearEsSoloNumero(telefn))
                {
                    if (Utilidades.EsMail(mail))
                    {
                        if (!mailUsado)
                        {
                            if (Utilidades.ChequearEsSoloNumero(nroPuerta))
                            {
                                deshabilitarTxtBox();
                                elSis.ModificarUsuario(usrNm, passWd, nmbre, apellido, telefn, calleUsr, nroPuerta, codPostal, ciudUsr, paisUsr, mail);
                                cargarCliente();
                            }
                            else this.p_homes_messageServer.InnerText = "El número de puerta debe contener solo números";
                        }
                        else this.p_homes_messageServer.InnerText = "Ese mail ya fue registrado";
                    }
                    else this.p_homes_messageServer.InnerText = "El mail debe tener el formato adecuado";
                }
                else this.p_homes_messageServer.InnerText = "El teléfono sólo puede contener números";
            }
            else this.p_homes_messageServer.InnerText = "Todos los campos deben ser completados";
        }

        protected void btn_homes_modificar_Click(object sender, EventArgs e)
        {
            habilitarTxtBox();
        }

        protected void cargarCliente()
        {
            string usrName = Session["UsuarioLogueado"].ToString();
            Usuario usuario = elSis.BuscarUsuarioPorUsername(usrName);

            this.txt_homes_Apellido.Text = usuario.Apellido;
            this.txt_homes_Calle.Text = usuario.DireccionUsuario.Calle;
            this.txt_homes_CI.Text = usuario.Documento;
            this.txt_homes_ciudad.Text = usuario.DireccionUsuario.Ciudad;
            this.txt_homes_CP.Text = usuario.DireccionUsuario.CodPostal;
            this.txt_homes_nombre.Text = usuario.Nombre;
            this.txt_homes_Pais.Text = usuario.DireccionUsuario.Pais;
            this.txt_homes_tel.Text = usuario.Telefono;
            this.txt_homes_Usuario.Text = usuario.User;
            this.txt_nroPt_homes.Text = usuario.DireccionUsuario.Numero.ToString();
            this.txt_homes_Mail.Text = usuario.Mail;
            this.txt_homes_passwd.Attributes.Add("Value", usuario.Password);
        }

        protected void deshabilitarTxtBox()
        {
            this.txt_homes_Apellido.Enabled = false;
            this.txt_homes_Calle.Enabled = false;
            this.txt_homes_ciudad.Enabled = false;
            this.txt_homes_CP.Enabled = false;
            this.txt_homes_nombre.Enabled = false;
            this.txt_homes_Pais.Enabled = false;
            this.txt_homes_passwd.Enabled = false;
            this.txt_homes_tel.Enabled = false;
            this.txt_nroPt_homes.Enabled = false;
            this.txt_homes_Mail.Enabled = false;

            this.btn_homes_modificar.Visible = true;
            this.btn_homes_guardar.Visible = false;
        }

        protected void habilitarTxtBox()
        {
            this.txt_homes_Apellido.Enabled = true;
            this.txt_homes_Calle.Enabled = true;
            this.txt_homes_ciudad.Enabled = true;
            this.txt_homes_CP.Enabled = true;
            this.txt_homes_nombre.Enabled = true;
            this.txt_homes_Pais.Enabled = true;
            this.txt_homes_passwd.Enabled = true;
            this.txt_homes_tel.Enabled = true;
            this.txt_nroPt_homes.Enabled = true;
            this.txt_homes_Mail.Enabled = true;

            this.btn_homes_guardar.Visible = true;
            this.btn_homes_modificar.Visible = false;

        }
    }
}