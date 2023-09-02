// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Brokers.Datas;
using Standard.AI.Data.EntityIntelligence.Models.Datas.Services.Queries;

namespace Standard.AI.Data.EntityIntelligence.Services.Foundations.Datas.Queries
{
    internal class QueryService : IQueryService
    {
        private readonly IDataBroker dataBroker;

        public QueryService(IDataBroker dataBroker) =>
            this.dataBroker = dataBroker;

        public ValueTask<IEnumerable<ResultRow>> RunQueryAsync(string query)
        {
            throw new System.NotImplementedException();
        }
    }
}
