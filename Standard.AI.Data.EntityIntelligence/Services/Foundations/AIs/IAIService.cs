// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;

namespace Standard.AI.Data.EntityIntelligence.Services.Foundations.AIs
{
    internal interface IAIService
    {
        ValueTask<string> RetrieveSqlQueryAsync(string naturalQuery);
    }
}
