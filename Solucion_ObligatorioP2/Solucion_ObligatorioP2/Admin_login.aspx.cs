using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Solucion_ObligatorioP2
{
    public partial class Admin_login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.WebForms;
            ScriptResourceDefinition jQuery = new ScriptResourceDefinition();
            jQuery.Path = "~/scripts/jquery-2.1.3.min.js";
            jQuery.DebugPath = "~/scripts/jquery-2.1.3.js";
            jQuery.CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-2.1.3.min.js";
            jQuery.CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-2.1.3.js";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", jQuery);
        }
    }
}