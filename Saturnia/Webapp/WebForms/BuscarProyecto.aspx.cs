using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Core.Domain;
using Core.Business;

namespace Webapp.WebForms
{
    public partial class BuscarProyecto : System.Web.UI.Page
    {

        private ProjectBusiness projectBusiness;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.projectBusiness = new ProjectBusiness();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            String name = txtName.Text;
            Project project = new Project();
            project.Name = name;
            List<Project> results = this.projectBusiness.SearchProject(project);
            TableRow tempRow;
            TableCell tempCell;

            foreach(Project listElement in results)
            {
                tempRow = new TableRow();
                tempCell = new TableCell();

                if (listElement.Id != -1)
                {
                    tempCell.Text = "<a class=results href=./MostrarProyecto.aspx?project=" + listElement.Id + ">" + listElement.Name + "</a>";
                    tempCell.CssClass = "results";
                    tempRow.Cells.Add(tempCell);

                    tempCell = null;
                    tempCell = new TableCell();
                    tempCell.Text = "<a class=results href=./AsignarUsuario.aspx?project=" + listElement.Id + "> Asignar Usuario </a>";
                } else
                {
                    tempCell.Text = listElement.Name;
                }

                tempCell.CssClass = "results";

                tempRow.Cells.Add(tempCell);
                tempRow.CssClass = "results";
                resultTable.Rows.Add(tempRow);
            }

            resultTable.Visible = true;
        }
    }
}