// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Datas.Services.Queries;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions.Queries;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Foundations.Datas.Queries
{
    public partial class QueryServiceTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task ShouldThrowValidationExceptionOnRunQueryIfQueryIsInvalidAsync(
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

            ValueTask<IEnumerable<ResultRow>> runQueryTask =
                this.queryService.RunQueryAsync(invalidQuery);

            QueryValidationException actualQueryValidationException =
                await Assert.ThrowsAsync<QueryValidationException>(
                    runQueryTask.AsTask);

            this.dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<It.IsAnyType>(It.IsAny<string>()),
                    Times.Never);

            this.dataBrokerMock.VerifyNoOtherCalls();
        }
    }
}
