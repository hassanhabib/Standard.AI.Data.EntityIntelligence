// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Standard.AI.Data.EntityIntelligence.Models.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

using System.Data.SqlClient;
using Dapper;

namespace Standard.AI.Data.EntityIntelligence.Brokers.DataStorages
{
    public class DataBroker
    {
        private readonly DataStorageConfiguration configuration;

        public DataBroker(DataStorageConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IEnumerable<TableColumnMetadata>> SelectSqlTablesMetadataAsync()
        {
            const string query = "";

            using var connection = new SqlConnection(configuration.ConnectionString);

            return await connection.QueryAsync<TableColumnMetadata>(query);
        }
    }
}
