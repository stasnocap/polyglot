using System.Data;
using Npgsql;
using EngQuest.Application.Abstractions.Data;

namespace EngQuest.Infrastructure.Data;

internal sealed class SqlConnectionFactory(string connectionString) : ISqlConnectionFactory
{
    public IDbConnection CreateConnection()
    {
        var connection = new NpgsqlConnection(connectionString);
        
        connection.Open();

        return connection;
    }
}
