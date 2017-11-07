
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

        protected void Page_Load(object sender, EventArgs e)
        {
            this.userBusiness = new UserBusiness();
            this.projectBusiness = new ProjectBusiness();
            this.categoryBusiness = new CategoryBusiness();
            this.taskBusiness = new TaskBusiness();
        }

        /// <summary>
        /// Metodo que agrega por querrystring el id de una entidad seleccionada como filtro sin importar el botón, se usa "commandName" y "commandParameter" en el botón.
        /// </summary>
        /// <param name="sender">El botón que fue presionado</param>
        /// <param name="e"></param>
        private void btnAddEntityFilter_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            String path = "./BuscarTarea.aspx?", user, category, project;

            user = ((Request.QueryString["user"] != null) ? ("user=" + Request.QueryString["user"].ToString() + "&") : (""));
            category = ((Request.QueryString["category"] != null) ? ("category=" + Request.QueryString["category"].ToString() + "&") : (""));
            project = ((Request.QueryString["project"] != null) ? ("project=" + Request.QueryString["project"].ToString() + "&") : (""));

            switch (btn.CommandName)
            {
                case "user":
                    path += "user=" + btn.CommandArgument.ToString() + "&" + category + project;
                    break;
                case "category":
                    path += user + "category=" + btn.CommandArgument.ToString() + "&" + project;
                    break;
                case "project":
                    path += user + category + "project=" + btn.CommandArgument.ToString() + "&";
                    break;
            }

            path = path.Remove(path.Length - 1);
            Response.Redirect("./BuscarProyecto.aspx");
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
                    Text = "<button type='button' class='btn btn-danger' value=" + listElement.Id + " onclick='FillHidden(\"Project\", this.value,\"" + listElement.Name + "\")'>Tareas por el proyecto " + listElement.Name + "</button>",
                    CssClass = "results"
                };

                tempRow.Cells.Add(tempCell);
                tempRow.CssClass = "results";
                this.resultProjectTable.Rows.Add(tempRow);
            }

            this.resultProjectTable.Visible = true;
            this.resultTaskTable.Visible = false;
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
                    Text = "<button type='button' class='btn btn-danger' value=" + listElement.Id + " onclick='FillHidden(\"Category\", this.value,\"" + listElement.Name + "\")'>Tareas por la categoría " + listElement.Name + "</button>",

                    CssClass = "results"
                };

                tempRow.Cells.Add(tempCell);
                tempRow.CssClass = "results";
                this.resultCategoryTable.Rows.Add(tempRow);
            }

            this.resultCategoryTable.Visible = true;
            this.resultTaskTable.Visible = false;
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
                tempCell = new TableCell
                {
                    //El boton no contiene id, pero sí un 'value' que es el id de la entidad, también llamamos al método
                    // que llena el hidden de la entidad pasando el nombre de la entidad, y el valor de este botón.
                    Text = "<button type='button' class='btn btn-danger' value=" + listElement.Id + " onclick='FillHidden(\"User\", this.value,\"" + listElement.FirstName + " " + listElement.LastName + "\")'>Tareas de " + listElement.FirstName + " " + listElement.LastName + "</button>",
                    CssClass = "results"
                };
                tempRow.Cells.Add(tempCell);

                //Finalmente añadimos la tupla temporal.
                this.resultUserTable.Rows.Add(tempRow);
            }
            //Hacemos visible la tabla que originalmente es invisible.
            this.resultUserTable.Visible = true;
            //Hacemos invisible la tabla de resultados para evitar el "bug" donde solo quedan visibles los encabezados.
            this.resultTaskTable.Visible = false;
        }

        protected void BTEliminar_Click(object sender, EventArgs e)
        {
            Response.Redirect("EliminarTarea.aspx");
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

            foreach(Task listItem in taskList)
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

                //Por último añadimos un indicador de si son horas extra o no.
                tempCell = new TableCell
                {
                    Text = "<input id='"+listItem.Id+"' class='results' type=\"checkbox\" " + (listItem.ExtraHours ? "checked " : "") + "disabled ><label for='"+listItem.Id+"'><span></span></label>",
                    CssClass = "results"
                };
                tempRow.Cells.Add(tempCell);

                tempRow.CssClass = "results";
                this.resultTaskTable.Rows.Add(tempRow);
            }

            this.resultTaskTable.Visible = true;
            this.resultUserTable.Visible = false;
            this.resultCategoryTable.Visible = false;
            this.resultProjectTable.Visible = false;

        }
    }
}