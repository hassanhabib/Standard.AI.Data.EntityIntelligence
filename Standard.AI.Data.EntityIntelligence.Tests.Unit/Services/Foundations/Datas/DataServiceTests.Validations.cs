// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions;
using Xeptions;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Foundations.Datas
{
    public partial class DataServiceTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        private async Task ShouldThrowValidationExceptionOnRunQueryIfQueryIsNullOrEmptyAsync(
            string invalidQuery)
        {
            // given
            var invalidDataQueryException =
                new NullDataQueryException(
                    message: "Data query is null.");

            var expectedDataQueryServiceValidationException =
                new DataServiceValidationException(
                    message: "Data query service validation error occurred, fix the errors and try again.",
                    invalidDataQueryException.InnerException as Xeption);

            // when
            ValueTask<DataResult> runQueryTask =
                this.dataQueryService.RetrieveDataAsync(invalidQuery);

            DataServiceValidationException actualDataValidationException =
                await Assert.ThrowsAsync<DataServiceValidationException>(
                    runQueryTask.AsTask);

            // then
            actualDataValidationException.Should().BeEquivalentTo(
                expectedDataQueryServiceValidationException);
            
            this.dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<It.IsAnyType>(It.IsAny<string>()),
                    Times.Never);

            this.dataBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(InvalidQueries))]
        private async Task ShouldThrowValidationExceptionOnRunQueryIfQueryIsInvalidAsync(
            string invalidQuery)
        {
            // given
            var invalidDataQueryException =
                new InvalidDataQueryException(
                message: "Invalid query error occurred, fix the errors and try again.");

            var expectedDataQueryServiceValidationException =
                new DataServiceValidationException(
                    message: "Data query service validation error occurred, fix the errors and try again.",
                    invalidDataQueryException.InnerException as Xeption);

            // when
            ValueTask<DataResult> runQueryTask =
                this.dataQueryService.RetrieveDataAsync(invalidQuery);

            DataServiceValidationException actualDataValidationException =
                await Assert.ThrowsAsync<DataServiceValidationException>(
                    runQueryTask.AsTask);

            // then
            actualDataValidationException.Should().BeEquivalentTo(
                expectedDataQueryServiceValidationException);
            
            this.dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<It.IsAnyType>(It.IsAny<string>()),
                    Times.Never);

            this.dataBrokerMock.VerifyNoOtherCalls();
        }
    }
}
