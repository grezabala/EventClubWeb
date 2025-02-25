using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System.Data;

namespace ClubWebApp.Aplication.Dominio.Data.DbConnectionSql
{
    public class ConnectionSqlServer
    {
        public SqlConnection _connection = new SqlConnection("Data Source=(local); Initial Catalog=ClubAltamaria; Integrated Security=True; MultipleActiveResultSets=True; Encrypt=True; TrustServerCertificate=True");

        public SqlConnection OpenConnection()
        {

            if (_connection.State == ConnectionState.Closed) _connection.Open();
            return _connection;

        }

        public SqlConnection CloseConnection()
        {
            if (_connection.State == ConnectionState.Open) _connection.Close();
            return _connection;

        }
        public string GetConexion() 
        {
            string _connection = "Data Source=(local); Initial Catalog=ClubAltamaria; Integrated Security=True; MultipleActiveResultSets=True; Encrypt=True; TrustServerCertificate=True";
            return _connection;

        }
    }
}
