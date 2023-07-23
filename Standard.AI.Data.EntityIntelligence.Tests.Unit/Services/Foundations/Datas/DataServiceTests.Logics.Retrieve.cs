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
            var randomQuery = GetRandomString();
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
                                TableSchema = schema__tableName.Split("__")[0],
                                TableName = schema__tableName.Split("__")[1],
                                Name = columnKey,
                                Type = columnsMetadata[columnKey],
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
                        Schema = schema__tableName.Split("__")[0],
                        Name = schema__tableName.Split("__")[1],
                        ColumnsMetadata = columnsMetadata.Keys.Select(key => new ColumnMetadata
                        {
                            Name = key,
                            DataType = columnsMetadata[key],
                        }).ToList()
                    };
                }).ToList();

            dataBrokerMock.Setup(broker => broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()))
                .ReturnsAsync(toRetrieveTablesColumnsMetadata);

            // when
            var retrievedTablesDetails =
                await dataService.RetrieveTablesDetailsAsync();

            retrievedTablesDetails.Should().BeEquivalentTo(expectedTablesDetails);

            dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()),
                    Times.Once());

            dataBrokerMock.VerifyNoOtherCalls();
        }
    }
}
