// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Datas;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Processings
{
    public partial class AIProcessingServiceTests
    {
        [Fact]
        private async Task ShouldRetrieveSqlQueryAsync()
        {
            // given
            string randomNaturalQuery = CreateRandomString();
            string inputNaturalQuery = randomNaturalQuery;
            string randomAISqlResponse = CreateRandomString();
            string returnedAiSqlResponse = randomAISqlResponse;
            string expectedAiSqlResponse = returnedAiSqlResponse;

            Dictionary<string, Dictionary<string, string>> randomTablesData =
                GenerateRandomTables();

            List<TableInformation> randomTableInformations =
                randomTablesData.Keys.Select(key =>
                {
                    return new TableInformation
                    {
                        Name = key,
                        Columns = randomTablesData[key].Keys.Select(tableColumnKey =>
                        {
                            return new TableColumn
                            {
                                Name = tableColumnKey,
                                Type = randomTablesData[key][tableColumnKey]
                            };
                        }).ToList()
                    };
                }).ToList();

            List<TableInformation> inputTableInformaiton = randomTableInformations;

            string randomTablesColumns = String.Join(" ", randomTablesData.Keys.Select(key =>
            {
                string tableName = key;

                string allColumnsTypes = String.Join(" ", randomTablesData[key].Keys.Select(tableColumnKey =>
                    $"{tableColumnKey} with type {randomTablesData[key][tableColumnKey]}")
                        .ToArray());

                return $"Table name: {tableName} has the following columns: {allColumnsTypes}";
            }).ToArray());

            string expectedNaturalQueryInput = $"Respond ONLY with code. Given a SQL db with the following tables: " +
                $"{randomTablesColumns} Translated the following request into SQL query: {inputNaturalQuery}";

            this.aiServiceMock.Setup(service =>
                service.PromptQueryAsync(expectedNaturalQueryInput))
                    .ReturnsAsync(returnedAiSqlResponse);

            // when
            string actualAiSqlResponse =
                await this.aiProcessingService.RetrieveSqlQueryAsync(
                    inputTableInformaiton,
                    inputNaturalQuery);

            // then
            actualAiSqlResponse.Should().BeEquivalentTo(expectedAiSqlResponse);

            this.aiServiceMock.Verify(service =>
                service.PromptQueryAsync(expectedNaturalQueryInput),
                    Times.Once());

            this.aiServiceMock.VerifyNoOtherCalls();
        }
    }
}
