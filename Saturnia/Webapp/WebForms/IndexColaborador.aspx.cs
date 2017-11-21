﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webapp.WebForms
{
    public partial class IndexColaborador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"] == null)
                Label1.Text = Session["userName"].ToString();
            else
                Response.Redirect("~/WebForms/IniciarSesion.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("EliminarTarea.aspx");
        }
    }
}