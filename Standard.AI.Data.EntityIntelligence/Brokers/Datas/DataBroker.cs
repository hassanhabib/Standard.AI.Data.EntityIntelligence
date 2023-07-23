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
    internal class DataBroker : IDataBroker
    {
        private readonly DbContextConfigurations configurations;

        public DataBroker(DbContextConfigurations configurations) => 
            this.configurations = configurations;

        public async ValueTask<IEnumerable<T>> ExecuteQueryAsync<T>(string query) =>
            await QueryAsync<T>(query);
        
        private async ValueTask<IEnumerable<T>> QueryAsync<T>(string query)
        {
            using var dbConnection = new SqlConnection(this.configurations.ConnectionString);

            return await dbConnection.QueryAsync<T>(query);
        }
    }
}