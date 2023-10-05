// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas;

namespace Standard.AI.Data.EntityIntelligence.Services.Processings.Datas
{
    internal interface IDataProcessingService
    {
        ValueTask<DataResult> RetrieveDataAsync(string query);
    }
}
