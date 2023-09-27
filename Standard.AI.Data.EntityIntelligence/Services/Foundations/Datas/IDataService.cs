// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas;

namespace Standard.AI.Data.EntityIntelligence.Services.Foundations.Datas
{
    internal interface IDataService
    {
        ValueTask<IEnumerable<ResultRow>> RetrieveDataAsync(string query);
    }
}
