using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webapp.WebForms
{
    public partial class GenerarReporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userRole"] == null)
            {
                Response.Redirect("~/WebForms/IniciarSesion.aspx");
            }
            else
            {
                this.lblUserName.Text = Session["userName"].ToString();
            }
        }

        protected void btnSearchUser_Click(object sender, EventArgs e)
        {

        }

        protected void btnSearchCategory_Click(object sender, EventArgs e)
        {

        }

        protected void btnSearchProject_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Método que oculta una columna de una tabla, tomado de:
        /// https://stackoverflow.com/questions/7275135/how-do-i-hide-a-column-in-an-asptable
        /// por: https://stackoverflow.com/users/874888/jdavies
        /// </summary>
        /// <param name="table">Tabla a la que le ocultaremos una o más columnas.</param>
        /// <param name="index">Número de columnas a ocultar.</param>
        private void HideColumn(Table table, int index)
        {
            foreach (TableRow row in table.Rows)
            {
                if (row.Cells.Count - 1 >= index)
                {
                    row.Cells[index].Visible = false;
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("./IndexAdmin.aspx");
        }

        protected void btnGenerateReport_Click(object sender, EventArgs e)
        {
            
        }
    }
}