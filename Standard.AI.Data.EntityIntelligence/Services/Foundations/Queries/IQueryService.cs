// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Queries;

namespace Standard.AI.Data.EntityIntelligence.Services.Foundations.Queries
{
    internal interface IQueryService
    {
        ValueTask<IEnumerable<ResultRow>> RunQueryAsync(string query);
    }
}
