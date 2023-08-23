using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccess
{
    public class UsuarioDAL
    {
        HandlerConnection handlerConnection = new HandlerConnection();
        public bool CrearUsuario(Usuario newUser)
        {
            try
            {
                using (SqlConnection connection = handlerConnection.GetConnection())
                {
                    SqlCommand sqlCommand = connection.CreateCommand();
                    sqlCommand.CommandText = "sp_CrearUsuario";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Username", newUser.Username);
                    sqlCommand.Parameters.AddWithValue("@Passwd", newUser.Password);
                    sqlCommand.Parameters.AddWithValue("@Rol", newUser.Rol);

                    int filasAfectada = sqlCommand.ExecuteNonQuery();
                    if (filasAfectada > 0) return true;
                    return false;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        //Trabajando en el login buscando el usuario por sus credenciales
        public IEnumerable<Usuario> ValidarUsuarioCredenciales(Usuario usuario)
        {
            try
            {
                List<Usuario> users = new List<Usuario>();
                string sqlCommand = "SELECT Username, Passwd, Rol FROM usuario WHERE username = '" + usuario.Username + "' AND passwd = '" + usuario.Password + "' ";

                using (SqlConnection connection = handlerConnection.GetConnection())
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = sqlCommand;

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            users.Add(new Usuario()
                            {
                                Username = dataReader["Username"].ToString(),
                                Password = dataReader["Passwd"].ToString(),
                                Rol = dataReader["Rol"].ToString()
                            });
                        }
                    }
                }

                return users;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Usuario> GetAllUsers()
        {
            try
            {
                List<Usuario> users = new List<Usuario>();
                string sqlCommand = "SELECT * FROM Usuario ";

                using (SqlConnection connection = handlerConnection.GetConnection())
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = sqlCommand;

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            users.Add(new Usuario()
                            {
                                Username = dataReader["Username"].ToString() ?? "",
                                Password = dataReader["Passwd"].ToString() ?? "",
                                Rol = dataReader["Rol"].ToString() ?? ""
                            });
                        }
                    }
                }

                return users;

            }
            catch (Exception)
            {
                throw;
            }

        }

        public IEnumerable<Usuario> GetUserByUsername(string username)
        {
            try
            {
                List<Usuario> users = new List<Usuario>();
                string sqlCommand = "SELECT * FROM Usuario WHERE Username = '" + username.Trim() + "' ";

                using (SqlConnection connection = handlerConnection.GetConnection())
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = sqlCommand;

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            users.Add(new Usuario()
                            {
                                Username = dataReader["Username"].ToString() ?? "",
                                Password = dataReader["Passwd"].ToString() ?? "",
                                Rol = dataReader["Rol"].ToString() ?? ""
                            });
                        }
                    }
                }

                return users;

            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool UpdateUsuario(Usuario usuario)
        {
            bool estaActualizado = false;
            try
            {
                using (SqlConnection connection = handlerConnection.GetConnection())
                {
                    SqlCommand sqlCommand = connection.CreateCommand();
                    string comandoEjecutarstring = "UPDATE Usuario" +
                        " SET " +
                        " Passwd = '"+usuario.Password+"' " +
                        ",Rol = '"+usuario.Rol+"' " +
                        "WHERE Username = '"+usuario.Username+"' ";

                    sqlCommand.CommandText = comandoEjecutarstring.Trim();
                    sqlCommand.CommandType = CommandType.Text;

                    int filasAfectadas = sqlCommand.ExecuteNonQuery();
                    if (filasAfectadas > 0) return estaActualizado = true;

                }

                return estaActualizado;
            }

            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteUsuario(string username)
        {
            bool estaEliminado = false;
            try
            {
                using (SqlConnection connection = handlerConnection.GetConnection())
                {
                    SqlCommand sqlCommand = connection.CreateCommand();
                    string comandoEjecutarstring = "DELETE FROM Usuario WHERE Username = '" + username + "' ";

                    sqlCommand.CommandText = comandoEjecutarstring.Trim();
                    sqlCommand.CommandType = CommandType.Text;

                    int filasAfectadas = sqlCommand.ExecuteNonQuery();
                    if (filasAfectadas > 0) return estaEliminado = true;

                }

                return estaEliminado;
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
