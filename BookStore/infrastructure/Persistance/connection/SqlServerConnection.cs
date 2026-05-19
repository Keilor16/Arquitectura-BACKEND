using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Arquitectura_BACKEND.BookStore.infrastructure.Persistance.connection
{
    public class SqlServerConnection
    {
        private readonly string _connectionString;

        public SqlServerConnection(
            IConfiguration configuration
        )
        {
            _connectionString = configuration
                .GetConnectionString("DefaultConnection")!;
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
