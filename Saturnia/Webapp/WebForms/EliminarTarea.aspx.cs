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
    public partial class EliminarTarea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BTCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarTareaColaborador.aspx");
        }

        protected void BTAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                TaskBusiness taskBusiness = new TaskBusiness();
                Task task = new Task();
                task.Id = Int32.Parse(Request.QueryString["id"]);
                task = taskBusiness.ShowTask(task);
                taskBusiness.DeleteTask(task);
                Response.Redirect("BuscarTareaColaborador.aspx");
            }//try
            catch
            {
                LabelMensaje.Text = "La tarea no pudo ser eliminada";
            }//catch
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}