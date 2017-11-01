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
    }
}