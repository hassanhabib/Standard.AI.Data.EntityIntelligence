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
            // break the circuit if no tables
            ValidateTablesAreNotNullOrEmpty(tables);

            // continous validation
            // TODO: Is there a better way to test these nested objects?
            Validate(
                (Rule: IsInvalidNaturalQuery(naturalQuery), Parameter: nameof(naturalQuery)),
                (Rule: IsInvalidTables(tables), Parameter: nameof(tables)),
                (Rule: IsInvalidTableColumns(tables), Parameter: nameof(tables))
                );

        }
        
        private static void ValidateTablesAreNotNullOrEmpty(List<TableInformation> tables)
        {
            if (tables is null || tables.Count == 0)
            {
                throw new NullOrEmptyTableInformationException();
            }
        }

        private static dynamic IsInvalidNaturalQuery(string naturalQuery) => new
        {
            Condition = string.IsNullOrWhiteSpace(naturalQuery),
            Message = "Natural query is required."
        };

        private static dynamic IsInvalidTables(List<TableInformation> tables) => new
        {
            Condition = tables.Any(tableInformation => string.IsNullOrEmpty(tableInformation.Name) || tableInformation.Columns == null
            || tableInformation.Columns.Count() == 0),
            Message = "Each table should have a name and associated columns."
        };

        private static dynamic IsInvalidTableColumns(List<TableInformation> tables) => new
        {
            Condition = tables.Any(tableInformation => tableInformation.Columns.Any(column => string.IsNullOrEmpty(column.Name) ||
                string.IsNullOrEmpty(column.Type))),
            Message = "Each table column should have a name and a type."
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidAIProcessingException =
                new InvalidAIProcessingQueryException();

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
