using Core.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace Core.Data
{
    public class TaskData
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

        public void DeleteTask(Task task)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();//abre la conexion
            SqlCommand cmd;

            cmd = new SqlCommand("sp_task_delete", sqlConnection);//agrego mi procedimiento almacenado para utilizarlo
            cmd.CommandType = System.Data.CommandType.StoredProcedure;//indico que voy a utilizar un procedimiento almacenado

            // enviarle parametro al procedimiento
            cmd.Parameters.AddWithValue("@id_task", task.Id);

            cmd.ExecuteNonQuery();//ejecuto el procedimiento almacenado

            sqlConnection.Close();//cierra la conexion
        }//DeleteTask

        public Task GetHoursByDateAndCollaborator(Task task)
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
                task.Hours = hours;
                sqlCommand.Connection.Close();
                return task;
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

        public Task ShowTask(Task task)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string sqlProcedure = "SP_TASK_SHOW";
            SqlCommand command = new SqlCommand(sqlProcedure, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@ID", task.Id));

            connection.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            dataReader.Read();
            //hours, extra_hours, date, description
            //project_id, collaborator_id, category_id
            task.Hours = float.Parse(dataReader["hours"].ToString());
            task.ExtraHours = Boolean.Parse(dataReader["extra_hours"].ToString());
            task.Date = DateTime.Parse(dataReader["date"].ToString());
            task.Description = dataReader["description"].ToString();
            task.Project.Id = Int32.Parse(dataReader["project_id"].ToString());
            task.Collaborator.Id = Int32.Parse(dataReader["collaborator_id"].ToString());
            task.Category.Id = Int32.Parse(dataReader["category_id"].ToString());
            connection.Close();
            return task;
        }

        public void UpdateTask(Task task)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand("sp_update_task", connection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            
            sqlCommand.Parameters.Add(new SqlParameter("@id", task.Id));
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
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            if (connection != null)
            {
                connection.Close();
            }
        }

    }
}
