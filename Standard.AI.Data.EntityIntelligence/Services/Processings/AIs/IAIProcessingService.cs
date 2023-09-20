// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.TableMetadatas;

namespace Standard.AI.Data.EntityIntelligence.Services.Processings.AIs
{
    internal interface IAIProcessingService
    {
        ValueTask<string> RetrieveSqlQueryAsync(
            List<TableInformation> tableInformations,
            string naturalQuery);
    }
}
