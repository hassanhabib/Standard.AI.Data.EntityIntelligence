// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Schemas;
using Standard.AI.Data.EntityIntelligence.Services.Foundations.AIs;

namespace Standard.AI.Data.EntityIntelligence.Services.Processings.AIs
{
    internal partial class AIProcessingService : IAIProcessingService
    {
        private readonly IAIService aiService;

        public AIProcessingService(IAIService aiService) =>
            this.aiService = aiService;

        public ValueTask<string> RetrieveSqlQueryAsync(
            List<TableInformation> tableInformations,
            string naturalQuery) => TryCatch(async () =>
        {
            ValidateTableInformationList(tableInformations);
            ValidateNaturalQuery(naturalQuery);

            IEnumerable<string> tablesDetails = ConvertToTablesDetailsEnumerable(tableInformations);
            string tablesNameColumns = string.Join(" ", tablesDetails);

            string naturalQueryInput = $"Respond ONLY with code. Given a SQL db with the following tables: " +
                $"{tablesNameColumns} Translated the following request into SQL query: {naturalQuery}";

            return await this.aiService.PromptQueryAsync(naturalQueryInput);
        });

        private static IEnumerable<string> ConvertToTablesDetailsEnumerable(
            List<TableInformation> tableInformations)
        {
            return tableInformations.Select(tableInformation =>
            {
                IEnumerable<string> tableColumnDetails =
                    ConvertToTableColumnDetailsEnumerable(tableInformation);

                string tableColumns =
                    string.Join(" ", tableColumnDetails);

                return $"Table name: {tableInformation.Name} has the following columns: {tableColumns}";
            });
        }

        private static IEnumerable<string> ConvertToTableColumnDetailsEnumerable(
            TableInformation table)
        {
            return table.Columns.Select(column =>
                $"{column.Name} with type {column.Type}");
        }
    }
}
