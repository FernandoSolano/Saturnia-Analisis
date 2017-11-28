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
    public partial class ActualizarProyecto : System.Web.UI.Page
    {

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["userRole"] != null)
            {
                if ((int)Session["userRole"] == 1)
                {
                    this.MasterPageFile = "~/Site.master";
                }
                else if ((int)Session["userRole"] == 2)
                {
                    Response.Redirect("./IndexColaborador.aspx");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateOnClick(object sender, EventArgs e)
        {
            Project project = new Project();
            project.Name = tb_name.Text;
            project.Description = tb_description.Text;
            project.EstimatedHours = Int32.Parse(tb_estimated_hours.Text);
            ProjectBusiness projectBusiness = new ProjectBusiness();
            project = projectBusiness.AddProject(project);
            Response.Write("<script>alert('El proyecto ha sido creado con éxito');window.location.href = 'BuscarProyecto.aspx';</script>");
        }

        protected void btnCancelOnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForms/BuscarProyecto.aspx");
        }
    }
}