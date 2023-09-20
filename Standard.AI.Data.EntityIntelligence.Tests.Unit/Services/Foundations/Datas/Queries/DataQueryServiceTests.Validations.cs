// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Datas.Services;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Queries.Exceptions;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Foundations.Datas.Queries
{
    public partial class DataQueryServiceTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task ShouldThrowValidationExceptionOnRunQueryIfQueryIsNullOrEmptyAsync(
            string invalidQuery)
        {
            // given
            var nullOrEmptyDataQueryException =
                new NullOrEmptyDataQueryException();

            var expectedDataQueryServiceValidationException =
                new DataQueryServiceValidationException(nullOrEmptyDataQueryException);

            ValueTask<IEnumerable<ResultRow>> runQueryTask =
                this.dataQueryService.RunQueryAsync(invalidQuery);

            DataQueryServiceValidationException actualDataValidationException =
                await Assert.ThrowsAsync<DataQueryServiceValidationException>(
                    runQueryTask.AsTask);

            this.dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<It.IsAnyType>(It.IsAny<string>()),
                    Times.Never);

            this.dataBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(InvalidQueries))]
        public async Task ShouldThrowValidationExceptionOnRunQueryIfQueryIsInvalidAsync(
            string invalidQuery)
        {
            // given
            var invalidDataQueryException =
                new InvalidDataQueryException();

            var expectedDataQueryServiceValidationException =
                new DataQueryServiceValidationException(invalidDataQueryException);

            ValueTask<IEnumerable<ResultRow>> runQueryTask =
                this.dataQueryService.RunQueryAsync(invalidQuery);

            DataQueryServiceValidationException actualDataValidationException =
                await Assert.ThrowsAsync<DataQueryServiceValidationException>(
                    runQueryTask.AsTask);

            this.dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<It.IsAnyType>(It.IsAny<string>()),
                    Times.Never);

            this.dataBrokerMock.VerifyNoOtherCalls();
        }
    }
}
