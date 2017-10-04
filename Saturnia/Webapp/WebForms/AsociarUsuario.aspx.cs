﻿using Core.Business;
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
            Boolean leader = this.cbLeader.Checked, success;
            Project project = new Project();
            User user = new User();

            project.Id = this.currentProject;
            user.Id = this.currentUser;

            success = this.userBusiness.AssignCollaboratorToProject(user, project, leader);

            if (success)
            {
                this.lblResponse.Text = "Asignación completada con éxito.";
                this.lblResponse.ForeColor = System.Drawing.Color.Green;
            }
            else {
                this.lblResponse.Text = "Hubo un error en la asignación del usuario, quizá este ya estuviese asigando.";
                this.lblResponse.ForeColor = System.Drawing.Color.Red;
            }

            this.lblResponse.Visible = true;
            this.lblMessage.Visible = true;
            this.btnAceptar.Visible = true;
            this.btnReturn.Visible = true;

        }

        protected void btnSearchProject_Click(object sender, EventArgs e)
        {
            Response.Redirect("./SearchProject.aspx");
        }

        protected void btnSearchUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("./AsignarUsuario.aspx?project=" + this.currentProject);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("./SearchCategory.aspx");
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./SearchProject.aspx");
        }
    }
}