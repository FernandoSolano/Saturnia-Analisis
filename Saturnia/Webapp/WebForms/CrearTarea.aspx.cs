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
    public partial class CrearTarea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TaskBusiness taskBusiness = new TaskBusiness();
            CategoryBusiness categoryBusiness = new CategoryBusiness();
            ProjectBusiness projectBusiness = new ProjectBusiness();

            Category category = new Category();
            List<Category> categories = categoryBusiness.SearchCategory(category);
            DdlCategory.DataSource = categories;
            DdlCategory.DataValueField = "Id";
            DdlCategory.DataTextField = "Name";
            DdlCategory.DataBind();

            DdlCategorySoT.DataSource = categories;
            DdlCategorySoT.DataValueField = "Id";
            DdlCategorySoT.DataTextField = "Name";
            DdlCategorySoT.DataBind();

            Project project = new Project();

           
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {

        }

        protected void BtnSetData_Click(object sender, EventArgs e)
        {

        }
       
    }
}