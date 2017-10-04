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
    public partial class ShowProject : System.Web.UI.Page
    {
        private ProjectBusiness projectBusiness;

        public ShowProject()
        {
            this.projectBusiness = new ProjectBusiness();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["project"] != null)
            {
                Project project = new Project();
                project.Id = Int32.Parse(Request.QueryString["project"]);
                project = this.projectBusiness.ShowProject(project);
                this.LinkUpdateProject.NavigateUrl = "./ActualizarProyecto.aspx?id=" + project.Id;

                this.lblName.Text = project.Name;
                if (project.State) { 
                    this.lblStateDescription.Text = "Activo";
                    this.linkButtonChangeStatus.Text = "Deshabilitar";
                } else
                {
                    this.lblStateDescription.Text = "Inactivo";
                    this.linkButtonChangeStatus.Text = "Habilitar";

                }
                this.lblDescriptionContent.Text = project.Description;
                this.lblEstimatedHoursContent.Text = (project.EstimatedHours).ToString();
                this.lblStartDateContent.Text = project.StartDate.ToString();
                if (project.EndDate.ToString() != "1/1/0001 00:00:00")
                {
                    this.lblEndDateContent.Text = project.EndDate.ToString();
                } else
                {
                    this.lblEndDateContent.Text = "Sin fecha de fin";
                }
            }
            else
            {

            }
        }

        protected void LinkButon_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ProjectBusiness projectBusiness = new ProjectBusiness();
                Project project = new Project();
                project.Id = Int32.Parse(Request.QueryString["project"]);
                project = projectBusiness.ShowProject(project);
                projectBusiness.DeleteProject(project);

                Response.Write("<script>alert('El proyecto ha sido eliminado con éxito');window.location.href = 'SearchProject.aspx';</script>");
            

            }//try
            catch
            {
                Response.Write("<script>alert('Ocurrió un problema, el proyecto no se pudo eliminar');window.location.href = 'SearchProject.aspx';</script>");
            }//catch
        }

        protected void LinkButonChangeStatus(object sender, EventArgs e)
        {
            Project project = new Project();
            project.Id = Int32.Parse(Request.QueryString["project"]);
            projectBusiness.ChangeProjectStatus(project);
            Page_Load(sender, e);

        }
    }
}