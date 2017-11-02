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
                    this.MasterPageFile = "~/SiteCollaborator.master";
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] != null)
            {
                taskBusiness = new TaskBusiness();
                collaboratorTasks = new List<Task>();
                task = new Task();
                task.Collaborator.Id = (int)(Session["userId"]);
                collaboratorTasks = taskBusiness.GetTaskByCollaborator(task);
                GridViewTasks.DataSource = collaboratorTasks;
                GridViewTasks.DataBind();
            }
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForms/CrearTarea.aspx");
        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewTasks.PageIndex = e.NewPageIndex;
            GridViewTasks.DataBind();
        }
    }
}