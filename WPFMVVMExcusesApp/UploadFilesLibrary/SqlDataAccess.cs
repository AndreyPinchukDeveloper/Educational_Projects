using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace UploadFilesLibrary;

public class SqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration config)
	{
        _config = config;
    }

    public async Task SaveData(
        string storedProc, 
        string connectionName, 
        object parameter)
    {
        string connectionString = _config.GetConnectionString(connectionName)
            ?? throw new Exception($"Missing connection string at {connectionName}");

        using var connection = new SqlConnection(connectionString);

        await connection.ExecuteAsync(
            storedProc, 
            parameter, 
            commandType: System.Data.CommandType.StoredProcedure);
    }
}
