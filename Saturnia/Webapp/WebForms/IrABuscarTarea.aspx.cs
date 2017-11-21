using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webapp.WebForms
{
    public partial class IrABuscarTarea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userRole"] == null)
            {
                Response.Redirect("~/WebForms/IniciarSesion.aspx");
            }
            else if (Session["userRole"].ToString() == "1")
            {

                Response.Redirect("~/WebForms/BuscarTarea.aspx");
            }
            else if (Session["userRole"].ToString() == "2")
            {
                Response.Redirect("~/WebForms/BuscarTareaColaborador.aspx");
            }
        }
    }
}