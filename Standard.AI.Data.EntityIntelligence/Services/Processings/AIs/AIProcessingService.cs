// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Models.Datas;
using Standard.AI.Data.EntityIntelligence.Services.Foundations.AIs;

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
            string tableNameColumns = String.Join(" ", tables.Select(table =>
            {
                string tableName = table.Name;

                string tableColumns =
                    String.Join(" ", table.Columns.Select(column =>
                        $"{column.Name} with type {column.Type}"));

                return $"Table name: {tableName} has the following columns: {tableColumns}";
            }));

            string naturalQueryInput = $"Respond ONLY with code. Given a SQL db with the following tables: " +
                $"{tableNameColumns} Translated the following request into SQL query: {naturalQuery}";

            return await this.aiService.PromptQueryAsync(naturalQueryInput);
        }
    }
}
