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

        public void DeleteProject(Project project)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();//abre la conexion
            SqlCommand cmd;

            cmd = new SqlCommand("sp_project_delete", sqlConnection);//agrego mi procedimiento almacenado para utilizarlo
            cmd.CommandType = System.Data.CommandType.StoredProcedure;//indico que voy a utilizar un procedimiento almacenado

            // enviarle parametro al procedimiento
            cmd.Parameters.AddWithValue("@id_project", project.Id);
            
            cmd.ExecuteNonQuery();//ejecuto el procedimiento almacenado

            sqlConnection.Close();//cierra la conexion
        }//DeleteProject

        public Project GetProject(int idProject)
        {

            //paso 1
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand("sp_get_project", sqlConnection);//agrego mi procedimiento almacenado para utilizarlo
            cmd.CommandType = System.Data.CommandType.StoredProcedure;//indico que voy a utilizar un procedimiento almacenado
                                                                      // enviarle parametro al procedimiento
            cmd.Parameters.AddWithValue("@id_project", idProject);

            SqlDataReader drProject = cmd.ExecuteReader();
            Project project = null;
            while (drProject.Read())
            {

                project = new Project();
                project.Id = Int32.Parse(drProject["id"].ToString());
                project.Name = drProject["name"].ToString();
                project.State = bool.Parse(drProject["state"].ToString());
                project.Description = drProject["description"].ToString();
                project.EstimatedHours = Int32.Parse(drProject["estimated_hours"].ToString());
                project.StartDate = Convert.ToDateTime(drProject["start_date"].ToString());
            }//while
            sqlConnection.Close();
            return project;

        }//GetProject()

    }//ProjectData

}//namespace
