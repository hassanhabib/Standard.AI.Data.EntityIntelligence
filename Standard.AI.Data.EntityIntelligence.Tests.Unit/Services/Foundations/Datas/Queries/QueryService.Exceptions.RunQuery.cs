// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Datas.Services.Queries;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions.Queries;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Foundations.Datas.Queries
{
    public partial class QueryServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRunQueryIfInvalidArgumentExceptionOccursAsync()
        {
            // arrange
            string query = GetRandomString();

            var invalidArgumentException = new ArgumentException();

            var invalidQueryException =
                new InvalidQueryException(invalidArgumentException);

            var expectedQueryServiceDependencyValidationException =
                new QueryServiceDependencyValidationException(invalidQueryException);

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<IDictionary<string, object>>(query))
                    .ThrowsAsync(invalidArgumentException);

            // act
            ValueTask<IEnumerable<ResultRow>> runQueryTask =
                this.queryService.RunQueryAsync(query);

            var actualRunQueryException =
                await Assert.ThrowsAsync<QueryServiceDependencyValidationException>(
                    runQueryTask.AsTask);

            // assert
            actualRunQueryException.Should().BeEquivalentTo(
                expectedQueryServiceDependencyValidationException);

            this.dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<It.IsAnyType>(query),
                    Times.Once);

            this.dataBrokerMock.VerifyNoOtherCalls();
        }
    }
}
