﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Domain;
using System.Data.SqlClient;
using System.Data;

namespace Core.Data
{
    /// <summary>
    /// Clase que se encarga de todas las operaciones de recuperacion de datos de la entidad Proyecto.
    /// </summary>
    public class ProjectData
    {
        private String connectionString;

        public ProjectData()
        {
            ConnectionData connectionData = new ConnectionData();
            connectionString = connectionData.ConnectionString;
        }
      
        /// <summary>
        /// Busqueda de proyectos con nombres similares al recibido.
        /// </summary>
        /// <param name="project">El objeto que contiene el nombre a buscar.</param>
        /// <returns> Una lista de proyectos que coincidieron con el nombre dado.</returns>
        public List <Project> SearchProject(Project project)
        {
            //Declaracion e inicializacion de variables e instancias.
            SqlConnection connection = new SqlConnection(connectionString);
            
            //Nombre del SP
            string sqlStoredProcedure = "SP_PROJECT_SEARCH";

            //Variables para ejecutar el SP
            SqlCommand sqlCommand;
            SqlParameter parameter;
            SqlDataReader reader;

            //Lista de retorno.
            List<Project> projects = new List<Project>();
            
            //Objeto temporal para llenar la lista.
            Project tempProject;

            sqlCommand = new SqlCommand(sqlStoredProcedure, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            //Parametro que contendra el nombre para la busqueda.
            parameter = new SqlParameter("@NAME", project.Name);
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
                    tempProject = new Project();
                    tempProject.Id = reader.GetInt32(0);
                    tempProject.Name = reader.GetString(1);
                    projects.Add(tempProject);
                }
            } else
            {
                //Si no hay resultados, agregamos un proyecto con id -1 y nombre que indique que no hubo resultados.
                tempProject = new Project();
                tempProject.Id = -1;
                tempProject.Name = "No se encontraron coincidencias";
                projects.Add(tempProject);
            }

            //Cerramos la conexion.
            sqlCommand.Connection.Close();

            //Retornamos la lista.
            return projects;

        }

        public Project ShowProject(Project project)
        {

            //Declaracion e inicializacion de variables e instancias.
            SqlConnection connection = new SqlConnection(connectionString);

            //Nombre del SP
            string sqlStoredProcedure = "SP_PROJECT_SHOW";

            //Variables para ejecutar el SP
            SqlCommand sqlCommand;
            SqlParameter parameter;
            SqlDataReader reader;

            //Proyecto de retorno.
            Project projectToShow = new Project();

            sqlCommand = new SqlCommand(sqlStoredProcedure, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            //Parametro que contendra el nombre para la busqueda.
            parameter = new SqlParameter("@ID", project.Id);
            sqlCommand.Parameters.Add(parameter);

            //Abrimos y ejecutamos el SP
            sqlCommand.Connection.Open();
            sqlCommand.ExecuteNonQuery();

            //Ejecutamos el lector para recibir lo devuelto.
            reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                project.Name = reader.GetString(0);
                project.State = reader.GetBoolean(1);
                project.Description = reader.GetString(2);
                project.EstimatedHours = reader.GetInt32(3);
                project.StartDate = reader.GetDateTime(4);
                
                if (reader.IsDBNull(5) == false)
                {
                    project.EndDate = reader.GetDateTime(5);
                }
                

            } else
            {

                project.Name = "Error en conexión";
                project.State = false;
                project.Description = "Hubo un error en ProjectData";
                project.EstimatedHours = 0;
                project.StartDate = new DateTime(1995,8,8);
                project.EndDate = new DateTime(2020, 8, 8);

            }

            //Cerramos la conexion.
            sqlCommand.Connection.Close();

            //Retornamos la lista.
            return project;
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
