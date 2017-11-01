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
    public partial class ActualizarTarea : System.Web.UI.Page
    {
      
        private TaskBusiness taskBusiness;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                if (Request.QueryString["id"] != null)
                {
                    loadTaskData();
                }
            }
        }

        private void loadTaskData()
        {
            Task task = new Task();
            task.Id= Int32.Parse(Request.QueryString["id"]);
            taskBusiness = new TaskBusiness();
            task = taskBusiness.ShowTask(task);

            tbDescription.Text = task.Description;
            tbHours.Text = task.Hours.ToString();
            if (task.ExtraHours==false) {
                rdHours.Checked = true;
                rdExtrasHours.Enabled = false;
            } else {
                rdHours.Enabled = false;
                rdExtrasHours.Checked = true;
            }
            CdDate.SelectedDate = DateTime.Parse(task.Date.ToString());
            CdDate.VisibleDate = DateTime.Parse(task.Date.ToString());



        }

        protected void btnUpdateTask_Click(object sender, EventArgs e)
        {
            Task task = new Task();

            task.Id = Int32.Parse(Request.QueryString["id"]);
            task.Description = tbDescription.Text;
            task.Hours = Int32.Parse(tbHours.Text);
            task.Date = DateTime.Parse(CdDate.SelectedDate.ToString());
            if (rdHours.Checked==true) {
                task.ExtraHours = false;
            }
            else {
                task.ExtraHours = true;
            }

            taskBusiness = new TaskBusiness();
            taskBusiness.UpdateTask(task);

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            
        }

    }
}