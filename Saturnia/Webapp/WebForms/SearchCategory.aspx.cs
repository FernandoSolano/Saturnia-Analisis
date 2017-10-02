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
    public partial class SearchCategory : System.Web.UI.Page
    {
        private CategoryBusiness categoryBusiness;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.categoryBusiness = new CategoryBusiness();
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

                tempCell.Text = "<a href=./ShowCategory.aspx?category=" + listElement.Id + ">" + listElement.Name + "</a>";

                tempRow.Cells.Add(tempCell);
                resultTable.Rows.Add(tempRow);
            }

            resultTable.Visible = true;
        }
    }
}