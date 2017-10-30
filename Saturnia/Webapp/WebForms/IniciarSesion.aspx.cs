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
    public partial class IniciarSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Nickname = TxtNickname.Text;
            user.Password = TxtPassword.Text;
            UserBusiness userBusiness = new UserBusiness();
            user = userBusiness.VerifyUser(user);

            if (user.Id > 0)
            {
                Session["userId"] = user.Id;
                Session["userName"] = user.FirstName+" "+user.LastName;
                Session["userRol"] = user.Role.Id;
                if (user.Role.Id == 1)
                {

                    Response.Redirect("~/WebForms/BuscarProyecto.aspx");
                }
                else if (user.Role.Id == 2)
                {
                    Response.Redirect("~/WebForms/CrearTarea.aspx");
                }

            }
            else
            {
               LblMessage.Text = "Error al iniciar sesión, nombre de usuario o contraseña incorrectos";
                TxtPassword.Text = "";
            }
        }
    }
}