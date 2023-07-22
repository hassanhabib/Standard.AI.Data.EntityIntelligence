// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Standard.AI.Data.EntityIntelligence.Brokers.Datas
{
    internal partial class DataBroker : IDataBroker
    {
        public async ValueTask<IEnumerable<T>> ExecuteQueryAsync<T>(string query) => 
            await QueryAsync<T>(query);
    }
}
