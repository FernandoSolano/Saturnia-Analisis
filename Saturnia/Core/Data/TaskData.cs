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
            SqlCommand sqlCommand = new SqlCommand("sp_task_update", connection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            sqlCommand.Parameters.Add(new SqlParameter("@id", task.Id));
            sqlCommand.Parameters.Add(new SqlParameter("@hours", task.Hours));
            sqlCommand.Parameters.Add(new SqlParameter("@extra_hours", task.ExtraHours));
            sqlCommand.Parameters.Add(new SqlParameter("@date", task.Date));
            sqlCommand.Parameters.Add(new SqlParameter("@description", task.Description));
     

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

        public List<Task> GetTaskByCollaborator(Task task)
        {
            List<Task> tasks = new List<Task>();
            Task temporalTask;

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand("SP_TASK_BY_COLLABORATOR_SEARCH", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Id", task.Collaborator.Id);

            SqlDataReader reader;
            try
            {
                sqlCommand.Connection.Open();
                reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    temporalTask = new Task();
                    temporalTask.Id = Int32.Parse(reader["id"].ToString());
                    temporalTask.Hours = float.Parse(reader["hours"].ToString());
                    temporalTask.ExtraHours = Boolean.Parse(reader["extra_hours"].ToString());
                    temporalTask.Date = DateTime.Parse(reader["date"].ToString());
                    temporalTask.Description = reader["description"].ToString();
                    temporalTask.Project.Name = reader["project_name"].ToString();
                    temporalTask.Category.Name = reader["category_name"].ToString();
                    temporalTask.Project.Id = Int32.Parse(reader["project_id"].ToString());
                    temporalTask.Category.Id = Int32.Parse(reader["category_id"].ToString());
                    temporalTask.Collaborator.Id = Int32.Parse(reader["collaborator_id"].ToString());
                    tasks.Add(temporalTask);
                }



                sqlCommand.Connection.Close();
                return tasks;
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
        /// <summary>
        /// Método que busca una tárea en base a filtrado.
        /// </summary>
        /// <param name="task">Tarea que contiene los filtros para la búsqueda.</param>
        /// <returns>Retorna una lista de tareas que coincidan con la búsqueda.</returns>
        public List<Task> Search(Task task)
        {
            //Declaracion e inicializacion de variables e instancias.
            SqlConnection connection = new SqlConnection(connectionString);

            //Nombre del SP
            string sqlStoredProcedure = "SP_SEARCH_TASK_FILTERED";

            //Variables para ejecutar el SP
            SqlCommand sqlCommand;
            SqlParameter parameter;
            SqlDataReader reader;

            //Lista de retorno.
            List<Task> tasks = new List<Task>();

            //Objeto temporal para llenar la lista.
            Task tempTask;

            sqlCommand = new SqlCommand(sqlStoredProcedure, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            //Parametro que contendra la descripción para la búsqueda.
            parameter = new SqlParameter("@_Description", task.Description);
            sqlCommand.Parameters.Add(parameter);

            //Parametro que contendra el filtro por proyecto.
            parameter = new SqlParameter("@_Project", task.Project.Id);
            sqlCommand.Parameters.Add(parameter);

            //Parametro que contendra el filtro por usuario.
            parameter = new SqlParameter("@_User", task.Collaborator.Id);
            sqlCommand.Parameters.Add(parameter);

            //Parametro que contendra el filtro por categoria.
            parameter = new SqlParameter("@_Category", task.Category.Id);
            sqlCommand.Parameters.Add(parameter);

            //Parametro que contendra la fecha "desde".
            parameter = new SqlParameter("@_Date_From", task.Date);
            sqlCommand.Parameters.Add(parameter);

            //Parametro que contendra la fecha "hasta".
            //Si proyecto trae en su descripción la palabra "Same" quiere decir que ambas fechas son iguales.
            //Lo que nos hace tomar la desición de enviar nuevamente task.date, sino se hace un parse.
            parameter = new SqlParameter("@_Date_To", 
                task.Project.Description == "Same" ? task.Date : DateTime.Parse(task.Project.Description)
            );
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
                    tempTask = new Task();
                    tempTask.Id = reader.GetInt32(0);
                    tempTask.Hours = float.Parse(reader.GetDouble(1).ToString());
                    tempTask.ExtraHours = reader.GetBoolean(2);
                    tempTask.Date = reader.GetDateTime(3);
                    tempTask.Description = reader.GetString(4);
                    tempTask.Project.Name = reader.GetString(5);
                    tempTask.Collaborator.FirstName = reader.GetString(6);
                    tempTask.Collaborator.LastName = reader.GetString(7);
                    tempTask.Category.Name = reader.GetString(8);
                    tasks.Add(tempTask);
                }
            }
            else
            {
                //Si no hay resultados, agregamos un proyecto con id -1 y nombre que indique que no hubo resultados.
                tempTask = new Task();
                tempTask.Id = -1;
                tempTask.Hours = 0;
                tempTask.ExtraHours = false;
                tempTask.Date = DateTime.Today;
                tempTask.Description = "No se encontraron coincidencias";
                tempTask.Project.Name = "";
                tempTask.Collaborator.FirstName = "";
                tempTask.Category.Name = "";
                tasks.Add(tempTask);
            }

            //Cerramos la conexion.
            sqlCommand.Connection.Close();

            //Retornamos la lista.
            return tasks;
        }

        /// <summary>
        /// Método que busca los datos para generar un reporte en base a criterios dados en la pantalla.
        /// </summary>
        /// <param name="task">Tarea que contiene los criterios para la búsqueda.</param>
        /// <returns>Una lista de tareas que se usará para generar el reporte.</returns>
        public List<Task> GenerateReport(Task task)
        {
            //Declaracion e inicializacion de variables e instancias.
            SqlConnection connection = new SqlConnection(connectionString);

            //Nombre del SP
            string sqlStoredProcedure = "SP_GENERATE_REPORT_FILTERED";

            //Variables para ejecutar el SP
            SqlCommand sqlCommand;
            SqlParameter parameter;
            SqlDataReader reader;

            //Lista de retorno.
            List<Task> tasks = new List<Task>();

            //Objeto temporal para llenar la lista.
            Task tempTask;

            sqlCommand = new SqlCommand(sqlStoredProcedure, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            //Parametro que contendra el filtro por proyecto.
            parameter = new SqlParameter("@_Project", task.Project.Id);
            sqlCommand.Parameters.Add(parameter);

            //Parametro que contendra el filtro por usuario.
            parameter = new SqlParameter("@_User", task.Collaborator.Id);
            sqlCommand.Parameters.Add(parameter);

            //Parametro que contendra el filtro por categoria.
            parameter = new SqlParameter("@_Category", task.Category.Id);
            sqlCommand.Parameters.Add(parameter);

            //Parametro que contendra la fecha "desde".
            parameter = new SqlParameter("@_Date_From", task.Date);
            sqlCommand.Parameters.Add(parameter);

            //Parametro que contendra la fecha "hasta".
            //Si proyecto trae en su descripción la palabra "Same" quiere decir que ambas fechas son iguales.
            //Lo que nos hace tomar la desición de enviar nuevamente task.date, sino se hace un parse.
            parameter = new SqlParameter("@_Date_To",
                task.Project.Description == "Same" ? task.Date : DateTime.Parse(task.Project.Description)
            );
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
                    tempTask = new Task();
                    tempTask.Hours = float.Parse(reader.GetDouble(0).ToString());
                    tempTask.ExtraHours = reader.GetBoolean(1);
                    tempTask.Project.Name = reader.GetString(2);
                    tempTask.Collaborator.FirstName = reader.GetString(3);
                    tempTask.Collaborator.LastName = reader.GetString(4);
                    tempTask.Category.Name = reader.GetString(5);
                    tasks.Add(tempTask);
                }
            }
            else
            {
                //Si no hay resultados, agregamos un proyecto con id -1 y nombre que indique que no hubo resultados.
                tempTask = new Task();
                tempTask.Hours = 0;
                tempTask.ExtraHours = false;
                tempTask.Project.Name = "Sin resultados, esto sucede por no proporcionar un filtro o rango de fechas";
                tempTask.Collaborator.FirstName = "Sin resultados, esto sucede por no proporcionar un filtro o rango de fechas";
                tempTask.Collaborator.LastName = "Sin resultados, esto sucede por no proporcionar un filtro o rango de fechas";
                tempTask.Category.Name = "Sin resultados, esto sucede por no proporcionar un filtro o rango de fechas";
                tasks.Add(tempTask);
            }

            //Cerramos la conexion.
            sqlCommand.Connection.Close();

            //Retornamos la lista.
            return tasks;
        }

    }
}
