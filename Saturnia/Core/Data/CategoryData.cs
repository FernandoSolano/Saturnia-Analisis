using Core.Domain;
using System;
using System.Collections.Generic;
using System.Data;
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


        public Category AddCategory(Category category)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand("sp_category_create", connection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter id = new SqlParameter("@id", System.Data.SqlDbType.Int);
            id.Direction = System.Data.ParameterDirection.Output;
            sqlCommand.Parameters.Add(id);
            sqlCommand.Parameters.Add(new SqlParameter("@name", category.Name));
            sqlCommand.Parameters.Add(new SqlParameter("@description", category.Description));
            try
            {
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                category.Id = Int32.Parse(sqlCommand.Parameters["@id"].Value.ToString());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            if (connection != null)
            {
                connection.Close();
            }
            return category;
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

        /// <summary>
        /// Metodo que busca coincidencias de categorias según un nombre dado
        /// </summary>
        /// <param name="category">Nombre para buscar categorias.</param>
        /// <returns>Lista de categorias con minimo 1 resultado.</returns>
        public List<Category> SearchCategory(Category category)
        {
            //Declaracion e inicializacion de variables e instancias.
            SqlConnection connection = new SqlConnection(connectionString);

            //Nombre del SP
            string sqlStoredProcedure = "SP_CATEGORY_SEARCH";

            //Variables para ejecutar el SP
            SqlCommand sqlCommand;
            SqlParameter parameter;
            SqlDataReader reader;

            //Lista de retorno.
            List<Category> categories = new List<Category>();

            //Objeto temporal para llenar la lista.
            Category tempCategory;

            sqlCommand = new SqlCommand(sqlStoredProcedure, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            //Parametro que contendra el nombre para la busqueda.
            parameter = new SqlParameter("@NAME", category.Name);
            sqlCommand.Parameters.Add(parameter);

            //Abrimos y ejecutamos el SP
            sqlCommand.Connection.Open();
            sqlCommand.ExecuteNonQuery();

            //Ejecutamos el lector para recibir lo devuelto.
            reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                //Si hubiesen resultados, los añadimos uno a uno a la lista.
                while (reader.Read())
                {
                    tempCategory = new Category();
                    tempCategory.Id = reader.GetInt32(0);
                    tempCategory.Name = reader.GetString(1);
                    categories.Add(tempCategory);
                }
            }
            else
            {
                //Si no hay resultados, agregamos un proyecto con id -1 y nombre que indique que no hubo resultados.
                tempCategory = new Category();
                tempCategory.Id = -1;
                tempCategory.Name = "No se encontraron coincidencias";
                categories.Add(tempCategory);
            }

            //Cerramos la conexion.
            sqlCommand.Connection.Close();

            //Retornamos la lista.
            return categories;

        }

    }//CategoryData

}//namespace
