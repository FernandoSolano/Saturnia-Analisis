﻿
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
    public partial class BuscarTarea : System.Web.UI.Page
    {

        private UserBusiness userBusiness;
        private ProjectBusiness projectBusiness;
        private CategoryBusiness categoryBusiness;
        private TaskBusiness taskBusiness;

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
            this.userBusiness = new UserBusiness();
            this.projectBusiness = new ProjectBusiness();
            this.categoryBusiness = new CategoryBusiness();
            this.taskBusiness = new TaskBusiness();
            this.HLCreateTask.PostBackUrl = "./CrearTarea.aspx";
        }        

        protected void btnSearchProject_Click(object sender, EventArgs e)
        {
            String name = this.txtProjectName.Text;
            Project project = new Project();
            project.Name = name;
            List<Project> results = this.projectBusiness.SearchProject(project);
            TableRow tempRow;
            TableCell tempCell;

            foreach (Project listElement in results)
            {
                tempRow = new TableRow();
                tempCell = new TableCell
                {
                    Text = listElement.Name,
                    CssClass = "results"
                };
                tempRow.Cells.Add(tempCell);

                tempCell = new TableCell
                {
                    CssClass = "results"
                };

                if (listElement.Id != -1)
                {
                    tempCell.Text = "<button type='button' class='btn btn-danger' value=" + listElement.Id + " onclick='FillHidden(\"Project\", this.value,\"" + listElement.Name + "\")' style=\"width:100%\" data-toggle=\"tooltip\" title=\"Solo buscar tareas registradas en " + listElement.Name + " \" > " + listElement.Name + "</button>";
                } else
                {
                    tempCell.Text = "";
                }

                tempRow.Cells.Add(tempCell);
                tempRow.CssClass = "results";
                this.resultProjectTable.Rows.Add(tempRow);
            }

            this.ShowTable(3);
        }

        protected void btnSearchCategory_Click(object sender, EventArgs e)
        {
            String name = this.txtCategoryName.Text;
            Category category = new Category
            {
                Name = name
            };
            List<Category> results = this.categoryBusiness.SearchCategory(category);
            TableRow tempRow;
            TableCell tempCell;

            foreach (Category listElement in results)
            {
                tempRow = new TableRow();
                tempCell = new TableCell
                {
                    Text = listElement.Name,

                    CssClass = "results"
                };
                tempRow.Cells.Add(tempCell);

                tempCell = new TableCell
                {
                    CssClass = "results"
                };
                if (listElement.Id != -1)
                {
                    //El boton no contiene id, pero sí un 'value' que es el id de la entidad, también llamamos al método
                    // que llena el hidden de la entidad pasando el nombre de la entidad, y el valor de este botón.
                    tempCell.Text = "<button type='button' class='btn btn-danger' value=" + listElement.Id + " onclick='FillHidden(\"Category\", this.value,\"" + listElement.Name + "\")' style=\"width:100%\" data-toggle=\"tooltip\" title=\"Solo buscar tareas de " + listElement.Name + " \">" + listElement.Name + "</button>";
                }
                else
                {
                    tempCell.Text = "";
                }

                tempRow.Cells.Add(tempCell);
                tempRow.CssClass = "results";
                this.resultCategoryTable.Rows.Add(tempRow);
            }

            this.ShowTable(2);
        }

        protected void btnSearchUser_Click(object sender, EventArgs e)
        {
            ///Capturamos el texto a buscar.
            String name = this.txtUserName.Text;

            //Creamos un nuevo usuario con el nombre a buscar.
            User user = new User();
            user.FirstName = name;

            //Con el usuario conteniendo el nombre a buscar, llamamos al metodo que nos retorna una lista con al menos 1 resultado.
            List<User> results = this.userBusiness.SearchUser(user);

            //Variables temporales para llenar la tabla de resultados.
            TableRow tempRow;
            TableCell tempCell;

            foreach (User listElement in results)
            {
                //Se inicializan.
                tempRow = new TableRow();
                tempCell = new TableCell
                {

                    //Cargamos el nombre del usuario y la agregamos a la tabla.
                    Text = listElement.FirstName,
                    CssClass = "results" //Importante, el CSS contiene la clase "results" para las tablas similares a esta.
                };
                tempRow.Cells.Add(tempCell);

                //Re-inicializamos a "tempCell" para agregar los apellidos a la tabla
                tempCell = new TableCell
                {
                    Text = listElement.LastName,
                    CssClass = "results"
                };
                tempRow.Cells.Add(tempCell);

                //Re-inicializamos a "tempCell" para agregar el botón de seleccionar a la tabla
                tempCell = new TableCell { 
                    CssClass = "results"
                };
                if (listElement.Id != -1)
                {
                    //El boton no contiene id, pero sí un 'value' que es el id de la entidad, también llamamos al método
                    // que llena el hidden de la entidad pasando el nombre de la entidad, y el valor de este botón.
                    tempCell.Text = "<button type='button' class='btn btn-danger' value=" + listElement.Id + " onclick='FillHidden(\"User\", this.value,\"" + listElement.FirstName + " " + listElement.LastName + "\")' style=\"width:100%\" data-toggle=\"tooltip\" title=\"Solo buscar tareas de " + listElement.FirstName + " \"> " + listElement.FirstName + " " + listElement.LastName + "</button>";
                } else
                {
                    tempCell.Text = "";
                }
                tempRow.Cells.Add(tempCell);

                //Finalmente añadimos la tupla temporal.
                this.resultUserTable.Rows.Add(tempRow);
            }
            //Hacemos visible la tabla que originalmente es invisible.
            this.ShowTable(1);
        }

        protected void btnSearchTask_Click(object sender, EventArgs e)
        {
            int user, category, project;
            String textDateFrom, textDateTo, taskDescription;
            DateTime dateFrom, dateTo;
            Task localTask;
            List<Task> taskList;
            TableRow tempRow;
            TableCell tempCell;

            textDateFrom = this.txtFrom.Text;
            textDateTo = this.txtTo.Text;
            taskDescription = ""; //Actualmente no se busca por descripción, pero de ser necesario queda listo.
                                 //Tan solo falta añadir un txt para descripción y obtener su texto aquí.

            user = Int16.Parse(this.hdnUser.Value);
            category = Int16.Parse(this.hdnCategory.Value);
            project = Int16.Parse(this.hdnProject.Value);

            this.lblDateMessage.Visible = false;
            this.ShowTable(0);
            
            //El bloque try protege de fechas inválidas, pero tome en cuenta que una fecha vacía ("") es válida
            //para nosotros, esto indica que se deben buscar tareas sin importar la fecha.
            try
            {
                //Inicializamos las variables de fecha.
                dateFrom = DateTime.Parse(
                    (textDateFrom != "") ? textDateFrom : "1801-08-05"
                );
                dateTo = DateTime.Parse(
                    (textDateTo != "") ? textDateTo : "1801-08-05"
                );

                //Inicializamos la tarea a buscar
                localTask = new Task();

                //Primero los filtros usuario, categoria y colaborador
                localTask.Collaborator.Id = user;
                localTask.Project.Id = project;
                localTask.Category.Id = category;
                //Luego las fechas.
                localTask.Date = dateFrom;
                //Con esto nos ahorramos una conversión en data en algunos casos, en otros se obtiene de la descripcion del
                //proyecto que conforma la tarea.
                localTask.Project.Description = (
                    dateFrom == dateTo ? ("Same") : (dateTo.ToString())
                );
                //Finalmente la descripcion de la tarea
                localTask.Description = taskDescription;


                taskList = this.taskBusiness.Search(localTask);

                foreach (Task listItem in taskList)
                {
                    tempRow = new TableRow();

                    tempCell = new TableCell
                    {

                        //Añadimos descripcion
                        Text = "<a href=\"#\" class=\"results\" data-toggle=\"tooltip\" title=\"Ver tarea en detalle\">" + listItem.Description + "</a>",
                        CssClass = "results"
                    };
                    tempRow.Cells.Add(tempCell);

                    //Añadimos fecha
                    tempCell = new TableCell
                    {
                        Text = listItem.Date.ToShortDateString(),
                        CssClass = "results"
                    };
                    tempRow.Cells.Add(tempCell);

                    //Añadimos el nombre del proyecto.
                    tempCell = new TableCell
                    {
                        Text = listItem.Project.Name,
                        CssClass = "results"
                    };
                    tempRow.Cells.Add(tempCell);

                    //Añadimos las horas dedicadas.
                    tempCell = new TableCell
                    {
                        Text = listItem.Hours.ToString(),
                        CssClass = "results"
                    };
                    tempRow.Cells.Add(tempCell);

                    //Añadimos un indicador de si son horas extra o no.
                    tempCell = new TableCell
                    {
                        Text = "<input id='" + listItem.Id + "' class='results' type=\"checkbox\" " + (listItem.ExtraHours ? "checked " : "") + "disabled ><label for='" + listItem.Id + "'><span></span></label>",
                        CssClass = "results"
                    };
                    tempRow.Cells.Add(tempCell);

                    //Finalmente agregamos los enlaces de las acciones a realizar.
                    //Se agregan en el orden: Link para actualizar, link para duplicar y link para eliminar.
                    tempCell = new TableCell
                    {
                        CssClass = "results"
                    };
                    if (listItem.Id != -1)
                    {
                        tempCell.Text = "<a href=\"./ActualizarTarea.aspx?id=" + listItem.Id + "\" class=\"results\">Editar</a>&nbsp;" +
                        "<a href=\"./DuplicarTarea.aspx?id=" + listItem.Id + "\" class=\"results\">Duplicar</a>&nbsp;" +
                        "<a href=\"EliminarTarea.aspx?id=" + listItem.Id + "\" class=\"results\">Eliminar</a>";

                    }
                    else
                    {
                        tempCell.Text = "No hay acciones para este caso.";
                    }
                    tempRow.Cells.Add(tempCell);

                    tempRow.CssClass = "results";
                    this.resultTaskTable.Rows.Add(tempRow);
                }

                this.ShowTable(4);

            }
            catch
            {
                this.lblDateMessage.Visible = true;
            }
            

        }

        /// <summary>
        /// Método que hace visible únicamente la tabla según un número recibido.
        /// </summary>
        /// <param name="tableNumber">Número de la tabla a hacer visible.</param>
        private void ShowTable(Byte tableNumber)
        {
            //Este método es hecho debido al "bug" en el que si hay una tabla cargada
            // y se carga una nueva, la primera desaparece sus datos dejando únicamente
            // los encabezados, lo cual se vé mal.

            //Ocultamos todas las tablas.
            this.resultTaskTable.Visible = false;
            this.resultUserTable.Visible = false;
            this.resultCategoryTable.Visible = false;
            this.resultProjectTable.Visible = false;

            //Dependiendo del valor recibido, harémos visible una tabla.
            switch (tableNumber)
            {
                case 1:
                    //Se hace visible la tabla usuario
                    this.resultUserTable.Visible = true;
                    break;
                case 2:
                    //Se hace visible la tabla categoria.
                    this.resultCategoryTable.Visible = true;
                    break;
                case 3:
                    //Se hace visible la tabla proyecto.
                    this.resultProjectTable.Visible = true;
                    break;
                case 4:
                    //Se hace visible la tabla tarea.
                    this.resultTaskTable.Visible = true;
                    break;
            }
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("./IndexAdmin.aspx");
        }
    }
}