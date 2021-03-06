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
    public partial class ActualizarCategoria1 : System.Web.UI.Page
    {

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
                    Response.Redirect("./IndexColaborador.aspx");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                if (Request.QueryString["id"] != null)
                {
                    Category category = new Category();
                    category.Id = Int32.Parse(Request.QueryString["id"]);
                    category = this.categoryBusiness.ShowCategory(category);

                    this.tbName.Text = category.Name;

                    this.tbDescription.Text = category.Description;
                }
                else
                {

                }
            }
        }

        private CategoryBusiness categoryBusiness;

        public ActualizarCategoria1()
        {
            this.categoryBusiness = new CategoryBusiness();
        }

      

        protected void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.Id = Int32.Parse(Request.QueryString["id"]);
            category.Name = tbName.Text;
            category.Description = tbDescription.Text;
            this.categoryBusiness.UpdateCategory(category);
            Response.Write("<script>alert('Actualización exitosa.');</script>");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForms/BuscarCategoria.aspx");
        }



    }
}