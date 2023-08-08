// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using Standard.AI.Data.EntityIntelligence.Models.Datas;
using Standard.AI.Data.EntityIntelligence.Models.Processings.AIs.Exceptions;

namespace Standard.AI.Data.EntityIntelligence.Services.Processings.AIs
{
    internal partial class AIProcessingService : IAIProcessingService
    {

        private static void ValidateNaturalQuery(string naturalQuery)
        {
            if (string.IsNullOrWhiteSpace(naturalQuery))
            {
                throw new InvalidNaturalQueryAIProcessingException();
            }
        }
        private static void ValidateTableInformationList(List<TableInformation> tableInformations)
        {
            if (tableInformations is null || tableInformations.Any() is false)
            {
                throw new InvalidTableInformationListAIProcessingException();
            }
        }
    }
}
