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
    public partial class AsignarUsuario : System.Web.UI.Page
    {

        private ProjectBusiness projectBusiness;
        private UserBusiness userBusiness;
        private int currentProject; //Esta variable nos permite guardar el Id del proyecto reibido en PageLoad para futuros usos.

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
            //Si, viene un id de proyecto.
            if (Request.QueryString["project"] != null)
            {
                //Quiere decir que alguien seleccionó un proyecto para asignar.
                Project project = new Project();
                this.currentProject = Int32.Parse(Request.QueryString["project"].ToString());
                project.Id = this.currentProject;

                this.projectBusiness = new ProjectBusiness();
                this.userBusiness = new UserBusiness();
                
                //Traemos los datos del proyecto
                project = this.projectBusiness.ShowProject(project);

                //Colocamos el nombre del proyecto visible al usuario.
                this.txtProjectName.Text = project.Name;

                //Si hubiese una variable llamada user
                if (Request.QueryString["user"] != null)
                {
                    //Quiere decir que en la página siguiente, el usuario quiso cambiar el colaborador a asociar.
                    this.txtUserName.Text = Request.QueryString["user"].ToString(); //Colocamos el nombre a buscar en el textfield.
                    //Emulamos un click en el boton para buscar usuario, así la funcionalidad se encargará de hacer la nueva búsqueda.
                    btnSearchUser_Click(this, new EventArgs());
                }

            } else
            {
                //Si no había id de proyecto, quiere decir que el acceso a esta página no es según el orden normal.
                //Redireccionamos a la página de buscar proyectos para que busque y en base a uno venga a esta página.
                Response.Redirect("./BuscarProyecto.aspx");
            }
        }

        protected void btnSearchProject_Click(object sender, EventArgs e)
        {
            //Para permitir que el usuario busque otro proyecto, volvemos a buscar proyecto.
            Response.Redirect("./BuscarProyecto.aspx");
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
                tempCell.CssClass = "results";
                tempRow.Cells.Add(tempCell);

                //Para evitar contaminación, "destruímos" la variable y la inicializamos nuevamente para usarla de nuevo.
                tempCell = null;
                tempCell = new TableCell();
                //Solo que ahora, la cargamos con el apellido y la agregamos a la tabla.
                tempCell.Text = listElement.LastName;
                tempCell.CssClass = "results";
                tempRow.Cells.Add(tempCell);

                //Nuevamente la "destruímos" para cargarla con un link que permitirá la asociación del usuario al proyecto.
                tempCell = null;
                tempCell = new TableCell();
                tempCell.CssClass = "results";
                if (listElement.Id != -1)
                {
                    tempCell.Text = "<a class=results href=./AsociarUsuario.aspx?user=" + listElement.Id + "&project=" + this.currentProject + ">  Asignar al proyecto </a>";
                } else
                {
                    tempCell.Text = "<a class=results>Para asignar un colaborador, seleccione uno existente por favor</a>";
                }
                tempRow.Cells.Add(tempCell);
                
                //Finalmente añadimos la tupla temporal.
                resultTable.Rows.Add(tempRow);
            }
            //Hacemos visible la tabla que originalmente es invisible.
            resultTable.Visible = true;
        }
    }
}