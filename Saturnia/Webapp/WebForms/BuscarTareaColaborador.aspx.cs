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
    public partial class BuscarTareaColaborador : System.Web.UI.Page
    {
        TaskBusiness taskBusiness;
        List<Task> collaboratorTasks;
        Task task;
        protected void Page_Load(object sender, EventArgs e)
        {
            taskBusiness = new TaskBusiness();
            collaboratorTasks = new List<Task>();
            task = new Task();
            task.Collaborator.Id = (int)(Session["userId"]);
            if (!Page.IsPostBack)
            {
                LblCollaboratorName.Text += Session["userName"].ToString();
            }

        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            collaboratorTasks = taskBusiness.GetTaskByCollaborator(task);
            GridViewTasks.DataSource = collaboratorTasks;
            GridViewTasks.DataBind();
        }

        protected void GridViewTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

    
        protected void GridViewTask_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewTasks.Rows[index];
               
                Response.Redirect("~/WebForms/ActualizarTarea.aspx?id=" + row.Cells[0].Text);
            }

            if (e.CommandName == "Editar2")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewTasks.Rows[index];

                Response.Redirect("~/WebForms/ActualizarTarea.aspx?id=" + row.Cells[0].Text);
            }
        }
    }
}