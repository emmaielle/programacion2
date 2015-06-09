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
            Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.WebForms;
            ScriptResourceDefinition jQuery = new ScriptResourceDefinition();
            jQuery.Path = "~/scripts/jquery-2.1.3.min.js";
            jQuery.DebugPath = "~/scripts/jquery-2.1.3.js";
            jQuery.CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-2.1.3.min.js";
            jQuery.CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-2.1.3.js";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", jQuery);

            if (this.IsPostBack)
            {
                p_registro_messageServer.InnerText = "";
            }

        }

        protected void btn_registro_registrar_Click(object sender, EventArgs e)
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

            if (ci != "" && nombre != "" && apellido != "" && telefono != "" && pais != "" && ciudad != "" &&
                CP != "" && calle != "" && nroPuerta != "" && usuario != "" && password != "")
            {
                bool resultNroPta = elSis.ChequearEsSoloNumero(nroPuerta);
                bool resultTel = elSis.ChequearEsSoloNumero(telefono);

                bool resultCI = elSis.ChequearEsFormatoCedula(ci); // <--- no necesariamente hay solo cedulas de Identidad. Otros formatos?

                bool lenPass = false;
                if (password.Length >= 6) lenPass = true;

                if (resultNroPta)
                {
                    if (resultCI)
                    {
                        if (resultTel)
                        {
                            if (lenPass)
                            {
                                Usuario cli = elSis.BuscarCliente(txt_registro_CI.Text);

                                if (cli == null)
                                {
                                    elSis.AltaCliente(usuario, password, nombre, apellido, ci, telefono, calle, nroPuerta, CP, ciudad, pais);
                                    Response.Redirect("~/Inicio.aspx?message=true");
                                }
                                else p_registro_messageServer.InnerText = "Ya existe un cliente con la cédula de identidad ingresada";
                            }
                            else p_registro_messageServer.InnerText = "El password debe tener 6 o más caracteres";
                        }
                        else p_registro_messageServer.InnerText = "El teléfono sólo puede contener números";
                    }
                    else p_registro_messageServer.InnerText = "La cédula de identidad no tiene el formato adecuado (1234567-8)";
                }
                else p_registro_messageServer.InnerText = "El número de puerta debe contener solo números";
            }                   
        }

        protected void link_registro_volver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio.aspx");
        }


    }
}