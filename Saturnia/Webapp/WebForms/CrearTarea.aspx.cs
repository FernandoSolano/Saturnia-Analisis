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
                SetCategoryDropDownList();
                SetProjectsDropDownList();
                SetHoursDropDownList();

            }
        }

        public void SetCategoryDropDownList()
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
            DdlCategory.Items.Insert(0, new ListItem("Seleccione"));
            DdlCategorySoT.Items.Insert(0, new ListItem("Seleccione"));
        }

        public void SetHoursDropDownList()
        {
            DdlHours.Items.Clear();
            DdlHoursSoT.Items.Clear();

            for (int i = 0; i <= 8; i++)
            {
                DdlHours.Items.Add(new ListItem(i.ToString()));
            }

            DdlHoursSoT.Items.AddRange(DdlHours.Items.OfType<ListItem>().ToArray());

        }

        public void SetProjectsDropDownList()
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
            DdlProject.Items.Insert(0, new ListItem("Seleccione"));
            DdlProjectSoT.Items.Insert(0, new ListItem("Seleccione"));
        }

        public void ResetData()
        {
            DdlCategory.SelectedIndex = 0;
            DdlCategorySoT.SelectedIndex = 0;
            DdlProject.SelectedIndex = 0;
            DdlProjectSoT.SelectedIndex = 0;
            RadioButtonList1.SelectedIndex = 0;
            RadioButtonList2.SelectedIndex = 0;
            TbDescription.Text = "";
            TbDescription2.Text = "";
            SetHoursDropDownList();
            DdlMinutes.SelectedIndex = 0;
            DdlMinutesSoT.SelectedIndex = 0;
            Lbdates.Items.Clear();
            LblWarning.Text = "";
            LblWarningSoT.Text = "";

        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForms/IndexColaborador.aspx");
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            Task task = new Task();
            if (DdlProject.SelectedIndex == 0)
            {
                LblWarning.Text = "Seleccione un proyecto de la lista";
            }
            else
            {
                task.Project.Id = Int32.Parse(DdlProject.SelectedItem.Value);
                if (DdlCategory.SelectedIndex == 0)
                {
                    LblWarning.Text = "Selecciona una categoría de la lista";
                }
                else
                {


                    task.Category.Id = Int32.Parse(DdlCategory.SelectedItem.Value);

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
                                float registeredHours = taskBusiness.GetHoursByDateAndCollaborator(task).Hours;
                                float hoursInTheForm = float.Parse(DdlHours.Text + "," + DdlMinutes.Text);

                                if ((task.ExtraHours && registeredHours + hoursInTheForm > 16) || (!task.ExtraHours && registeredHours + hoursInTheForm > 8))
                                {
                                    LblWarning.Text = "Usted ya ha ingresado " + registeredHours + " horas anteriormente, no se puede pasar del límite de horas diario.";

                                }
                                else
                                {
                                    task.Hours = hoursInTheForm;
                                    task = taskBusiness.AddTask(task);
                                    if (task.Id > 0)
                                    {

                                        ResetData();
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
                    float registeredHours = taskBusiness.GetHoursByDateAndCollaborator(testTask).Hours;
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
                    if (DdlProjectSoT.SelectedIndex == 0)
                    {
                        LblWarningSoT.Text = "Seleccione un proyecto de la lista";
                    }
                    else
                    {
                        task.Project.Id = Int32.Parse(DdlProjectSoT.SelectedItem.Value);
                        if (DdlCategorySoT.SelectedIndex == 0)
                        {
                            LblWarningSoT.Text = "Seleccione una categoría de la lista";
                        }
                        else
                        {
                            task.Category.Id = Int32.Parse(DdlCategorySoT.SelectedItem.Value);

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


                                    float registeredHours = taskBusiness.GetHoursByDateAndCollaborator(task).Hours;
                                    float hoursInTheForm = float.Parse(DdlHoursSoT.Text + "," + DdlMinutesSoT.Text);

                                    if ((task.ExtraHours && registeredHours + hoursInTheForm > 16) || (!task.ExtraHours && registeredHours + hoursInTheForm > 8))
                                    {
                                        LblWarningSoT.Text = "Usted ya ha ingresado " + registeredHours + " horas  anteriormente para el día " + task.Date.ToShortDateString() + ", no se puede pasar del límite de horas diario.";
                                        break;
                                    }
                                    else
                                    {
                                        task.Hours = hoursInTheForm;
                                        task = taskBusiness.AddTask(task);
                                        if (task.Id > 0)
                                        {
                                            ResetData();
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
            ResetData();
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
                for (int i = 9; i <= 16; i++)
                {
                    DdlHours.Items.Remove(i.ToString());
                }
            }
            else if (RadioButtonList1.SelectedIndex == 1)
            {


                for (int i = 9; i <= 16; i++)
                {
                    DdlHours.Items.Add(new ListItem(i.ToString()));
                }

            }

        }

        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList2.SelectedIndex == 0)
            {
                for (int i = 9; i <= 16; i++)
                {
                    DdlHoursSoT.Items.Remove(i.ToString());
                }
            }
            else if (RadioButtonList2.SelectedIndex == 1)
            {
                for (int i = 9; i <= 16; i++)
                {
                    DdlHoursSoT.Items.Add(new ListItem(i.ToString()));
                }

            }


        }

        protected void DisableDays(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date > DateTime.Now.Date)
            {
                e.Day.IsSelectable = false;
            }
        }

        protected void DdlHours_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblWarning.Text = "cacaqwe";
            if ((RadioButtonList1.SelectedIndex == 0 && DdlHours.SelectedValue.Equals("8")) || (RadioButtonList1.SelectedIndex == 1 && DdlHours.SelectedValue.Equals(16)))
            {
                DdlMinutes.Items[1].Enabled = false;
                LblWarning.Text = "caca";
            }
            else if(DdlHours.SelectedIndex == 0)
            {
                DdlMinutes.Items[0].Enabled = false;
                LblWarning.Text = "caca2";
            }
        }
    }
}