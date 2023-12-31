﻿// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas;
using Xunit;
namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Foundations.Datas
{
    public partial class DataServiceTests
    {
        [Fact]
        private async Task ShouldRunSqlQueryAsync()
        {
            // given
            string query = GetValidQuery();
            var inputQuery = query;

            IEnumerable<KeyValuePair<int, (string ColumnName, object ColumnValue)>>
                randomColumnData = GenerateColumnDatas().ToList();

            IEnumerable<IDictionary<string, object>> toRetriveColumnDatas =
                randomColumnData.GroupBy(rcd => rcd.Key)
                    .Select(rcd =>
                        rcd.Select(r =>
                            KeyValuePair.Create(
                                r.Value.ColumnName,
                                r.Value.ColumnValue))
                        .ToDictionary(r => r.Key, r => r.Value));

            DataResult expectedResultRows =
                new DataResult
                {
                    ColumnGroups = randomColumnData.GroupBy(rcd => rcd.Key)
                    .Select(rcd => new ColumnGroupData
                    {
                        Columns = rcd.Select(r => new ColumnData
                        {
                            Name = r.Value.ColumnName,
                            Value = r.Value.ColumnValue,
                        })
                    })
                };

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<IDictionary<string, object>>(inputQuery))
                    .ReturnsAsync(toRetriveColumnDatas);

            // when
            DataResult retrievedResultRows =
                await dataQueryService.RetrieveDataAsync(query);

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
