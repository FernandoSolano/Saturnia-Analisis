using Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Core.Data
{
    public class CategoryData
    {
        private String connectionString;

        public CategoryData()
        {
            ConnectionData connectionData = new ConnectionData();
            connectionString = connectionData.ConnectionString;
        }

        public void DeleteCategory(Category category)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();//abre la conexion
            SqlCommand cmd;

            cmd = new SqlCommand("sp_category_delete", sqlConnection);//agrego mi procedimiento almacenado para utilizarlo
            cmd.CommandType = System.Data.CommandType.StoredProcedure;//indico que voy a utilizar un procedimiento almacenado

            // enviarle parametro al procedimiento
            cmd.Parameters.AddWithValue("@id_category", category.Id);

            cmd.ExecuteNonQuery();//ejecuto el procedimiento almacenado

            sqlConnection.Close();//cierra la conexion
        }//DeleteCategory

        public Category GetCategory(int idCategory)
        {

            //paso 1
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand("sp_get_category", sqlConnection);//agrego mi procedimiento almacenado para utilizarlo
            cmd.CommandType = System.Data.CommandType.StoredProcedure;//indico que voy a utilizar un procedimiento almacenado

            // enviarle parametro al procedimiento
            cmd.Parameters.AddWithValue("@id_category", idCategory);

            SqlDataReader drCategory = cmd.ExecuteReader();
            Category category = null;
            while (drCategory.Read())
            {

                category = new Category();
                category.Id = Int32.Parse(drCategory["id"].ToString());
                category.Name = drCategory["name"].ToString();
                category.Description = drCategory["description"].ToString();
            }//while
            sqlConnection.Close();
            return category;

        }//GetCategory()

    }//CategoryData

}//namespace
