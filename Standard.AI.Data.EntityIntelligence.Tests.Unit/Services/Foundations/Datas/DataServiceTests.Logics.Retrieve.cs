// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Datas.Brokers;
using Standard.AI.Data.EntityIntelligence.Models.Datas.Services;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Foundations.Datas
{
    public partial class DataServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveTablesDetailsAsync()
        {
            // given
            var query = String.Join(
                            Environment.NewLine,
                            "SELECT",
                            $"c.TABLE_SCHEMA AS [TableSchema],",
                            $"c.TABLE_NAME AS [TableName],",
                            $"c.COLUMN_NAME AS [Name],",
                            $"c.DATA_TYPE AS [DataType]",
                            "FROM INFORMATION_SCHEMA.COLUMNS c");

            var randomNumber = GetRandomNumber();
            var randomTablesMetadataProperties = GenerateRandomTablesMetadata();

            var toRetrieveTablesColumnsMetadata =
                randomTablesMetadataProperties.Keys.SelectMany(schema__tableName =>
                {
                    var columnsMetadata = randomTablesMetadataProperties[schema__tableName];
                    var tablesColumnsMetadata = new List<TableColumnMetadata>();
                    foreach (var columnKey in columnsMetadata.Keys)
                    {
                        var columnMetadata = columnsMetadata[columnKey];
                        tablesColumnsMetadata.Add(
                            new TableColumnMetadata
                            {
                                TableSchema = schema__tableName.Split(".")[0],
                                TableName = schema__tableName.Split(".")[1],
                                Name = columnKey,
                                DataType = columnsMetadata[columnKey],
                            });
                    }
                    return tablesColumnsMetadata;
                });

            var expectedTablesDetails =
                randomTablesMetadataProperties.Keys.Select(schema__tableName =>
                {
                    var columnsMetadata = randomTablesMetadataProperties[schema__tableName];
                    return new TableMetadata
                    {
                        Schema = schema__tableName.Split(".")[0],
                        Name = schema__tableName.Split(".")[1],
                        ColumnsMetadata = columnsMetadata.Keys.Select(key => new ColumnMetadata
                        {
                            Name = key,
                            DataType = columnsMetadata[key],
                        }).ToList()
                    };
                }).ToList();

            dataBrokerMock.Setup(broker => broker.ExecuteQueryAsync<TableColumnMetadata>(query))
                .ReturnsAsync(toRetrieveTablesColumnsMetadata);

            // when
            var retrievedTablesDetails =
                await dataService.RetrieveTablesDetailsAsync();

            // then
            retrievedTablesDetails.Should().BeEquivalentTo(expectedTablesDetails);

            dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(query),
                    Times.Once());

            dataBrokerMock.VerifyNoOtherCalls();
        }
    }
}
