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

        private TaskBusiness taskBusiness;
        private CategoryBusiness categoryBusiness;
        private ProjectBusiness projectBusiness;

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
            DdlCategory.DataSource = categories;
            DdlCategory.DataValueField = "Id";
            DdlCategory.DataTextField = "Name";
            DdlCategory.DataBind();

            DdlCategorySoT.DataSource = categories;
            DdlCategorySoT.DataValueField = "Id";
            DdlCategorySoT.DataTextField = "Name";
            DdlCategorySoT.DataBind();
        }

        public void setProjectsDropDownList()
        {
            User user = new User();
            user.Id = (int)Session["userId"];
            List<Project> collaboratorProjects = projectBusiness.GetProjectsByCollaborator(user);
            DdlProject.DataSource = collaboratorProjects;
            DdlProjectSoT.DataSource = collaboratorProjects;
            if (collaboratorProjects.Count <= 0)
            {
                Project project = new Project();
                project.Name = "No tiene proyectos";
                collaboratorProjects.Add(project);
                DdlProject.Enabled = false;
                DdlProjectSoT.Enabled = false;
                BtnAdd.Enabled = false;
                BtnAddSoT.Enabled = false;
            }
            DdlProject.DataValueField = "Id";
            DdlProject.DataTextField = "Name";
            DdlProjectSoT.DataValueField = "Id";
            DdlProjectSoT.DataTextField = "Name";
            DdlProject.DataBind();
            DdlProjectSoT.DataBind();
        }

        public void resetData()
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

        protected void AddDateToList(object sender, EventArgs e)
        {

        }

    }
}