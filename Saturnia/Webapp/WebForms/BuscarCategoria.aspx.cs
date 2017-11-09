using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Core.Business;
using Core.Domain;

namespace Webapp.WebForms
{
    public partial class BuscarCategoria : System.Web.UI.Page
    {
        private CategoryBusiness categoryBusiness;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.categoryBusiness = new CategoryBusiness();

            if (!IsPostBack)
            {
                this.btnSearch_Click(this, new EventArgs());
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            String name = txtName.Text;
            Category category = new Category();
            category.Name = name;
            List<Category> results = this.categoryBusiness.SearchCategory(category);
            TableRow tempRow;
            TableCell tempCell;

            foreach (Category listElement in results)
            {
                tempRow = new TableRow();
                tempCell = new TableCell();

                if (listElement.Id != -1)
                {
                    tempCell.Text = "<a class=results href=./MostrarCategoria.aspx?category=" + listElement.Id + ">" + listElement.Name + "</a>";
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