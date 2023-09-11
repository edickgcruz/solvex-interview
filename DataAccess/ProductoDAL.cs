using System.Data.SqlClient;
using System.Data;
using Entities;

namespace DataAccess
{
    public class ProductoDAL
    {
        HandlerConnection handlerConnection = new HandlerConnection();
        public bool CrearProducto(Producto producto)
        {
            try
            {
                using (SqlConnection sqlConnection = handlerConnection.GetConnection())
                {
                    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.CommandText = "usp_CrearProducto";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Nombre", producto.Name);
                    

                    int filasAfectadas = sqlCommand.ExecuteNonQuery();
                    if (filasAfectadas > 0) return true;

                    return false;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Producto> GetAllProducts()
        {
            try
            {
                List<Producto> productos = new List<Producto>();

                using (SqlConnection connection = handlerConnection.GetConnection())
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "BuscarTodosProductos";
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            productos.Add(new Producto()
                            {
                                Id = dataReader["Id"] as int? ?? 0,
                                Name = dataReader["Nombre"].ToString() as string ?? "",
                            });

                        }
                    }

                }

                return productos;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IEnumerable<Producto> GetProducto(int id)
        {
            try
            {
                List<Producto> productos = new List<Producto>();
                string sqlCommand = "SELECT Id, Nombre FROM Producto WHERE Id = '" + id + "' ";

                using (SqlConnection connection = handlerConnection.GetConnection())
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = sqlCommand;
                    //cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {

                            productos.Add(new Producto()
                            {
                                Id = dataReader["Id"] as int? ?? 0,
                                Name = dataReader["Nombre"].ToString()
                            });

                        }
                    }

                }

                return productos;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Producto> GetProducto(string producto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProduct(int idProducto)
        {
            bool estaEliminado = false;
            try
            {
                string comandoEjecutar = "DELETE FROM Producto WHERE Producto.Id = '" + idProducto + "' ";

                using (SqlConnection connection = handlerConnection.GetConnection())
                {
                    SqlCommand sqlCommand = connection.CreateCommand();
                    sqlCommand.CommandText = comandoEjecutar;
                    //cmd.CommandType = CommandType.Text;
                    //

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

        public bool UpdateProducto(int idProducto, Producto producto)
        {
            bool estaActualizado = false;
            try
            {
                using (SqlConnection connection = handlerConnection.GetConnection())
                {
                    SqlCommand sqlCommand = connection.CreateCommand();
                    sqlCommand.CommandText = "usp_ActualizarProducto";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Id", producto.Id);
                    sqlCommand.Parameters.AddWithValue("@Nombre", producto.Name);

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

        /// <summary>
        /// Guarda el precio del producto por cada color.
        /// </summary>
        /// <param name="idProducto">Id del producto a guardar</param>
        /// <param name="precioProducto">Una entidad del tipo que contiene las propiedades a guardar del producto</param>
        /// <returns></returns>
        private bool GuardarPrecioProducto(int idProducto, PrecioProducto precioProducto)
        {
            bool estaGuardado = false;

            try
            {
                string comandoEjecutar = "INSERT INTO Precio (IdProducto, Precio, Color) VALUES " +
                    "('"+ precioProducto.IdProducto +"', '"+ precioProducto.Precio +"', '"+ precioProducto.Color +"')";

                using (SqlConnection connection = handlerConnection.GetConnection())
                {
                    SqlCommand sqlCommand = connection.CreateCommand();
                    sqlCommand.CommandText = comandoEjecutar;

                    int filasAfectadas = sqlCommand.ExecuteNonQuery();
                    if (filasAfectadas > 0) return estaGuardado = true;

                }

                return estaGuardado;
            }

            catch (Exception)
            {
                throw;
            }
        }        
    }
}