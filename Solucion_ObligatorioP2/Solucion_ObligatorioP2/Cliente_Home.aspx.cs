using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Solucion_ObligatorioP2
{
    public partial class Cliente_home : System.Web.UI.Page
    {
        Sistema elSis = Sistema.Instancia;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["esCliente"] == false)
            {
                Response.Redirect("~/Inicio.aspx");

            }

            if (!this.IsPostBack)
            {
                cargarCliente();
            }
            else p_home_messageServer.InnerText = "";
        }

        protected void btn_homeCli_modificar_Click(object sender, EventArgs e)
        {
            habilitarTxtBox();
        }

        protected void btn_homeCli_guardar_Click(object sender, EventArgs e)
        {

            string usrNm = txt_homeCli_Usuario.Text;
            string passWd = txt_homeCli_passwd.Text;
            string nmbre = txt_homeCli_nombre.Text;
            string apellido = txt_homeCli_Apellido.Text;
            string telefn = txt_homeCli_tel.Text;
            string calleUsr = txt_homeCli_Calle.Text;
            string nroPuerta = txt_nroPt_homeCli.Text;
            string codPostal =  txt_homeCli_CP.Text;
            string ciudUsr = txt_homeCli_ciudad.Text;
            string paisUsr = txt_homeCli_Pais.Text;

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
                    else p_home_messageServer.InnerText = "El número de puerta debe contener solo números";
                }
                else p_home_messageServer.InnerText = "El teléfono sólo puede contener números";
            }

        }

        protected void cargarCliente()
        {
            string usrName = Session["UsuarioLogueado"].ToString();
            Usuario usuario = elSis.buscarUsuarioPorUsername(usrName);

            txt_homeCli_Apellido.Text = usuario.Apellido;
            txt_homeCli_Calle.Text = usuario.DireccionUsuario.Calle;
            txt_homeCli_CI.Text = usuario.Documento;
            txt_homeCli_ciudad.Text = usuario.DireccionUsuario.Ciudad;
            txt_homeCli_CP.Text = usuario.DireccionUsuario.CodPostal;
            txt_homeCli_nombre.Text = usuario.Nombre;
            txt_homeCli_Pais.Text = usuario.DireccionUsuario.Pais;
            txt_homeCli_tel.Text = usuario.Telefono;
            txt_homeCli_Usuario.Text = usuario.User;
            txt_nroPt_homeCli.Text = usuario.DireccionUsuario.Numero.ToString();

            txt_homeCli_passwd.Attributes.Add("Value", usuario.Password);
        }

        protected void deshabilitarTxtBox()
        {
            txt_homeCli_Apellido.Enabled = false;
            txt_homeCli_Calle.Enabled = false;
            txt_homeCli_ciudad.Enabled = false;
            txt_homeCli_CP.Enabled = false;
            txt_homeCli_nombre.Enabled = false;
            txt_homeCli_Pais.Enabled = false;
            txt_homeCli_passwd.Enabled = false;
            txt_homeCli_tel.Enabled = false;
            txt_nroPt_homeCli.Enabled = false;

            btn_homeCli_modificar.Visible = true;
            btn_homeCli_guardar.Visible = false;
        }

        protected void habilitarTxtBox()
        {
        
            txt_homeCli_Apellido.Enabled = true;
            txt_homeCli_Calle.Enabled = true;
            txt_homeCli_ciudad.Enabled = true;
            txt_homeCli_CP.Enabled = true;
            txt_homeCli_nombre.Enabled = true;
            txt_homeCli_Pais.Enabled = true;
            txt_homeCli_passwd.Enabled = true;
            txt_homeCli_tel.Enabled = true;
            txt_nroPt_homeCli.Enabled = true;

            btn_homeCli_guardar.Visible = true;
            btn_homeCli_modificar.Visible = false;
        
        }
    }
}