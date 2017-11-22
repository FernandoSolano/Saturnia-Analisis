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

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["userRole"] != null)
            {
                if ((int)Session["userRole"] == 1)
                {
                    this.MasterPageFile = "~/Site.master";
                }
                else if ((int)Session["userRole"] == 2)
                {
                    this.MasterPageFile = "~/SiteCollaborator.master";
                }
            }
        }

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