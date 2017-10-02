﻿using System;
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

                this.lblName.Text = project.Name;
                if (project.State) { 
                    this.lblStateDescription.Text = "Activo";
                } else
                {
                    this.lblStateDescription.Text = "Inactivo";

                }
                this.lblDescriptionContent.Text = project.Description;
                this.lblEstimatedHoursContent.Text = (project.EstimatedHours).ToString();
                this.lblStartDateContent.Text = project.StartDate.ToString();
                if (project.EndDate.ToString() != "01/01/0001 00:00:00")
                {
                    this.lblEndDateContent.Text = project.EndDate.ToString();
                } else
                {
                    this.lblEndDateContent.Text = "Sin fecha de fin";
                }

                //**********************************KRISTELL**********************************//
                //Compañera, aqui puede poner lo que necesite del LinkButton con id btnDelete
                //this.linkUpdate.NavigateUrl = "./ActualizarProyecto.aspx?id=" + project.Id;

            }
            else
            {

            }
        }
    }
}