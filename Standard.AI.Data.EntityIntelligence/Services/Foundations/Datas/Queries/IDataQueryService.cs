// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Standard.AI.Data.EntityIntelligence.Models.Datas.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Standard.AI.Data.EntityIntelligence.Services.Foundations.Datas.Queries
{
    internal interface IDataQueryService
    {
        ValueTask<IEnumerable<ResultRow>> RunQueryAsync(string query);
    }
}
