using Core.Data;
using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webapp.WebForms
{
    public partial class EliminarProyecto : System.Web.UI.Page
    {
        private static int id = 5;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page.IsPostBack == false)
            {
                ProjectData projectData = new ProjectData();
                //id = Int32.Parse(Request.QueryString["id"]);

                Project project = new Project();

                project = projectData.GetProject(id);

                LB_nombre.Text = project.Name;
                LB_descripcion.Text = project.Description;
                LB_fecha.Text = project.StartDate.ToString();


            }//IsPostBack

        }//Page_Load

        protected void BT_cancelar_Click(object sender, EventArgs e)
        {
           // Response.Redirect("BuscarProyectos");
        }

        protected void BT_aceptar_Click(object sender, EventArgs e)
        {
            ProjectData projectData = new ProjectData();
            Project project = new Project();
            project = projectData.GetProject(id);
            projectData.DeleteProject(project);
            Response.Write("<script>alert('El projecto ha sido eliminado con éxito');window.location.href = '/About.aspx';</script>");
            
        }
    }
}