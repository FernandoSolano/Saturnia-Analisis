using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webapp.WebForms
{
    public partial class IndexAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"] == null)
                Response.Redirect("~/WebForms/IniciarSesion.aspx");
            else
                Label1.Text = Session["userName"].ToString();
            
        }
    }
}