using Core.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Core.Data
{
    public class UserData
    {

        private String connectionString;

        public UserData()
        {
            ConnectionData connectionData = new ConnectionData();
            connectionString = connectionData.ConnectionString;
        }

      
        public User VerifyUser(User user)
        {
           
            SqlConnection connection = new SqlConnection(connectionString);
          
            SqlDataReader reader;  
            SqlCommand sqlCommand = new SqlCommand("SP_USER_VERIFICATION", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@NICKNAME", user.Nickname);
            sqlCommand.Parameters.AddWithValue("@PASSWORD", user.Password);
            try
            {
                sqlCommand.Connection.Open();
                sqlCommand.ExecuteNonQuery();

                reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    user.Id = reader.GetInt32(0);
                    user.FirstName = reader.GetString(1);
                    user.LastName = reader.GetString(2);
                    user.Role.Id = reader.GetInt32(3);
                }
              
                sqlCommand.Connection.Close();

                return user;
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
        }

        /// <summary>
        /// Metodo para obtener los datos de un colaborador en concreto.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User ShowUser(User user)
        {
            //Declaracion e inicializacion de variables e instancias.
            SqlConnection connection = new SqlConnection(connectionString);

            //Nombre del SP
            string sqlStoredProcedure = "SP_USER_SHOW";

            //Variables para ejecutar el SP
            SqlCommand sqlCommand;
            SqlParameter parameter;
            SqlDataReader reader;

            sqlCommand = new SqlCommand(sqlStoredProcedure, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            //Parametro que contendra el nombre para la busqueda.
            parameter = new SqlParameter("@ID", user.Id);
            sqlCommand.Parameters.Add(parameter);

            //Abrimos y ejecutamos el SP
            sqlCommand.Connection.Open();
            sqlCommand.ExecuteNonQuery();

            //Ejecutamos el lector para recibir lo devuelto.
            reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                user.FirstName = reader.GetString(0);
                user.LastName = reader.GetString(1);
                user.Nickname = reader.GetString(2);
                user.Role.Id = reader.GetInt32(3);
                user.Role.Name = reader.GetString(4);
                user.Role.Description = reader.GetString(5);
            }
            else
            {

                user.FirstName = "Error en conexión";
                user.LastName = "No se encontró al usuario";
                user.Nickname = "";
                user.Role.Id = 0;
                user.Role.Name = "Sin Rol";
                user.Role.Description = "Error de lectura";

            }

            //Cerramos la conexion.
            sqlCommand.Connection.Close();

            //Retornamos el usuario.
            return user;
        }

        /// <summary>
        /// Metodo para buscar usuarios basado en un nombre o apellido dado
        /// </summary>
        /// <param name="user">Entidad usuario con el indice de busqueda almacenado en FirstName</param>
        /// <returns>Una lista con al menos una entidad.</returns>
        public List<User> SearchUser(User user)
        {

            //Declaracion e inicializacion de variables e instancias.
            SqlConnection connection = new SqlConnection(this.connectionString);

            //Nombre del SP
            string sqlStoredProcedure = "SP_USER_SEARCH";

            //Variables para ejecutar el SP
            SqlCommand sqlCommand;
            SqlParameter parameter;
            SqlDataReader reader;

            //Lista de retorno.
            List<User> users = new List<User>();

            //Objeto temporal para llenar la lista.
            User tempUser;

            sqlCommand = new SqlCommand(sqlStoredProcedure, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            //Parametro que contendra el nombre para la busqueda.
            parameter = new SqlParameter("@NAME", user.FirstName);
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
                    tempUser = new User();
                    tempUser.Id = reader.GetInt32(0);
                    tempUser.FirstName = reader.GetString(1);
                    tempUser.LastName = reader.GetString(2);
                    users.Add(tempUser);
                }
            }
            else
            {
                //Si no hay resultados, agregamos un usuario con id -1 y nombre y apellidos que indiquen que no hubo resultados.
                tempUser = new User();
                tempUser.Id = -1;
                tempUser.FirstName = "No se encontraron";
                tempUser.LastName = "coincidencias";
                users.Add(tempUser);
            }

            //Cerramos la conexion.
            sqlCommand.Connection.Close();

            //Retornamos la lista.
            return users;

        }

        public Boolean AssignCollaboratorToProject(User user, Project project, char leader)
        {

            //Declaracion e inicializacion de variables e instancias.
            SqlConnection connection = new SqlConnection(this.connectionString);
            char response;

            //Nombre del SP
            string sqlStoredProcedure = "SP_ASSIGN_COLLABORATOR_PROJECT";

            //Variables para ejecutar el SP
            SqlCommand sqlCommand;
            SqlParameter parameter;
          

            sqlCommand = new SqlCommand(sqlStoredProcedure, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            //Parametro que contendra el id del usuario para asociar.
            parameter = new SqlParameter("@ID_USER", user.Id);
            sqlCommand.Parameters.Add(parameter);
            parameter = null; //Se destruye el parametro luego de agregado para evitar datos viejos.

            //Parametro que contendra el id del proyecto para asociar.
            parameter = new SqlParameter("@ID_PROJECT", project.Id);
            sqlCommand.Parameters.Add(parameter);
            parameter = null;//Se destruye el parametro luego de agregado para evitar datos viejos.

            //Parametro que contendra el un atributo que determina si el colaborador será lider o no.
            parameter = new SqlParameter("@IsLeader", leader);
            sqlCommand.Parameters.Add(parameter);
            parameter = null;//Se destruye el parametro luego de agregado para evitar datos viejos.

            parameter = new SqlParameter("@R", "");
            parameter.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(parameter);

            //Abrimos y ejecutamos el SP
            sqlCommand.Connection.Open();
            sqlCommand.ExecuteNonQuery();
            
            response = sqlCommand.Parameters["@R"].Value.ToString()[0];
            
            //Cerramos la conexion.
            sqlCommand.Connection.Close();

            if (response == 'y')
            {
                return true;
            } else
            {
                return false;
            }
        }

    }
}
