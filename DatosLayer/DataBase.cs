using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace DatosLayer
{
    public class DataBase
    {

        // Propiedad que devuelve la cadena de conexión completa configurada
        public static string ConnectionString {
            get
            {
                // Obtiene la cadena de conexión desde el archivo de configuración
                string CadenaConexion = ConfigurationManager
                    .ConnectionStrings["NWConnection"]
                    .ConnectionString;

                // Crea un SqlConnectionStringBuilder a partir de la cadena de conexión
                SqlConnectionStringBuilder conexionBuilder = 
                    new SqlConnectionStringBuilder(CadenaConexion);

                // Establece el nombre de la aplicación si se ha configurado
                conexionBuilder.ApplicationName = 
                    ApplicationName ?? conexionBuilder.ApplicationName;

                // Establece el tiempo de espera de conexión si se ha configurado
                conexionBuilder.ConnectTimeout = ( ConnectionTimeout > 0 ) 
                    ? ConnectionTimeout : conexionBuilder.ConnectTimeout;

                // Devuelve la cadena de conexión modificada
                return conexionBuilder.ToString();
            }


        }

        // Propiedad estática para el tiempo de espera de conexión
        public static int ConnectionTimeout { get; set; }

        // Propiedad estática para el nombre de la aplicación
        public static string ApplicationName { get; set; }

        // Método para obtener una conexión SQL abierta
        public static SqlConnection GetSqlConnection()
        {
            // Método para obtener una conexión SQL abierta
            SqlConnection conexion = new SqlConnection(ConnectionString);

            // Abre la conexión
            conexion.Open();
            return conexion;
            
        } 
    }
}
