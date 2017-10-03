﻿using Core.Business;
using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webapp.WebForms
{
    public partial class IniciarSesion2 : System.Web.UI.Page
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
                Session["user"] = user;
                if (user.Role.Id == 1)
                {

                    Response.Redirect("~/WebForms/SearchProject.aspx");
                }
                else if (user.Role.Id == 2)
                {
                    Response.Redirect("~/Default.aspx");
                }

            }
            else
            {
                Response.Write("Error al iniciar sesión, nombre de usuario o contraseña incorrectos");
                TxtPassword.Text = "";
            }
        }
    }
}