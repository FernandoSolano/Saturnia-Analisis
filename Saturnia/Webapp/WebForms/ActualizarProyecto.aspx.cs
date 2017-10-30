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
    public partial class ActualizarProyecto1 : System.Web.UI.Page
    {
        private ProjectBusiness projectBusiness;
 
        public ActualizarProyecto1()
        {
            this.projectBusiness = new ProjectBusiness();
        }

        protected void Page_Load(object sender, EventArgs e)
        {


            if (Page.IsPostBack == false)
            {

                if (Request.QueryString["id"] != null)
                {

                    Project project = new Project();
                    project.Id = Int32.Parse(Request.QueryString["id"]);
                    project = this.projectBusiness.ShowProject(project);
                    tbName.Text = project.Name;
                    tbDescription.Text = project.Description;
                    tbEstimatedHours.Text = project.EstimatedHours.ToString();

                    CdStartDate.SelectedDate = DateTime.Parse(project.StartDate.ToString());
                    CdStartDate.VisibleDate = DateTime.Parse(project.StartDate.ToString());

                    if (project.EndDate.ToString() != "01/01/01 00:00:00")
                    {
                        CdEndDate.SelectedDate = DateTime.Parse(project.EndDate.ToString());
                        CdEndDate.VisibleDate = DateTime.Parse(project.EndDate.ToString());
                    }
                    else {
                        lbEndDateError.Visible = true;
                        lbEndDateError.Text="El proyecto no cuenta con una fecha de finalizacíon";
                    }

                }
                else
                {

                }
            }
        }



        protected void btnUpdateProject_Click(object sender, EventArgs e)
        {
            Project project = new Project();
            project.Id = Int32.Parse(Request.QueryString["id"]);

            project.Name = tbName.Text;
            project.Description = tbDescription.Text;
            project.EstimatedHours = Int32.Parse(tbEstimatedHours.Text);
            
            project.StartDate = DateTime.Parse(CdStartDate.SelectedDate.ToString());
            project.EndDate = DateTime.Parse(CdEndDate.SelectedDate.ToString());
            projectBusiness.UpdateProject(project);
            Response.Write("<script>alert('Actualización exitosa.');</script>");
        }


    }
}