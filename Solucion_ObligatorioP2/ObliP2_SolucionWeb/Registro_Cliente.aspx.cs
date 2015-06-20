using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Solucion_ObligatorioP2
{
    public partial class Registro_Usuario : System.Web.UI.Page
    {
        Sistema elSis = Sistema.Instancia;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                p_registro_message.InnerText = "";
            }

        }
        
        protected void link_registro_volver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio.aspx");
        }

        protected void btn_registro_registrar_Click1(object sender, EventArgs e)
        {
            string ci = txt_registro_CI.Text;
            string nombre = txt_registro_nombre.Text;
            string apellido = txt_registro_Apellido.Text;
            string telefono = txt_registro_tel.Text;
            string pais = txt_registro_Pais.Text;
            string ciudad = txt_registro_ciudad.Text;
            string CP = txt_registro_CP.Text;
            string calle = txt_registro_Calle.Text;
            string nroPuerta = txt_nroPt_registro.Text;
            string usuario = txt_registro_Usuario.Text;
            string password = txt_registro_passwd.Text;
            string mail = txt_registro_mail.Text;


            if (!string.IsNullOrWhiteSpace(ci) && !string.IsNullOrWhiteSpace(nombre) && !string.IsNullOrWhiteSpace(apellido)
                && !string.IsNullOrWhiteSpace(telefono) && !string.IsNullOrWhiteSpace(pais) && !string.IsNullOrWhiteSpace(ciudad)
                && !string.IsNullOrWhiteSpace(CP) && !string.IsNullOrWhiteSpace(calle) && !string.IsNullOrWhiteSpace(nroPuerta)
                && !string.IsNullOrWhiteSpace(usuario) && !string.IsNullOrWhiteSpace(password) && !string.IsNullOrWhiteSpace(mail))
            {
                bool resultNroPta = elSis.ChequearEsSoloNumero(nroPuerta);
                bool resultTel = elSis.ChequearEsSoloNumero(telefono);
                bool resultCI = elSis.ChequearEsSoloNumero(ci);

                bool lenPass = false;
                if (password.Length >= 6) lenPass = true;
                p_registro_message.InnerText = "";

                bool esMail = elSis.EsMail(mail);

                if (resultNroPta)
                {
                    if (resultCI)
                    {
                        if (resultTel)
                        {
                            if (esMail)
                            {
                                if (lenPass)
                                {
                                    Usuario cliUsr = elSis.BuscarUsuarioPorUsername(usuario);

                                    if (cliUsr == null)
                                    {
                                        Usuario cli = elSis.BuscarCliente(txt_registro_CI.Text);

                                        if (cli == null)
                                        {
                                            elSis.AltaCliente(usuario, password, nombre, apellido, ci, telefono, calle, nroPuerta, CP, ciudad, pais, mail);
                                            Response.Redirect("~/Inicio.aspx?message=true");
                                        }
                                        else p_registro_message.InnerText = "Ya existe un cliente con la cédula de identidad ingresada";
                                    }
                                    else p_registro_message.InnerText = "El username elegido ya existe";
                                }
                                else p_registro_message.InnerText = "El password debe tener 6 o más caracteres";
                            }
                            else p_registro_message.InnerText = "El mail debe estar en el formato correcto";
                        }
                        else p_registro_message.InnerText = "El teléfono sólo puede contener números";
                    }
                    else p_registro_message.InnerText = "El documento solo puede contener numeros";
                }
                else p_registro_message.InnerText = "El número de puerta tiene que contener solo números";
            }
            else p_registro_message.InnerText = "Todos los campos son necesarios";
        }


    }
}