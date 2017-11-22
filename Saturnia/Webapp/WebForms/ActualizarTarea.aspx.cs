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
        private CategoryBusiness categoryBusiness;
        private ProjectBusiness projectBusiness;

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
            
            if (Page.IsPostBack == false)
            {
                if (Request.QueryString["id"] != null)
                {
                    ShowTaskData();
                    ConfirmationMenu.Visible = false;
                    
                }
            }
        }

        private void ShowTaskData()
        {
            Task task = new Task();
            task.Id= Int32.Parse(Request.QueryString["id"]);
            taskBusiness = new TaskBusiness();

            task = taskBusiness.ShowTask(task);

            tbDescription.Text = task.Description;
            
            int horas= (int)Math.Floor(task.Hours);
            tbHours.Text = horas.ToString();
            if (task.ExtraHours==false) {
                rblList.SelectedValue = "0";
            } else {
                rblList.SelectedValue = "1";
            }
            if (horas - task.Hours == 0)
            {
                ddlMinutes.Items.FindByValue("00").Selected = true;
            }
            else {
                ddlMinutes.Items.FindByValue("30").Selected = true;
            }
      
            CdDate.SelectedDate = DateTime.Parse(task.Date.ToString());
            CdDate.VisibleDate = DateTime.Parse(task.Date.ToString());

 
        }

       
        protected void btnUpdateTask_Click(object sender, EventArgs e)
        {
            lbMessage.Visible = false;
            if (Int32.Parse(tbHours.Text) >= 9 && rblList.SelectedValue == "0")
            {
                lbHours.Text = "Las horas regulares tienen un maximo de 8 horas.";
                lbHours.Visible = true;
            }
            else if (Int32.Parse(tbHours.Text) >= 17 && rblList.SelectedValue == "1")
            {
                lbHours.Text = "Las horas extra tienen un maximo de 16 horas.";
                lbHours.Visible = true;
            }
            else if (Int32.Parse(tbHours.Text) <0) {
                lbHours.Text = "Ingrese un campo valido";
                lbHours.Visible = true;
            }
            else {
                DefaultMenu.Visible = false;
                ConfirmationMenu.Visible = true;
                lbHours.Visible = false;
                BlockEditOptions();
            }
            
        }

        private void BlockEditOptions()
        {
            CdDate.Enabled = false;
            ddlMinutes.Enabled = false;
            tbDescription.Enabled = false;
            tbHours.Enabled = false;
            rblList.Enabled = false;
        }

        private void UnlockEditOptions()
        {
            CdDate.Enabled = true;
            ddlMinutes.Enabled = true;
            tbDescription.Enabled = true;
            tbHours.Enabled = true;
            rblList.Enabled = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForms/BuscarTareaColaborador.aspx");
        }


        protected void btnUpdateTaskConfirmation_Click(object sender, EventArgs e)
        {
            Task task = new Task();

            task.Id = Int32.Parse(Request.QueryString["id"]);
            task.Description = tbDescription.Text;
   
            task.Hours = float.Parse(tbHours.Text + "." + ddlMinutes.SelectedValue.ToString()) ;
            task.Date = DateTime.Parse(CdDate.SelectedDate.ToString());
            if (rblList.SelectedValue=="0")
            {
                task.ExtraHours = false;
            }
            else
            {
                task.ExtraHours = true;
            }

            taskBusiness = new TaskBusiness();
            taskBusiness.UpdateTask(task);

            DefaultMenu.Visible = true;
            ConfirmationMenu.Visible = false;
            lbMessage.Visible = true;
            UnlockEditOptions();

        }

        protected void btnCancelUpdate_Click(object sender, EventArgs e)
        {
            DefaultMenu.Visible = true;
            ConfirmationMenu.Visible = false;
        }
    }
}