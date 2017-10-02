using Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Core.Data
{
    public class ProjectData
    {
        private String connectionString;

        public ProjectData()
        {
            ConnectionData connectionData = new ConnectionData();
            connectionString = connectionData.ConnectionString;
        }

        public Project AddProject(Project project)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand("sp_project_create", connection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter id = new SqlParameter("@id", System.Data.SqlDbType.Int);
            id.Direction = System.Data.ParameterDirection.Output;
            sqlCommand.Parameters.Add(id);
            sqlCommand.Parameters.Add(new SqlParameter("@name", project.Name));
            sqlCommand.Parameters.Add(new SqlParameter("@state", project.State));
            sqlCommand.Parameters.Add(new SqlParameter("@description", project.Description));
            sqlCommand.Parameters.Add(new SqlParameter("@estimated_hours", project.EstimatedHours));
            sqlCommand.Parameters.Add(new SqlParameter("@start_date", project.StartDate));
            try
            {
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                project.Id = Int32.Parse(sqlCommand.Parameters["@id"].Value.ToString());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            if (connection != null)
            {
                connection.Close();
            }
            return project;
        }
    }
}
