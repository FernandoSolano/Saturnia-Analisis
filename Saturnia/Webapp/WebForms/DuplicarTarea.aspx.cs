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
    public partial class DuplicarTarea : System.Web.UI.Page
    {
        private float registeredHours, allowedHours;
        private int ddl_hours_PreValue;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                registeredHours = 0;
                allowedHours = 0;
                ddl_hours_PreValue = 0;
            }
            User user = new User();
            if (Session["userId"] != null || Request.QueryString["TaskId"] != null)
            {
                user.Id = (int)Session["userId"];
                ProjectBusiness projectBusiness = new ProjectBusiness();
                CategoryBusiness categoryBusiness = new CategoryBusiness();
                TaskBusiness taskBusiness = new TaskBusiness();
                //Obtener proyectos para determinado usuario
                ddl_projects.DataSource = projectBusiness.GetProjectsByCollaborator(user);
                ddl_projects.DataTextField = "Name";
                ddl_projects.DataValueField = "Id";
                ddl_projects.DataBind();
                //Obtener lista de categorías
                ddl_categories.DataSource = categoryBusiness.SearchCategory(new Category());
                ddl_categories.DataTextField = "Name";
                ddl_categories.DataValueField = "Id";
                ddl_categories.DataBind();
                //Asignar valores de la tarea a los controles
                Task task = new Task();
                //TODO... Recibir id de tarea con un get
                //task.Id = Int32.Parse(Request.QueryString["TaskId"]);
                //*********************Pruebas*********************
                task.Id = 159;//Horas regulares
                //task.Id = 160;//Horas extra
                //*************************************************
                task = taskBusiness.ShowTask(task);
                ddl_projects.SelectedValue = task.Project.Id.ToString();
                ddl_categories.SelectedValue = task.Category.Id.ToString();
                rbl_hours_type.SelectedValue = Convert.ToInt32(task.ExtraHours).ToString();
                //Validar las horas y medias horas
                if (!Page.IsPostBack)
                    registeredHours = taskBusiness.GetHoursByDateAndCollaborator(task).Hours;
                GetAllowedHours();
                if (Page.IsPostBack)
                    ddl_hours_PreValue = Int32.Parse(ddl_hours.SelectedValue);
                LoadHoursDropDownList();
                ddl_hours.SelectedValue = ddl_hours_PreValue + "";
                LoadMinutesDropDownList();
                tb_description.Text = task.Description;
                cld_selected_date.SelectedDate = task.Date;
                cld_selected_date.VisibleDate = task.Date;
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            Task task = new Task();
            task.Project.Id = Int32.Parse(ddl_projects.SelectedValue);
            task.Category.Id = Int32.Parse(ddl_categories.SelectedValue);
            task.ExtraHours = bool.Parse(rbl_hours_type.SelectedValue);
            task.Description = tb_description.Text;
            task.Date = cld_selected_date.SelectedDate;
        }

        protected void ddl_hours_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMinutesDropDownList();
        }

        private void GetAllowedHours()
        {
            if (rbl_hours_type.SelectedValue == "0")
            {
                allowedHours = 8 - registeredHours;
            }
            else
            {
                allowedHours = 16 - registeredHours;
            }
        }

        private void LoadHoursDropDownList()
        {
            ddl_hours.Items.Clear();
            for (int i = 0; i <= allowedHours; i++)
            {
                ddl_hours.Items.Add(new ListItem(i + "", i + ""));
            }
        }

        protected void cld_selected_date_SelectionChanged(object sender, EventArgs e)
        {
            TaskBusiness taskBusiness = new TaskBusiness();
            Task task = new Task();
            task.Collaborator.Id = (int)Session["userId"];
            task.Date = cld_selected_date.SelectedDate;
            task.ExtraHours = Convert.ToBoolean(Int32.Parse(rbl_hours_type.SelectedValue));
            registeredHours = taskBusiness.GetHoursByDateAndCollaborator(task).Hours;
            ddl_hours_PreValue = Int32.Parse(ddl_hours.SelectedValue);
        }

        private void LoadMinutesDropDownList()
        {
            ddl_minutes.Items.Clear();
            if (allowedHours == 0.5)
            {
                ddl_minutes.Items.Add(new ListItem("30", "1"));
            }
            else if (allowedHours == 1 && ddl_hours.SelectedValue == "1")
            {
                ddl_minutes.Items.Add(new ListItem("0", "0"));
            }
            else if (allowedHours == 0)
            {
                ddl_minutes.Items.Add(new ListItem("0", "0"));
            }
            else if ((ddl_hours.SelectedValue == "8" && rbl_hours_type.SelectedValue == "0") || (ddl_hours.SelectedValue == "16" && rbl_hours_type.SelectedValue == "1"))
            {
                ddl_minutes.Items.Add(new ListItem("0", "0"));
            }
            else
            {
                ddl_minutes.Items.Add(new ListItem("0", "0"));
                ddl_minutes.Items.Add(new ListItem("30", "1"));
            }
        }
    }
}