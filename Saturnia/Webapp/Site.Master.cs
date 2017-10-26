using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webapp
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] == null)
            {
               // Response.Redirect("~/WebForms/IniciarSesion.aspx");
            }
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("userId");
            Session.Remove("userName");
            Session.Remove("userRole");

            Response.Redirect("~/WebForms/IniciarSesion.aspx");
        }
    }
}