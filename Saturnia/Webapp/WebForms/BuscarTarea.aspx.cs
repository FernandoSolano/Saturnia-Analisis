
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
            if (Page.IsPostBack == false)
            {
                this.userBusiness = new UserBusiness();
                this.projectBusiness = new ProjectBusiness();
                this.categoryBusiness = new CategoryBusiness();
                this.taskBusiness = new TaskBusiness();
            }
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
                tempCell = new TableCell();

                tempCell.Text = listElement.Name;
                tempCell.CssClass = "results";
                tempRow.Cells.Add(tempCell);

                tempRow.Cells.Add(tempCell);
                tempRow.CssClass = "results";
                this.resultProjectTable.Rows.Add(tempRow);
            }

            this.resultProjectTable.Visible = true;
        }

        protected void btnSearchCategory_Click(object sender, EventArgs e)
        {
            String name = this.txtCategoryName.Text;
            Category category = new Category();
            category.Name = name;
            List<Category> results = this.categoryBusiness.SearchCategory(category);
            TableRow tempRow;
            TableCell tempCell;

            foreach (Category listElement in results)
            {
                tempRow = new TableRow();
                tempCell = new TableCell();

                tempCell.Text = listElement.Name;

                tempCell.CssClass = "results";
                tempRow.Cells.Add(tempCell);
                tempRow.CssClass = "results";
                this.resultCategoryTable.Rows.Add(tempRow);
            }

            this.resultCategoryTable.Visible = true;
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
            Button tempButton;

            foreach (User listElement in results)
            {
                //Se inicializan.
                tempRow = new TableRow();
                tempCell = new TableCell();

                //Cargamos el nombre del usuario y la agregamos a la tabla.
                tempCell.Text = listElement.FirstName;
                tempCell.CssClass = "results"; //Importante, el CSS contiene la clase "results" para las tablas similares a esta.
                tempRow.Cells.Add(tempCell);

                //Re-inicializamos a "tempCell" para agregar los apellidos a la tabla
                tempCell = new TableCell();
                tempCell.Text = listElement.LastName;
                tempCell.CssClass = "results";
                tempRow.Cells.Add(tempCell);

                //Re-inicializamos a "tempCell" para agregar el botón de seleccionar a la tabla
                tempCell = new TableCell();
                //El boton no contiene id, pero sí un 'value' que es el id de la entidad, también llamamos al método
                // que llena el hidden de la entidad pasando el nombre de la entidad, y el valor de este botón.
                tempCell.Text = "<button type='button' class='btn btn-danger' value=" + listElement.Id + " onclick='FillHidden(\"User\", this.value)'>Tareas de " + listElement.FirstName + "</button>";
                tempCell.CssClass = "results";
                tempRow.Cells.Add(tempCell);

                //Finalmente añadimos la tupla temporal.
                this.resultUserTable.Rows.Add(tempRow);
            }
            //Hacemos visible la tabla que originalmente es invisible.
            this.resultUserTable.Visible = true;
        }

        protected void BTEliminar_Click(object sender, EventArgs e)
        {
            Response.Redirect("EliminarTarea.aspx");
        }

        protected void btnSearchTask_Click(object sender, EventArgs e)
        {
            int user, category, project;
            String textFrom, textTo;
            DateTime dateFrom, dateTo;

            this.TaskSearchingMessage.Visible = true;

            textFrom = this.txtFrom.Text;
            textTo = this.txtTo.Text;

            user = Int16.Parse(this.hdnUser.Value);
            category = Int16.Parse(this.hdnUser.Value);
            project = Int16.Parse(this.hdnUser.Value);
            //Inicializamos las variables de fecha.
            if (textFrom != "")
            {
                dateFrom = DateTime.Parse(textFrom);
            }
            if (textTo != "")
            {
                dateTo = DateTime.Parse(textTo);
            }

            this.resultTaskTable.Visible = true;

            this.TaskSearchingMessage.Visible = false;

        }
    }
}