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
    public partial class Registro_Usuario : System.Web.UI.Page
    {
        Sistema elSis = Sistema.Instancia;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                this.p_registro_message.InnerText = "";
            }
        }
        
        protected void link_registro_volver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio.aspx");
        }

        protected void btn_registro_registrar_Click1(object sender, EventArgs e)
        {
            string ci = this.txt_registro_CI.Text;
            string nombre = this.txt_registro_nombre.Text;
            string apellido = this.txt_registro_Apellido.Text;
            string telefono = this.txt_registro_tel.Text;
            string pais = this.txt_registro_Pais.Text;
            string ciudad = this.txt_registro_ciudad.Text;
            string CP = this.txt_registro_CP.Text;
            string calle = this.txt_registro_Calle.Text;
            string nroPuerta = this.txt_nroPt_registro.Text;
            string usuario = this.txt_registro_Usuario.Text;
            string password = this.txt_registro_passwd.Text;
            string mail = this.txt_registro_mail.Text;

            if (!string.IsNullOrWhiteSpace(ci) && !string.IsNullOrWhiteSpace(nombre) && !string.IsNullOrWhiteSpace(apellido)
                && !string.IsNullOrWhiteSpace(telefono) && !string.IsNullOrWhiteSpace(pais) && !string.IsNullOrWhiteSpace(ciudad)
                && !string.IsNullOrWhiteSpace(CP) && !string.IsNullOrWhiteSpace(calle) && !string.IsNullOrWhiteSpace(nroPuerta)
                && !string.IsNullOrWhiteSpace(usuario) && !string.IsNullOrWhiteSpace(password) && !string.IsNullOrWhiteSpace(mail))
            {
                bool resultNroPta = Utilidades.ChequearEsSoloNumero(nroPuerta);
                bool resultTel = Utilidades.ChequearEsSoloNumero(telefono);
                bool resultCI = Utilidades.ChequearEsSoloNumero(ci);

                bool lenPass = false;
                if (password.Length >= 6) lenPass = true;
                this.p_registro_message.InnerText = "";

                bool esMail = Utilidades.EsMail(mail);

                if (resultNroPta)
                {
                    if (resultCI)
                    {
                        if (resultTel)
                        {
                            if (esMail)
                            {
                                bool mailUsado = elSis.MailYaUsado(mail, "");

                                if (!mailUsado)
                                {
                                    if (lenPass)
                                    {
                                        Usuario cliUsr = elSis.BuscarUsuarioPorUsername(usuario);

                                        if (cliUsr == null)
                                        {
                                            Usuario cli = elSis.BuscarCliente(this.txt_registro_CI.Text);

                                            if (cli == null)
                                            {
                                                elSis.AltaCliente(usuario, password, nombre, apellido, ci, telefono, calle, nroPuerta, CP, ciudad, pais, mail);
                                                Response.Redirect("~/Inicio.aspx?message=true");
                                            }
                                            else this.p_registro_message.InnerText = "Ya existe un cliente con la cédula de identidad ingresada";
                                        }
                                        else this.p_registro_message.InnerText = "El username elegido ya existe";
                                    }
                                    else this.p_registro_message.InnerText = "El password debe tener 6 o más caracteres";
                                }
                                else this.p_registro_message.InnerText = "El mail ingresado ya está registrado";
                            }
                            else this.p_registro_message.InnerText = "El mail debe estar en el formato correcto";
                        }
                        else this.p_registro_message.InnerText = "El teléfono sólo puede contener números";
                    }
                    else this.p_registro_message.InnerText = "El documento solo puede contener numeros";
                }
                else this.p_registro_message.InnerText = "El número de puerta tiene que contener solo números";
            }
            else this.p_registro_message.InnerText = "Todos los campos son necesarios";
        }

    }
}