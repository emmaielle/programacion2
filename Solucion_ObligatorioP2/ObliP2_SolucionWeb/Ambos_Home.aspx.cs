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
            else p_homes_messageServer.InnerText = "";
        }

        protected void btn_homes_guardar_Click(object sender, EventArgs e)
        {
            string usrNm = txt_homes_Usuario.Text;
            string passWd = txt_homes_passwd.Text;
            string nmbre = txt_homes_nombre.Text;
            string apellido = txt_homes_Apellido.Text;
            string telefn = txt_homes_tel.Text;
            string calleUsr = txt_homes_Calle.Text;
            string nroPuerta = txt_nroPt_homes.Text;
            string codPostal = txt_homes_CP.Text;
            string ciudUsr = txt_homes_ciudad.Text;
            string paisUsr = txt_homes_Pais.Text;
            string mail = txt_homes_Mail.Text;

            if (!string.IsNullOrEmpty(passWd) && !string.IsNullOrEmpty(nmbre) && !string.IsNullOrEmpty(apellido) && 
                !string.IsNullOrEmpty(telefn) && !string.IsNullOrEmpty(calleUsr) && !string.IsNullOrEmpty(nroPuerta) 
                && !string.IsNullOrEmpty(codPostal) && !string.IsNullOrEmpty(ciudUsr) && !string.IsNullOrEmpty(paisUsr) &&
                !string.IsNullOrEmpty(mail))
            {
                if (Utilidades.ChequearEsSoloNumero(telefn))
                {
                    if (Utilidades.EsMail(mail))
                    {
                        if (Utilidades.ChequearEsSoloNumero(nroPuerta))
                        {
                            deshabilitarTxtBox();
                            elSis.ModificarUsuario(usrNm, passWd, nmbre, apellido, telefn, calleUsr, nroPuerta, codPostal, ciudUsr, paisUsr, mail);
                            cargarCliente();
                        }
                        else p_homes_messageServer.InnerText = "El número de puerta debe contener solo números";
                    }
                    else p_homes_messageServer.InnerText = "El mail debe tener el formato adecuado";
                }
                else p_homes_messageServer.InnerText = "El teléfono sólo puede contener números";
            }
        }

        protected void btn_homes_modificar_Click(object sender, EventArgs e)
        {
            habilitarTxtBox();
        }

        protected void cargarCliente()
        {
            string usrName = Session["UsuarioLogueado"].ToString();
            Usuario usuario = elSis.BuscarUsuarioPorUsername(usrName);

            txt_homes_Apellido.Text = usuario.Apellido;
            txt_homes_Calle.Text = usuario.DireccionUsuario.Calle;
            txt_homes_CI.Text = usuario.Documento;
            txt_homes_ciudad.Text = usuario.DireccionUsuario.Ciudad;
            txt_homes_CP.Text = usuario.DireccionUsuario.CodPostal;
            txt_homes_nombre.Text = usuario.Nombre;
            txt_homes_Pais.Text = usuario.DireccionUsuario.Pais;
            txt_homes_tel.Text = usuario.Telefono;
            txt_homes_Usuario.Text = usuario.User;
            txt_nroPt_homes.Text = usuario.DireccionUsuario.Numero.ToString();
            txt_homes_Mail.Text = usuario.Mail;
            txt_homes_passwd.Attributes.Add("Value", usuario.Password);
        }

        protected void deshabilitarTxtBox()
        {
            txt_homes_Apellido.Enabled = false;
            txt_homes_Calle.Enabled = false;
            txt_homes_ciudad.Enabled = false;
            txt_homes_CP.Enabled = false;
            txt_homes_nombre.Enabled = false;
            txt_homes_Pais.Enabled = false;
            txt_homes_passwd.Enabled = false;
            txt_homes_tel.Enabled = false;
            txt_nroPt_homes.Enabled = false;
            txt_homes_Mail.Enabled = false;

            btn_homes_modificar.Visible = true;
            btn_homes_guardar.Visible = false;
        }

        protected void habilitarTxtBox()
        {

            txt_homes_Apellido.Enabled = true;
            txt_homes_Calle.Enabled = true;
            txt_homes_ciudad.Enabled = true;
            txt_homes_CP.Enabled = true;
            txt_homes_nombre.Enabled = true;
            txt_homes_Pais.Enabled = true;
            txt_homes_passwd.Enabled = true;
            txt_homes_tel.Enabled = true;
            txt_nroPt_homes.Enabled = true;
            txt_homes_Mail.Enabled = true;

            btn_homes_guardar.Visible = true;
            btn_homes_modificar.Visible = false;

        }
    }
}