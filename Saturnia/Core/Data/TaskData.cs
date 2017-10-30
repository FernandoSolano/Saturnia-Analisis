using Core.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace Core.Data
{
    class TaskData
    {

        private String connectionString;

        public TaskData()
        {
            ConnectionData connectionData = new ConnectionData();
            connectionString = connectionData.ConnectionString;
        }

        public Task AddTask(Task task)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand("sp_task_create", connection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter id = new SqlParameter("@id", System.Data.SqlDbType.Int);
            id.Direction = System.Data.ParameterDirection.Output;
            sqlCommand.Parameters.Add(id);
            sqlCommand.Parameters.Add(new SqlParameter("@hours", task.Hours));
            sqlCommand.Parameters.Add(new SqlParameter("@extra_hours", task.ExtraHours));
            sqlCommand.Parameters.Add(new SqlParameter("@date", task.Date));
            sqlCommand.Parameters.Add(new SqlParameter("@description", task.Description));
            sqlCommand.Parameters.Add(new SqlParameter("@project_id", task.Project.Id));
            sqlCommand.Parameters.Add(new SqlParameter("@collaborator_id", task.Collaborator.Id));
            sqlCommand.Parameters.Add(new SqlParameter("@category_id", task.Category.Id));
            try
            {
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                task.Id = Int32.Parse(sqlCommand.Parameters["@id"].Value.ToString());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            if (connection != null)
            {
                connection.Close();
            }
            return task;
        }

        public float GetHoursByDateAndCollaborator(Task task)
        {
            float hours = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand("SP_GET_HOURS_BY_DATE_AND_COLLABORATOR", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter DBHours = new SqlParameter("@hours", System.Data.SqlDbType.Float);
            DBHours.Direction = System.Data.ParameterDirection.Output;
            sqlCommand.Parameters.Add(DBHours);
            sqlCommand.Parameters.AddWithValue("@collaborator_id", task.Collaborator.Id);
            sqlCommand.Parameters.AddWithValue("@date", task.Date);
            sqlCommand.Parameters.AddWithValue("@extra_hour", task.ExtraHours);

            try
            {
                sqlCommand.Connection.Open();
                sqlCommand.ExecuteNonQuery();

                hours = float.Parse(sqlCommand.Parameters["@hours"].Value.ToString());

                sqlCommand.Connection.Close();
                return hours;
            }
            catch (SqlException sqlException)
            {
                throw sqlException;
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
