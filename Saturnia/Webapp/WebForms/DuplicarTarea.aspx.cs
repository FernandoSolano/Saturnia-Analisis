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
        protected void Page_Load(object sender, EventArgs e)
        {
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
                //task.Id = 147;//Horas regulares
                task.Id = 155;//Horas extra
                //*************************************************
                task = taskBusiness.ShowTask(task);
                ddl_projects.SelectedValue = task.Project.Id.ToString();
                ddl_categories.SelectedValue = task.Category.Id.ToString();
                rbl_hours_type.SelectedValue = Convert.ToInt32(task.ExtraHours).ToString();
                lbl_title.Text = task.ExtraHours.ToString();
                //TODO... Validar las horas y medias horas, task.Hours es un flotante
                //ddl_hours.SelectedValue = task.Hours.ToString();
                //ddl_minutes.SelectedValue = ;
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
            //TODO... validar las horas y las medias horas
            //task.Hours=
            task.Description = tb_description.Text;
            task.Date = cld_selected_date.SelectedDate;
        }
    }
}