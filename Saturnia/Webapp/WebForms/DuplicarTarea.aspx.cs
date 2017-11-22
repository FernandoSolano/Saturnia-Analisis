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

        private ProjectBusiness projectBusiness;
        private CategoryBusiness categoryBusiness;
        private TaskBusiness taskBusiness;
        private User user;
        private Task task;
        private float registeredHours, allowedHours;
        private int ddl_hours_PreValue;

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
            if (Session["userId"] != null || Request.QueryString["id"] != null)
            {
                if (!Page.IsPostBack)
                {
                    user = new User();
                    task = new Task();
                    taskBusiness = new TaskBusiness();
                    projectBusiness = new ProjectBusiness();
                    categoryBusiness = new CategoryBusiness();
                    registeredHours = 0;
                    allowedHours = 0;
                    ddl_hours_PreValue = 0;
                    user.Id = (int)Session["userId"];

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
                    //Recibir id de tarea con un get
                    task.Id = Int32.Parse(Request.QueryString["id"]);
                    task = taskBusiness.ShowTask(task);
                    //Asignar valores de la tarea a los controles
                    ddl_projects.SelectedValue = task.Project.Id.ToString();
                    ddl_categories.SelectedValue = task.Category.Id.ToString();
                    //rbl_hours_type.SelectedValue = Convert.ToInt32(registeredTask.ExtraHours).ToString();//***********Al remover esta línea el rbl ejecuta su evento correctamente
                    tb_description.Text = task.Description;
                    cld_selected_date.SelectedDate = task.Date;
                    cld_selected_date.VisibleDate = task.Date;
                    registeredHours = taskBusiness.GetHoursByDateAndCollaborator(task).Hours;
                    GetAllowedHours();
                    LoadHoursDropDownList();
                    ddl_hours.SelectedValue = ddl_hours_PreValue + "";
                    LoadMinutesDropDownList();
                }
                if (Page.IsPostBack)
                    ddl_hours_PreValue = Int32.Parse(ddl_hours.SelectedValue);
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (rbl_hours_type.SelectedValue == "0" || rbl_hours_type.SelectedValue == "1")
            {
                if (ddl_hours.SelectedValue != "0" || ddl_minutes.SelectedValue != "0")
                {
                    taskBusiness = new TaskBusiness();
                    task = new Task();
                    task.Project.Id = Int32.Parse(ddl_projects.SelectedValue);
                    task.Category.Id = Int32.Parse(ddl_categories.SelectedValue);
                    task.Collaborator.Id = (int)Session["userId"];
                    task.ExtraHours = (rbl_hours_type.SelectedValue == "0") ? (false) : (true);
                    task.Description = tb_description.Text;
                    task.Date = cld_selected_date.SelectedDate;
                    float selectedHours = 0;
                    selectedHours = Int32.Parse(ddl_hours.SelectedValue);
                    if (ddl_minutes.SelectedValue == "1")
                    {
                        selectedHours += (float)0.5;
                    }
                    task.Hours = selectedHours;
                    taskBusiness.AddTask(task);
                    Response.Redirect("~/WebForms/BuscarTareaColaborador");
                }
                else
                {
                    lbl_error_hours.Visible = true;
                }
            }
            else
            {
                lbl_warning_hours_type.Visible = true;
            }
        }

        //TODO... Se ejecuta cuando se cambia del índice señalado en el PageLoad a otro, pero no al revés
        protected void rbl_hours_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_warning_hours_type.Visible = false;
            GetRegisteredHours();
            GetAllowedHours();
            LoadHoursDropDownList();
            LoadMinutesDropDownList();
        }

        protected void cld_selected_date_SelectionChanged(object sender, EventArgs e)
        {
            if (rbl_hours_type.SelectedValue == "0" || rbl_hours_type.SelectedValue == "1")
            {
                GetRegisteredHours();
                //ddl_hours_PreValue = Int32.Parse(ddl_hours.SelectedValue);
                GetAllowedHours();
                LoadHoursDropDownList();
                LoadMinutesDropDownList();
                lbl_warning_reselect.Visible = true;
            }
            else
            {
                lbl_warning_hours_type.Visible = true;
            }
        }

        private void GetRegisteredHours()
        {
            taskBusiness = new TaskBusiness();
            task = new Task();
            task.Collaborator.Id = (int)Session["userId"];
            task.Date = cld_selected_date.SelectedDate;
            task.ExtraHours = Convert.ToBoolean(Int32.Parse(rbl_hours_type.SelectedValue));
            registeredHours = taskBusiness.GetHoursByDateAndCollaborator(task).Hours;
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

        protected void ddl_hours_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetRegisteredHours();
            GetAllowedHours();
            //LoadHoursDropDownList();
            //ddl_hours.SelectedValue = ddl_hours_PreValue + "";
            LoadMinutesDropDownList();
            lbl_warning_reselect.Visible = false;
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForms/BuscarTareaColaborador");
        }

        protected void DisableDays(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date > DateTime.Now.Date)
            {
                e.Day.IsSelectable = false;
            }
        }
    }
}