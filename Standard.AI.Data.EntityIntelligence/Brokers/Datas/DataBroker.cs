// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Standard.AI.Data.EntityIntelligence.Models.Datas;

namespace Standard.AI.Data.EntityIntelligence.Brokers.Datas
{
    public class DataBroker : IDataBroker
    {
        private readonly DataStorageConfiguration configuration;

        public DataBroker(DataStorageConfiguration configuration) => 
            this.configuration = configuration;

        public async ValueTask<IEnumerable<T>> ExecuteQuery<T>(string query)
        {
            using var connection = new SqlConnection(configuration.ConnectionString);

            return await connection.QueryAsync<T>(query);
        }
    }
}
