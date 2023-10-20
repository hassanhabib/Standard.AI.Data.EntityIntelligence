// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas;
using Standard.AI.Data.EntityIntelligence.Models.Processings.Datas.Exceptions;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Processings.Datas
{
    public partial class DataProcessingServiceTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        private async Task ShouldThrowValidationExceptionOnRetrieveIfInputQueryIsInvalidAsync(
            string invalidQuery)
        {
            // given
            var invalidQueryProcessingException =
                new InvalidQueryDataProcessingException(
                    message: "Invalid query errors occurred, fix the errors and try again.");

            var expectedDataProcessingValidationException =
                new DataProcessingValidationException(
                    message: "Data validation error occurred, fix errors and try again.",
                    innerException: invalidQueryProcessingException);

            // when
            ValueTask<DataResult> retrieveDataTask =
                this.dataProcessingService.RetrieveDataAsync(invalidQuery);

            DataProcessingValidationException actualDataProcessingValidationException =
                await Assert.ThrowsAsync<DataProcessingValidationException>(
                    retrieveDataTask.AsTask);

            // then
            actualDataProcessingValidationException.Should()
                .BeEquivalentTo(expectedDataProcessingValidationException);

            this.dataServiceMock.Verify(service =>
                service.RetrieveDataAsync(It.IsAny<string>()),
                    Times.Never());

            this.dataServiceMock.VerifyNoOtherCalls();
        }
    }
}
