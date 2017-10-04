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
    public partial class ActualizarProyecto1 : System.Web.UI.Page
    {
        private ProjectBusiness projectBusiness;

        public ActualizarProyecto1()
        {
            this.projectBusiness = new ProjectBusiness();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {

                Project project = new Project();
                project.Id = Int32.Parse(Request.QueryString["id"]);
                project = this.projectBusiness.ShowProject(project);
                tbName.Text = project.Name;
                tbDescription.Text = project.Description;
                tbEstimatedHours.Text = project.EstimatedHours.ToString();

                //campos sobre fecha de inicio
                tbStartMonth.Text = project.StartDate.Month.ToString();
                tbStartDay.Text = project.StartDate.Day.ToString();
                tbStartYear.Text = project.StartDate.Year.ToString();

                //campos sobre fecha de finalizacion

                if (project.EndDate.ToString() != "01/01/0001 00:00:00")
                {

                }
                else
                {
                    tbEndMonth.Text = project.EndDate.Month.ToString();
                    tbEndDay.Text = project.EndDate.Day.ToString();
                    tbEndYear.Text = project.EndDate.Year.ToString();
                }
            }
            else
            {

            }
        }



        protected void btnUpdateProject_Click(object sender, EventArgs e)
        {
            Project project = new Project();
            project.Id = Int32.Parse(Request.QueryString["id"]);
            project.Name = tbName.Text;
            project.Description = tbDescription.Text;
            project.EstimatedHours = Int32.Parse(tbEstimatedHours.Text);



            DateTime start_date = DateTime.Parse(tbStartDay.Text + "/" + tbStartMonth.Text + "/" + tbStartYear.Text);

            //linea que falla 
            DateTime end_date = DateTime.Parse("01/01/0001 00:00:00");
            project.StartDate = start_date;

            project.EndDate = end_date;

            projectBusiness.UpdatePorject(project);

        }

    }
}