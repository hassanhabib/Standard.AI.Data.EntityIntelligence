// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Queries;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Foundations.Queries
{
    public partial class QueryServiceTests
    {
        [Fact]
        private async Task ShouldRunQueryAsync()
        {
            // given
            string randomQuery = GetRandomString();
            var inputQuery = randomQuery;

            List<KeyValuePair<int, (string ColumnName, object ColumnValue)>>
                randomColumnData = GenerateColumnDatas().ToList();

            IEnumerable<IDictionary<string, object>> toRetriveColumnDatas =
                randomColumnData.GroupBy(rcd => rcd.Key)
                    .Select(rcd =>
                        rcd.Select(r =>
                            KeyValuePair.Create(
                                r.Value.ColumnName,
                                r.Value.ColumnValue))
                        .ToDictionary(r => r.Key, r => r.Value));

            IEnumerable<ResultRow> expectedResultRows =
                randomColumnData.GroupBy(rcd => rcd.Key)
                    .Select(rcd => new ResultRow
                    {
                        Columns = rcd.Select(r => new ColumnData
                        {
                            Name = r.Value.ColumnName,
                            Value = r.Value.ColumnValue,
                        })
                    });

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<IDictionary<string, object>>(inputQuery))
                    .ReturnsAsync(toRetriveColumnDatas);

            // when
            IEnumerable<ResultRow> retrievedResultRows =
                await this.queryService.RunQueryAsync(inputQuery);

            // then
            retrievedResultRows.Should()
                .BeEquivalentTo(expectedResultRows);

            this.dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<IDictionary<string, object>>(inputQuery),
                    Times.Once());

            this.dataBrokerMock.VerifyNoOtherCalls();
        }
    }
}
