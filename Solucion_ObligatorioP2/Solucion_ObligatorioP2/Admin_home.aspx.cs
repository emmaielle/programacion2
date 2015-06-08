using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Solucion_ObligatorioP2
{
    public partial class Admin_home : System.Web.UI.Page
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
                cargarCliente();
            }
            else p_homeAdmin_messageServer.InnerText = "";
        }

        protected void btn_homeAdmin_guardar_Click(object sender, EventArgs e)
        {
            string usrNm = txt_homeAdmin_Usuario.Text;
            string passWd = txt_homeAdmin_passwd.Text;
            string nmbre = txt_homeAdmin_nombre.Text;
            string apellido = txt_homeAdmin_Apellido.Text;
            string telefn = txt_homeAdmin_tel.Text;
            string calleUsr = txt_homeAdmin_Calle.Text;
            string nroPuerta = txt_nroPt_homeAdmin.Text;
            string codPostal = txt_homeAdmin_CP.Text;
            string ciudUsr = txt_homeAdmin_ciudad.Text;
            string paisUsr = txt_homeAdmin_Pais.Text;

            if (passWd != "" && nmbre != "" && apellido != "" && telefn != "" && calleUsr != "" && nroPuerta != "" && codPostal != "" && ciudUsr != "" &&
                paisUsr != "")
            {
                if (elSis.ChequearEsSoloNumero(telefn))
                {
                    if (elSis.ChequearEsSoloNumero(nroPuerta))
                    {
                        deshabilitarTxtBox();
                        elSis.ModificarUsuario(usrNm, passWd, nmbre, apellido, telefn, calleUsr, nroPuerta, codPostal, ciudUsr, paisUsr);
                        cargarCliente();
                    }
                    else p_homeAdmin_messageServer.InnerText = "El número de puerta debe contener solo números";
                }
                else p_homeAdmin_messageServer.InnerText = "El teléfono sólo puede contener números";
            }
        }

        protected void btn_homeAdmin_modificar_Click(object sender, EventArgs e)
        {
            habilitarTxtBox();

        }

        protected void cargarCliente()
        {
            string usrName = Session["UsuarioLogueado"].ToString();
            Usuario usuario = elSis.buscarUsuarioPorUsername(usrName);

            txt_homeAdmin_Apellido.Text = usuario.Apellido;
            txt_homeAdmin_Calle.Text = usuario.DireccionUsuario.Calle;
            txt_homeAdmin_CI.Text = usuario.Documento;
            txt_homeAdmin_ciudad.Text = usuario.DireccionUsuario.Ciudad;
            txt_homeAdmin_CP.Text = usuario.DireccionUsuario.CodPostal;
            txt_homeAdmin_nombre.Text = usuario.Nombre;
            txt_homeAdmin_Pais.Text = usuario.DireccionUsuario.Pais;
            txt_homeAdmin_tel.Text = usuario.Telefono;
            txt_homeAdmin_Usuario.Text = usuario.User;
            txt_nroPt_homeAdmin.Text = usuario.DireccionUsuario.Numero.ToString();

            txt_homeAdmin_passwd.Attributes.Add("Value", usuario.Password);
        }

        protected void deshabilitarTxtBox()
        {
            txt_homeAdmin_Apellido.Enabled = false;
            txt_homeAdmin_Calle.Enabled = false;
            txt_homeAdmin_ciudad.Enabled = false;
            txt_homeAdmin_CP.Enabled = false;
            txt_homeAdmin_nombre.Enabled = false;
            txt_homeAdmin_Pais.Enabled = false;
            txt_homeAdmin_passwd.Enabled = false;
            txt_homeAdmin_tel.Enabled = false;
            txt_nroPt_homeAdmin.Enabled = false;

            btn_homeAdmin_modificar.Visible = true;
            btn_homeAdmin_guardar.Visible = false;
        }

        protected void habilitarTxtBox()
        {

            txt_homeAdmin_Apellido.Enabled = true;
            txt_homeAdmin_Calle.Enabled = true;
            txt_homeAdmin_ciudad.Enabled = true;
            txt_homeAdmin_CP.Enabled = true;
            txt_homeAdmin_nombre.Enabled = true;
            txt_homeAdmin_Pais.Enabled = true;
            txt_homeAdmin_passwd.Enabled = true;
            txt_homeAdmin_tel.Enabled = true;
            txt_nroPt_homeAdmin.Enabled = true;

            btn_homeAdmin_guardar.Visible = true;
            btn_homeAdmin_modificar.Visible = false;

        }
    }
}