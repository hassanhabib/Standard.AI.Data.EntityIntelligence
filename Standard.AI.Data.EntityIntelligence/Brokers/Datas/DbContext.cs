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
    internal class DbContext
    {
        private readonly DbContextConfigurations configurations;

        public DbContext(DbContextConfigurations configurations)
        {
            this.configurations = configurations;
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string query)
        {
            using var dbConnection = new SqlConnection(this.configurations.ConnectionString);

            return await dbConnection.QueryAsync<T>(query);
        }
    }
}