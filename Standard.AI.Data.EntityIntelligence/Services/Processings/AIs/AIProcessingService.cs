// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Models.Datas;
using Standard.AI.Data.EntityIntelligence.Services.Foundations.AIs;
using Standard.AI.OpenAI.Models.Clients.Completions.Exceptions;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Services.Processings.AIs
{
    internal partial class AIProcessingService : IAIProcessingService
    {
        private readonly IAIService aiService;

        public AIProcessingService(IAIService aiService) =>
            this.aiService = aiService;

        public async ValueTask<string> RetrieveSqlQueryAsync(
            List<TableInformation> tables,
            string naturalQuery)
        {
            ValidateTablesAndNaturalQuery(tables, naturalQuery);

            IEnumerable<string> tablesDetails = ConvertToTablesDetailsEnumerable(tables);
            string tablesNameColumns = string.Join(" ", tablesDetails);

            string naturalQueryInput = $"Respond ONLY with code. Given a SQL db with the following tables: " +
                $"{tablesNameColumns} Translated the following request into SQL query: {naturalQuery}";

            return await this.aiService.PromptQueryAsync(naturalQueryInput);
        }

        private static IEnumerable<string> ConvertToTablesDetailsEnumerable(
            List<TableInformation> tables)
        {
            return tables.Select(table =>
            {
                IEnumerable<string> tableColumnDetails = ConvertToTableColumnDetailsEnumerable(table);
                string tableColumns = string.Join(" ", tableColumnDetails);

                return $"Table name: {table.Name} has the following columns: {tableColumns}";
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
