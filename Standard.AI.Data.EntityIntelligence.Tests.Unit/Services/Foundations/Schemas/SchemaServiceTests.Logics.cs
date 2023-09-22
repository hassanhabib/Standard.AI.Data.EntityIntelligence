// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Schemas;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Foundations.Schemas
{
    public partial class SchemaServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveTableMetadatasAsync()
        {
            // given
            string query = String.Join(
                separator: Environment.NewLine,
                "SELECT",
                $"columnMetadata.TABLE_SCHEMA AS [TableSchema],",
                $"columnMetadata.TABLE_NAME AS [TableName],",
                $"columnMetadata.COLUMN_NAME AS [Name],",
                $"columnMetadata.DATA_TYPE AS [DataType]",
                "FROM INFORMATION_SCHEMA.COLUMNS columnMetadata");

            var randomTableInformations = GenerateRandomTableInformations();

            var toRetrieveTableColumnsMetadata =
                randomTableInformations.Keys.SelectMany(schemaTableName =>
                {
                    var columnsMetadata = randomTableInformations[schemaTableName];
                    var tablesColumnsMetadata = new List<TableColumnMetadata>();

                    foreach (var columnKey in columnsMetadata.Keys)
                    {
                        var columnMetadata = columnsMetadata[columnKey];

                        tablesColumnsMetadata.Add(
                            new TableColumnMetadata
                            {
                                TableSchema = schemaTableName.Split(".")[0],
                                TableName = schemaTableName.Split(".")[1],
                                Name = columnKey,
                                DataType = columnsMetadata[columnKey],
                            });
                    }
                    return tablesColumnsMetadata;
                });

            var expectedTableInformation =
                randomTableInformations.Keys.Select(schemaTableName =>
                {
                    var columnsMetadata = randomTableInformations[schemaTableName];

                    return new TableInformation
                    {
                        Schema = schemaTableName.Split(".")[0],
                        Name = schemaTableName.Split(".")[1],

                        Columns = columnsMetadata.Keys.Select(key => new TableColumn
                        {
                            Name = key,
                            Type = columnsMetadata[key],
                        }).ToList()
                    };
                }).ToList();

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(query))
                    .ReturnsAsync(toRetrieveTableColumnsMetadata);

            // when
            var retrievedTableInformations =
                await metadataQueryService.RetrieveTableInformationsAsync();

            // then
            retrievedTableInformations.Should().BeEquivalentTo(expectedTableInformation);

            this.dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(query),
                    Times.Once);

            this.dataBrokerMock.VerifyNoOtherCalls();
        }
    }
}
