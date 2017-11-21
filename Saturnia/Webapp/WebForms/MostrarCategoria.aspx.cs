using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Core.Business;
using Core.Domain;

namespace Webapp.WebForms
{
    public partial class MostrarCategoria : System.Web.UI.Page
    {
        private CategoryBusiness categoryBusiness;

        public MostrarCategoria()
        {
            this.categoryBusiness = new CategoryBusiness();
        }

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
            if (Request.QueryString["category"] != null)
            {
                Category category = new Category();
                category.Id = Int32.Parse(Request.QueryString["category"]);
                category = this.categoryBusiness.ShowCategory(category);

                this.lblName.Text = category.Name;
                
                this.lblDescriptionContent.Text = category.Description;

                
                this.LinkUpdateCategory.NavigateUrl = "./ActualizarCategoria.aspx?id=" + category.Id;

            }
            else
            {

            }
        }

        protected void LinkButon_Eliminar_Categoria_Click(object sender, EventArgs e)
        {
            try
            {
                CategoryBusiness projectBusiness = new CategoryBusiness();
                Category category = new Category();
                category.Id = Int32.Parse(Request.QueryString["category"]);
                category = projectBusiness.ShowCategory(category);
                projectBusiness.DeleteCategory(category);
                Response.Write("<script>alert('La categoría ha sido eliminada con éxito');window.location.href = 'BuscarCategoria.aspx';</script>");

            }//try
            catch
            {
                Response.Write("<script>alert('Ocurrió un problema, la categoría no se pudo eliminar');window.location.href = 'BuscarCategoria.aspx';</script>");
            }//catch
        }
    }
}