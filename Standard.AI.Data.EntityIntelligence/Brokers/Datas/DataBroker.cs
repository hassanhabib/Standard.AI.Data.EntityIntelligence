// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Models.Datas;

namespace Standard.AI.Data.EntityIntelligence.Brokers.Datas
{
    internal class DataBroker : DbContext, IDataBroker
    {
        public DataBroker(IDbContextConfigurations configurations) 
            : base(configurations)
        { }

        public async ValueTask<IEnumerable<T>> ExecuteQueryAsync<T>(string query) => 
            await QueryAsync<T>(query);
    }
}
