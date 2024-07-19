using BidCalculation.Common.Settings;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace BidCalculation.Data
{
    public class SqlServerDataContext : IDatabaseDataContext
    {
        private DbSettings _dbSettings;

        public SqlServerDataContext(IOptions<DbSettings> dbSettings)
        {
            _dbSettings = dbSettings.Value;
        }

        public IDbConnection CreateConnection()
        {
            var connectionString = $"data source={_dbSettings.Server};initial catalog={_dbSettings.Database};trusted_connection=true;";
            return new SqlConnection(connectionString);
        }
    }
}
