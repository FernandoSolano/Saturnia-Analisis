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
    public partial class CrearTarea : System.Web.UI.Page
    {

        private TaskBusiness taskBusiness;
        private CategoryBusiness categoryBusiness;
        private ProjectBusiness projectBusiness;


        protected void Page_Load(object sender, EventArgs e)
        {
            taskBusiness = new TaskBusiness();
            categoryBusiness = new CategoryBusiness();
            projectBusiness = new ProjectBusiness();


            if (!Page.IsPostBack)
            {
                setCategoryDropDownList();
                setProjectsDropDownList();

            }
        }

        public void setCategoryDropDownList()
        {
            Category category = new Category();
            List<Category> categories = categoryBusiness.SearchCategory(category);
            DdlCategory.DataSource = categories;
            DdlCategory.DataValueField = "Id";
            DdlCategory.DataTextField = "Name";
            DdlCategory.DataBind();

            DdlCategorySoT.DataSource = categories;
            DdlCategorySoT.DataValueField = "Id";
            DdlCategorySoT.DataTextField = "Name";
            DdlCategorySoT.DataBind();
        }

        public void setProjectsDropDownList()
        {
            User user = new User();
            user.Id = (int)Session["userId"];
            List<Project> collaboratorProjects = projectBusiness.GetProjectsByCollaborator(user);
            DdlProject.DataSource = collaboratorProjects;
            DdlProjectSoT.DataSource = collaboratorProjects;
            if (collaboratorProjects.Count <= 0)
            {
                Project project = new Project();
                project.Name = "No tiene proyectos";
                collaboratorProjects.Add(project);
                DdlProject.Enabled = false;
                DdlProjectSoT.Enabled = false;
                BtnAdd.Enabled = false;
                BtnAddSoT.Enabled = false;
            }
            DdlProject.DataValueField = "Id";
            DdlProject.DataTextField = "Name";
            DdlProjectSoT.DataValueField = "Id";
            DdlProjectSoT.DataTextField = "Name";
            DdlProject.DataBind();
            DdlProjectSoT.DataBind();
        }

        public void resetData()
        {
            RadioButtonList1.SelectedIndex = -1;
            RadioButtonList2.SelectedIndex = -1;
            TbDescription.Text = "";
            TbDescription2.Text = "";
            DdlHours.Items.Clear();
            DdlMinutes.SelectedIndex = 0;
            DdlHoursSoT.Items.Clear();
            DdlMinutesSoT.SelectedIndex = 0;
            Lbdates.Items.Clear();

        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            Task task = new Task();
            task.Category.Id = Int32.Parse(DdlCategory.SelectedItem.Value);
            task.Project.Id = Int32.Parse(DdlProject.SelectedItem.Value);
            task.Collaborator.Id = (int)Session["userId"];
            if (Calendar1.SelectedDate.Year.ToString() == "0001")
            {
                LblWarning.Text = "Debe ingresar una fecha válida";
            }
            else
            {
                task.Date = Calendar1.SelectedDate;

                if (TbDescription.Text == "")
                {
                    LblWarning.Text = "Debe agregar una descripción de la tarea realizada";

                }
                else
                {
                    task.Description = TbDescription.Text;
                    if ((DdlHours.SelectedIndex == 0 && DdlMinutes.SelectedIndex == 0) ||
                        (RadioButtonList1.SelectedIndex == 0 && DdlHours.SelectedIndex == 8 && DdlMinutes.SelectedIndex == 1) ||
                        (RadioButtonList1.SelectedIndex == 1 && DdlHours.SelectedIndex == 16 && DdlMinutes.SelectedIndex == 1))
                    {
                        LblWarning.Text = "No puede ingresar horas fuera del rango permitido";
                    }
                    else
                    {

                        if (RadioButtonList1.SelectedIndex == 0)
                        {
                            task.ExtraHours = false;
                        }
                        else if (RadioButtonList1.SelectedIndex == 1)
                        {
                            task.ExtraHours = true;
                        }
                        float registeredHours = taskBusiness.GetHoursByDateAndCollaborator(task);
                        float hoursInTheForm = float.Parse(DdlHours.Text + "," + DdlMinutes.Text);

                        if ((task.ExtraHours && registeredHours + hoursInTheForm > 16) || (!task.ExtraHours && registeredHours + hoursInTheForm > 8))
                        {
                            LblWarning.Text = "Usted ya ha ingresado " + registeredHours + " horas anteriormente, no se puede pasar del límite de horas diario.";

                        }
                        else
                        {
                            task.Hours = hoursInTheForm;
                            task = taskBusiness.addTask(task);
                            if (task.Id > 0)
                            {

                                LblWarning.Text = "Se ha ingresado la nueva tarea con éxito";
                            }
                            else
                            {
                                LblWarning.Text = "Ha ocurrido un error, envíe el formulario nuevamente";
                            }
                        }

                    }

                }
            }

        }

        protected void BtnAddSoT_Click(object sender, EventArgs e)
        {


            if (Lbdates.Items.Count > 1)
            {
                foreach (ListItem date in Lbdates.Items)
                {
                    Task testTask = new Task();
                    testTask.Collaborator.Id = (int)Session["userId"];
                    testTask.Date = DateTime.Parse(date.Text);
                    if (RadioButtonList2.SelectedIndex == 0)
                    {
                        testTask.ExtraHours = false;
                    }
                    else if (RadioButtonList2.SelectedIndex == 1)
                    {
                        testTask.ExtraHours = true;
                    }
                    float registeredHours = taskBusiness.GetHoursByDateAndCollaborator(testTask);
                    float hoursInTheForm = float.Parse(DdlHoursSoT.Text + "," + DdlMinutesSoT.Text);

                    if ((testTask.ExtraHours && registeredHours + hoursInTheForm > 16) || (!testTask.ExtraHours && registeredHours + hoursInTheForm > 8))
                    {
                        LblWarningSoT.Text = "Usted ya ha ingresado " + registeredHours + " horas  anteriormente para el día " + testTask.Date.ToShortDateString() + ", no se puede pasar del límite de horas diario.";
                        break;
                    }

                }


                foreach (ListItem date in Lbdates.Items)
                {

                    Task task = new Task();
                    task.Category.Id = Int32.Parse(DdlCategorySoT.SelectedItem.Value);
                    task.Project.Id = Int32.Parse(DdlProjectSoT.SelectedItem.Value);
                    task.Collaborator.Id = (int)Session["userId"];
                    task.Date = DateTime.Parse(date.Text);
                    if (TbDescription2.Text == "")
                    {
                        LblWarningSoT.Text = "Debe agregar una descripción de la tarea realizada";

                    }
                    else
                    {
                        task.Description = TbDescription2.Text;
                        if ((DdlHoursSoT.SelectedIndex == 0 && DdlMinutesSoT.SelectedIndex == 0) ||
                            (RadioButtonList2.SelectedIndex == 0 && DdlHoursSoT.SelectedIndex == 8 && DdlMinutesSoT.SelectedIndex == 1) ||
                            (RadioButtonList2.SelectedIndex == 1 && DdlHoursSoT.SelectedIndex == 16 && DdlMinutesSoT.SelectedIndex == 1))
                        {
                            LblWarningSoT.Text = "No puede ingresar horas fuera del rango permitido";
                        }
                        else
                        {

                            if (RadioButtonList2.SelectedIndex == 0)
                            {
                                task.ExtraHours = false;
                            }
                            else if (RadioButtonList2.SelectedIndex == 1)
                            {
                                task.ExtraHours = true;
                            }


                            float registeredHours = taskBusiness.GetHoursByDateAndCollaborator(task);
                            float hoursInTheForm = float.Parse(DdlHoursSoT.Text + "," + DdlMinutesSoT.Text);

                            if ((task.ExtraHours && registeredHours + hoursInTheForm > 16) || (!task.ExtraHours && registeredHours + hoursInTheForm > 8))
                            {
                                LblWarningSoT.Text = "Usted ya ha ingresado " + registeredHours + " horas  anteriormente para el día " + task.Date.ToShortDateString() + ", no se puede pasar del límite de horas diario.";
                                break;
                            }
                            else
                            {
                                task.Hours = hoursInTheForm;
                                task = taskBusiness.addTask(task);
                                if (task.Id > 0)
                                {

                                    LblWarningSoT.Text = "Se ha ingresado la nueva tarea con éxito";
                                }
                                else
                                {
                                    LblWarningSoT.Text = "Ha ocurrido un error, envíe el formulario nuevamente";
                                }
                            }

                        }
                    }

                }
            }
            else
            {
                LblWarningSoT.Text = "Debe seleccionar al menos dos fechas para realizar el ingreso por lote";
            }
        }

        protected void BtnRemove_Click(object sender, EventArgs e)
        {
            if (Lbdates.SelectedIndex > -1)
            {
                Lbdates.Items.RemoveAt(Lbdates.SelectedIndex);
            }
        }

        protected void BtnSetData_Click(object sender, EventArgs e)
        {
            resetData();
        }

        protected void AddDateToList(object sender, EventArgs e)
        {
            if (Lbdates.Items.Contains(new ListItem(Calendar2.SelectedDate.ToShortDateString())))
            {
                LblWarningSoT.Text = "La fecha ya ha sido seleccionada anteriormente";
            }
            else
            {
                Lbdates.Items.Add(Calendar2.SelectedDate.ToShortDateString());
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedIndex == 0)
            {
                DdlHours.Items.Clear();
                DdlHours.Items.Add(new ListItem("0", "0"));
                DdlHours.Items.Add(new ListItem("1", "1"));
                DdlHours.Items.Add(new ListItem("2", "2"));
                DdlHours.Items.Add(new ListItem("3", "3"));
                DdlHours.Items.Add(new ListItem("4", "4"));
                DdlHours.Items.Add(new ListItem("5", "5"));
                DdlHours.Items.Add(new ListItem("6", "6"));
                DdlHours.Items.Add(new ListItem("7", "7"));
                DdlHours.Items.Add(new ListItem("8", "8"));
            }
            else if (RadioButtonList1.SelectedIndex == 1)
            {
                DdlHours.Items.Clear();
                DdlHours.Items.Add(new ListItem("0", "0"));
                DdlHours.Items.Add(new ListItem("1", "1"));
                DdlHours.Items.Add(new ListItem("2", "2"));
                DdlHours.Items.Add(new ListItem("3", "3"));
                DdlHours.Items.Add(new ListItem("4", "4"));
                DdlHours.Items.Add(new ListItem("5", "5"));
                DdlHours.Items.Add(new ListItem("6", "6"));
                DdlHours.Items.Add(new ListItem("7", "7"));
                DdlHours.Items.Add(new ListItem("8", "8"));
                DdlHours.Items.Add(new ListItem("9", "9"));
                DdlHours.Items.Add(new ListItem("10", "10"));
                DdlHours.Items.Add(new ListItem("11", "11"));
                DdlHours.Items.Add(new ListItem("12", "12"));
                DdlHours.Items.Add(new ListItem("13", "13"));
                DdlHours.Items.Add(new ListItem("14", "14"));
                DdlHours.Items.Add(new ListItem("15", "15"));
                DdlHours.Items.Add(new ListItem("16", "16"));

            }

        }

        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList2.SelectedIndex == 0)
            {
                DdlHoursSoT.Items.Clear();
                DdlHoursSoT.Items.Add(new ListItem("0", "0"));
                DdlHoursSoT.Items.Add(new ListItem("1", "1"));
                DdlHoursSoT.Items.Add(new ListItem("2", "2"));
                DdlHoursSoT.Items.Add(new ListItem("3", "3"));
                DdlHoursSoT.Items.Add(new ListItem("4", "4"));
                DdlHoursSoT.Items.Add(new ListItem("5", "5"));
                DdlHoursSoT.Items.Add(new ListItem("6", "6"));
                DdlHoursSoT.Items.Add(new ListItem("7", "7"));
                DdlHoursSoT.Items.Add(new ListItem("8", "8"));
            }
            else if (RadioButtonList2.SelectedIndex == 1)
            {
                DdlHoursSoT.Items.Clear();
                DdlHoursSoT.Items.Add(new ListItem("0", "0"));
                DdlHoursSoT.Items.Add(new ListItem("1", "1"));
                DdlHoursSoT.Items.Add(new ListItem("2", "2"));
                DdlHoursSoT.Items.Add(new ListItem("3", "3"));
                DdlHoursSoT.Items.Add(new ListItem("4", "4"));
                DdlHoursSoT.Items.Add(new ListItem("5", "5"));
                DdlHoursSoT.Items.Add(new ListItem("6", "6"));
                DdlHoursSoT.Items.Add(new ListItem("7", "7"));
                DdlHoursSoT.Items.Add(new ListItem("8", "8"));
                DdlHoursSoT.Items.Add(new ListItem("9", "9"));
                DdlHoursSoT.Items.Add(new ListItem("10", "10"));
                DdlHoursSoT.Items.Add(new ListItem("11", "11"));
                DdlHoursSoT.Items.Add(new ListItem("12", "12"));
                DdlHoursSoT.Items.Add(new ListItem("13", "13"));
                DdlHoursSoT.Items.Add(new ListItem("14", "14"));
                DdlHoursSoT.Items.Add(new ListItem("15", "15"));
                DdlHoursSoT.Items.Add(new ListItem("16", "16"));

            }


        }

        protected void DisableDays(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date.Day > DateTime.Now.Day || e.Day.Date.Month > DateTime.Now.Month || e.Day.Date.Year > DateTime.Now.Year)
            {
                e.Day.IsSelectable = false;
            }
        }
    }
}