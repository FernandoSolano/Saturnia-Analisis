using Core.Data;
using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webapp.WebForms
{
    public partial class EliminarCategoria : System.Web.UI.Page
    {
        private static int id = 3;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                CategoryData categoryData = new CategoryData();
                //id = Int32.Parse(Request.QueryString["id"]);

                Category category = new Category();

                category = categoryData.GetCategory(id);

                LB_nombre.Text = category.Name;
                LB_descripcion.Text = category.Description;


            }//IsPostBack
        }//Page_Load

        protected void BT_aceptar_Click(object sender, EventArgs e)
        {
            CategoryData categoryData = new CategoryData();
            Category category = new Category();
            category = categoryData.GetCategory(id);
            //categoryData.DeleteCategory(category);
            Response.Write("<script>alert('La categoría ha sido eliminada con éxito');window.location.href = '/About.aspx';</script>");

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Response.Redirect("BuscarCategorias");
        }
    }
}