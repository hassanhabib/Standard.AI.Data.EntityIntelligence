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
        private static void ValidateTablesAndNaturalQuery(List<TableInformation> tables, string naturalQuery)

        {

        }

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidAIProcessingException =
                new InvalidAIProcessingException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidAIProcessingException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }
            invalidAIProcessingException.ThrowIfContainsErrors();
        }
    }
}
