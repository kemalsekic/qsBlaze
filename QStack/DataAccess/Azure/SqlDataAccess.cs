using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace QStack.DataAccess.Azure
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public string ConnectionStringName { get; set; } = "AzureConnection";

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            //string connectionString = _config.GetConnectionString(ConnectionStringName);
            string connectionString = "Server=tcp:qstackdbserver.database.windows.net,1433;Initial Catalog=qsBlazeDB;Persist Security Info=False;User ID=[ID];Password=[PASS];MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(sql, parameters);

                return data.ToList();
            }
        }

        public async Task SaveData<T>(string sql, T parameters)
        {
            //string connectionString = _config.GetConnectionString(ConnectionStringName);
            string connectionString = "Server=tcp:qstackdbserver.database.windows.net,1433;Initial Catalog=qsBlazeDB;Persist Security Info=False;User ID=[ID];Password=[PASS];MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(sql, parameters);
            }
        }
    }
}
