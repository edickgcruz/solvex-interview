using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    /// <summary>
    /// Clase destinada para manejar las conexiones a MS SQL SERVER
    /// </summary>
    public class HandlerConnection
    {
        /// <summary>
        /// Representa la cadena de conexion obtenida desde la configuracion
        /// </summary>
        private readonly string ConnectionString;

        //Cuando el objeto sea instanciado automaticamente le colocara el valor al campo ConnectionString, de esa forma puede estar disponible para la clase completa
        /// <summary>
        /// Busca la conexión en la configuración y la provee a los metodos que requieran.
        /// </summary>
        public HandlerConnection()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();

            this.ConnectionString = configuration.GetSection("ConnectionStrings").GetSection("dbConnectionsString").Value;
        }


        public SqlConnection GetConnection() 
        {
            SqlConnection connection = new SqlConnection(this.ConnectionString); 
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            return connection;
        }
    }
}
