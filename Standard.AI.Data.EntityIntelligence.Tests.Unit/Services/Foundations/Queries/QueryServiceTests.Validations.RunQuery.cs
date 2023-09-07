// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Queries;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Queries.Exceptions;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Foundations.Queries
{
    public partial class QueryServiceTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        private async Task ShouldThrowValidationExceptionOnRunQueryIfQueryIsInvalidAsync(
            string invalidQuery)
        {
            // given
            var invalidQueryException =
                new InvalidQueryException(
                    message: "Invalid query error occurred, fix the errors and try again.");

            var expectedQueryValidationException =
                new QueryValidationException(
                    message: "Query validation error occurred, fix the errors and try again.",
                    invalidQueryException);

            // when
            ValueTask<IEnumerable<ResultRow>> runQueryTask =
                this.queryService.RunQueryAsync(invalidQuery);

            QueryValidationException actualQueryValidationException =
                await Assert.ThrowsAsync<QueryValidationException>(
                    runQueryTask.AsTask);

            // then
            actualQueryValidationException.Should().BeEquivalentTo(
                expectedQueryValidationException);

            this.dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<It.IsAnyType>(It.IsAny<string>()),
                    Times.Never);

            this.dataBrokerMock.VerifyNoOtherCalls();
        }
    }
}
