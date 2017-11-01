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
    public partial class ActualizarTarea : System.Web.UI.Page
    {
        private CategoryBusiness categoryBusiness;
        private ProjectBusiness projectBusiness;
        private TaskBusiness taskBusiness;

        protected void Page_Load(object sender, EventArgs e)
        {
            taskBusiness = new TaskBusiness();
            categoryBusiness = new CategoryBusiness();
            projectBusiness = new ProjectBusiness();

            setCategoryDropDownList();
            setProjectsDropDownList();
        }

        public void setCategoryDropDownList()
        {
            Category category = new Category();
            List<Category> categories = categoryBusiness.SearchCategory(category);
            ddlCategory.DataSource = categories;
            ddlCategory.DataValueField = "Id";
            ddlCategory.DataTextField = "Name";
            ddlCategory.DataBind();

            ddlCategory.DataSource = categories;
            ddlCategory.DataValueField = "Id";
            ddlCategory.DataTextField = "Name";
            ddlCategory.DataBind();
        }

        public void setProjectsDropDownList()
        {
            User user = new User();
            //user.userSearch();

            List<Project> collaboratorProjects = projectBusiness.GetProjectsByCollaborator(user);
            ddlProject.DataSource = collaboratorProjects;

            if (collaboratorProjects.Count <= 0)
            {


            }
            ddlProject.DataValueField = "Id";
            ddlProject.DataTextField = "Name";

            ddlProject.DataBind();

        }

        protected void btnUpdateTask_Click(object sender, EventArgs e)
        {


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {


        }

    }
}