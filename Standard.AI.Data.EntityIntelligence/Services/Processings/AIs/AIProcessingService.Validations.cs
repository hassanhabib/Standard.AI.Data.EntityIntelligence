// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using Standard.AI.Data.EntityIntelligence.Models.Datas;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.AIs.Exceptions;
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
            ValidateTableInformationListNotNullOrEmpty(tableInformations);

            (dynamic, string)[] validations = 
                tableInformations.Select((tableInformation, index) =>
                    (Rule: IsInvalid(tableInformation), Parameter: $"Element at {index}"))
                        .ToArray();
            
            Validate(validations);
        }

        private static void ValidateTableInformationListNotNullOrEmpty(List<TableInformation> tableInformations) 
        { 
            if (tableInformations is null || tableInformations.Any() is false) 
            {
                throw new InvalidTableInformationListAIProcessingException();
            }
        }

        private static dynamic IsInvalid(TableInformation tableInformation) => new
        {
            Condition = tableInformation is null,
            Message = "Object is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidTableInformationListAIProcessingException = 
                new InvalidTableInformationListAIProcessingException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidTableInformationListAIProcessingException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidTableInformationListAIProcessingException.ThrowIfContainsErrors();
        }
    }
}
