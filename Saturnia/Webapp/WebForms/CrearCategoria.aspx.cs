using Core.Business;
using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webapp.WebForms
{
    public partial class ActualizarCategoria : System.Web.UI.Page
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
        }


        protected void btnCreateOnClick(object sender, EventArgs e)
        {
            Category category = new Category();
            category.Name = tb_name.Text;
            category.Description = tb_description.Text;
            CategoryBusiness categoryBusiness = new CategoryBusiness();
            category = categoryBusiness.AddCategory(category);
            Response.Write("<script>alert('La categoría ha sido creada con éxito');window.location.href = 'BuscarCategoria.aspx';</script>");
        }

        protected void btnCancelOnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForms/BuscarCategoria.aspx");
        }
    }
}