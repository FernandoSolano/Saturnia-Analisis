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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                lbl_name.Text = "";
                lbl_description.Text = "";
            }
        }


        protected void btnCreateOnClick(object sender, EventArgs e)
        {
            Category category = new Category();
            category.Name = lbl_name.Text;
            category.Description = lbl_description.Text;
            CategoryBusiness categoryBusiness = new CategoryBusiness();
            category = categoryBusiness.AddCategory(category);
            Response.Redirect("~/CrearCategoria.aspx");
        }
    }
}