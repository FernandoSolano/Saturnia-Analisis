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

        protected void Page_Load(object sender, EventArgs e)
        {
            this.userBusiness = new UserBusiness();
            this.projectBusiness = new ProjectBusiness();
            this.categoryBusiness = new CategoryBusiness();
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

                //Finalmente añadimos la tupla temporal.
                this.resultUserTable.Rows.Add(tempRow);
            }
            //Hacemos visible la tabla que originalmente es invisible.
            this.resultUserTable.Visible = true;
        }
    }
}