// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Informations;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Foundations.Informations
{
    public partial class DataInformationServiceTests
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

            var randomTableMetadatas = GenerateRandomTableMetadatas();

            var toRetrieveTableColumnsMetadata =
                randomTableMetadatas.Keys.SelectMany(schema__tableName =>
                {
                    var columnsMetadata = randomTableMetadatas[schema__tableName];
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

            var expectedTableMetadata =
                randomTableMetadatas.Keys.Select(schema__tableName =>
                {
                    var columnsMetadata = randomTableMetadatas[schema__tableName];

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

            this.dataBrokerMock.Setup(broker => 
                broker.ExecuteQueryAsync<TableColumnMetadata>(query))
                    .ReturnsAsync(toRetrieveTableColumnsMetadata);

            // when
            var retrievedTableMetadatas =
                await dataService.RetrieveTableMetadatasAsync();

            // then
            retrievedTableMetadatas.Should().BeEquivalentTo(expectedTableMetadata);

            this.dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(query),
                    Times.Once);

            this.dataBrokerMock.VerifyNoOtherCalls();
        }
    }
}
