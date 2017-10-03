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
    public partial class SearchProject : System.Web.UI.Page
    {

        private ProjectBusiness projectBusiness;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.projectBusiness = new ProjectBusiness();

            if (Request.QueryString["project"] != null)
            {
                this.txtName.Text = Request.QueryString["project"].ToString();
                btnSearch_Click(this, new EventArgs());
            }

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

                tempCell.Text = "<a href=./ShowProject.aspx?project=" + listElement.Id + ">" + listElement.Name + "</a>";

                tempRow.Cells.Add(tempCell);

                tempCell = null;
                tempCell = new TableCell();
                tempCell.Text = "<a href=./AsignarUsuario.aspx?project=" + listElement.Id + "> Asignar Usuario </a>";

                tempRow.Cells.Add(tempCell);

                resultTable.Rows.Add(tempRow);
            }

            resultTable.Visible = true;
        }
    }
}