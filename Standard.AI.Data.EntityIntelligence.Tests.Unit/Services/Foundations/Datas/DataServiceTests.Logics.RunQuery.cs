// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Datas.Services;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Foundations.Datas
{
    public partial class DataServiceTests
    {
        [Fact]
        public async Task ShouldRunSqlQueryAsync()
        {
            var randomQuery = GetRandomString();
            var inputQuery = randomQuery;

            IEnumerable<KeyValuePair<string, string>> 
                randomColumnDatas = GenerateRandomColumnDatas();

            IEnumerable<dynamic> toRetriveColumnDatas =
                randomColumnDatas.Select(columnData =>
                    new
                    {
                        ColumnName = columnData.Key,
                        ColumnValue = columnData.Value
                    });

            IEnumerable<ColumnData> expectedColumnDatas =
                randomColumnDatas.Select(columnData =>
                    new ColumnData
                    {
                        Name = columnData.Key,
                        Value = columnData.Value
                    });

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<dynamic>(inputQuery))
                    .ReturnsAsync(toRetriveColumnDatas);

            IEnumerable<ColumnData> retrievedColumnsData =
                await dataService.RunQuery(randomQuery);

            retrievedColumnsData.Should()
                .BeEquivalentTo(expectedColumnDatas);

            this.dataBrokerMock.Verify(broker => 
                broker.ExecuteQueryAsync<dynamic>(inputQuery), 
                    Times.Once());

            this.dataBrokerMock.VerifyNoOtherCalls();
        }
    }
}
