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
    }
}
