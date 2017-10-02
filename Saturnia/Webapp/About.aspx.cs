using Core.Data;
using Core.Domain;
using System;
using System.Web.UI;

namespace Webapp
{
    public partial class About : Page
    {
        public static int b=0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BT_Eliminar_Click(object sender, EventArgs e)
        {
            
            Response.Write("<script>confirmar=confirm('¿Eres mayor de edad ? '); if(confirmar){ alert('acepto');" + "}" + "else{ alert('Diste a Cancelar')}</script>");
             CategoryData cd = new CategoryData();
             Category category = new Category();
             int a= 0;
             cd.DeleteCategory(category);
             //alert('Usuario incorrecto o no existe');
             //Response.Write("<script>confirmar=confirm('¿Eres mayor de edad ? '); if(confirmar){ alert("+a+");"+"}"+"else{ alert('Diste a Cancelar')}</script>");
             Response.Write("<script>confirmar=confirm('¿Eres mayor de edad ? '); if(confirmar){ alert("+ a+ ");"+  b + " = " + 3+";}" + "else{ alert('Diste a Cancelar');" + "}</script>");
            // Response.Write("<script>confirmar=confirm('¿Eres mayor de edad ? '); if(confirmar){ alert(" + a + ");" + "}" + "else{ alert('Diste a Cancelar')}</script>");
             //MessageBox.Show("¿Esta seguro que desea borrar el proyecto?","Confirmar eliminación",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
         
        }
    }
}