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
    public partial class AsociarUsuario : System.Web.UI.Page
    {

        private UserBusiness userBusiness;
        private ProjectBusiness projectBusiness;
        private int currentProject;
        private int currentUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            if( ( Request.QueryString["user"] != null ) && ( Request.QueryString["project"] != null ) )
            {
                //Si alguien ingresara a mano texto en las variables, el try catch redireccionará a buscar proyecto.
                this.userBusiness = new UserBusiness();
                this.projectBusiness = new ProjectBusiness();

                try {
                    this.currentProject = Int32.Parse(Request.QueryString["project"]);
                    this.currentUser = Int32.Parse(Request.QueryString["user"]);

                    Project project = new Project();
                    User user = new User();

                    project.Id = this.currentProject;
                    user.Id = this.currentUser;

                    project = this.projectBusiness.ShowProject(project);
                    user = this.userBusiness.ShowUser(user);

                    this.txtProjectName.Text = project.Name;
                    this.txtUserName.Text = user.FirstName + " " + user.LastName;

                } catch
                {
                    Response.Redirect("./SearchCategory.aspx");
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("./SearchProject.aspx");
        }

        protected void btnAsign_Click(object sender, EventArgs e)
        {

        }

        protected void btnSearchProject_Click(object sender, EventArgs e)
        {
            Response.Redirect("./SearchProject.aspx");
        }

        protected void btnSearchUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("./AsignarUsuario.aspx?project=" + this.currentProject);
        }
    }
}