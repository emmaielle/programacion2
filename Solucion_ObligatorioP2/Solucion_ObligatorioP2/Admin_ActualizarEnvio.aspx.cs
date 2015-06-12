using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Solucion_ObligatorioP2
{
    public partial class Admin_ActualizarEnvio : System.Web.UI.Page
    {
        Sistema elSis = Sistema.Instancia;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ddl_actualizarEnv_Oficinas.DataSource = elSis.TraerNrosDeOficinasPostales();
                ddl_actualizarEnv_Oficinas.DataBind();

                ddl_actualizarEnv_etapaEnv.DataSource = Enum.GetNames(EtapaEnvio.Etapas.EnOrigen.GetType());
                ddl_actualizarEnv_etapaEnv.DataBind();
            }

        }

        protected void btn_actualizarEnv_AgregarEtapa_Click(object sender, EventArgs e)
        {
            int nroEnvio;
            bool result = int.TryParse(txt_actualizarEnv_nroEnv.Text, out nroEnvio);

            DateTime fechaIngreso = calendar_actualizarEnv_fchIngreso.SelectedDate;
            
            int nroOficina;
            bool resultOfi = int.TryParse(ddl_actualizarEnv_Oficinas.SelectedValue, out nroOficina);
            OficinaPostal oficinaEntrante = elSis.BuscarOficinaXID(nroOficina);

            Envio envioDeseado = elSis.BuscarEnvio(nroEnvio);
            
            envioDeseado.AgregarEtapa(fechaIngreso,, oficinaEntrante, );
        }
    }
}