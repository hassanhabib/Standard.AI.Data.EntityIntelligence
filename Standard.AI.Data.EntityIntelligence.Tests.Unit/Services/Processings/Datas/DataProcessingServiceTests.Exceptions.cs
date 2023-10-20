// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas;
using Standard.AI.Data.EntityIntelligence.Models.Processings.Datas.Exceptions;
using Xeptions;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Processings.Datas
{
    public partial class DataProcessingServiceTests
    {
        [Theory]
        [MemberData(nameof(DataDependencyValidationExceptions))]
        private async Task ShouldThrowDependencyValidationExceptionOnRetrieveIfDependencyValidationErrorOccursAsync(
            Xeption dependencyValidationException)
        {
            // given
            string someQuery = CreateRandomQuery();

            var expectedDataProcessingDependencyValidationException = 
                new DataProcessingDependencyValidationException(
                    message: "Data dependency validation error occurred, fix errors and try again.",
                    innerException: dependencyValidationException.InnerException as Xeption);

            this.dataServiceMock.Setup(service =>
                service.RetrieveDataAsync(It.IsAny<string>()))
                    .ThrowsAsync(dependencyValidationException);

            // when
            ValueTask<DataResult> retrieveDataResultTask =
                this.dataProcessingService.RetrieveDataAsync(someQuery);

            DataProcessingDependencyValidationException
                actualDataProcessingDependencyValidationException =
                    await Assert.ThrowsAsync<DataProcessingDependencyValidationException>(
                        retrieveDataResultTask.AsTask);
            // then
            actualDataProcessingDependencyValidationException.Should().BeEquivalentTo(
                expectedDataProcessingDependencyValidationException);

            this.dataServiceMock.Verify(service =>
                service.RetrieveDataAsync(It.IsAny<string>()),
                    Times.Once);

            this.dataServiceMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(DataDependencyExceptions))]
        private async Task ShouldThrowDependencyExceptionOnRetrieveIfDependencyErrorOccursAsync(
            Xeption dependencyException)
        {
            // given
            string someQuery = CreateRandomQuery();

            var expectedDataProcessingDependencyException =
                new DataProcessingDependencyException(
                    message: "Data dependency error occurred, contact support.",
                    innerException: dependencyException.InnerException as Xeption);

            this.dataServiceMock.Setup(service =>
                service.RetrieveDataAsync(It.IsAny<string>()))
                    .ThrowsAsync(dependencyException);

            // when
            ValueTask<DataResult> retrieveDataResultTask =
                this.dataProcessingService.RetrieveDataAsync(someQuery);

            DataProcessingDependencyException
                actualDataProcessingDependencyException =
                    await Assert.ThrowsAsync<DataProcessingDependencyException>(
                        retrieveDataResultTask.AsTask);
            // then
            actualDataProcessingDependencyException.Should().BeEquivalentTo(
                expectedDataProcessingDependencyException);

            this.dataServiceMock.Verify(service =>
                service.RetrieveDataAsync(It.IsAny<string>()),
                    Times.Once);

            this.dataServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        private async Task ShouldThrowServiceExceptionOnRetrieveIfServiceErrorOccursAsync()
        {
            // given
            string someQuery = CreateRandomQuery();
            var serviceException = new Exception();

            var failedDataProcessingServiceException =
                new FailedDataProcessingServiceException(
                    message: "Failed data service error occurred, contact support.",
                    innerException: serviceException as Xeption);

            var expectedDataProcessingServiceException =
                new DataProcessingServiceException(
                    message: "Data service error occurred, contact support.",
                    innerException: failedDataProcessingServiceException);

            this.dataServiceMock.Setup(service =>
                service.RetrieveDataAsync(It.IsAny<string>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<DataResult> retrieveDataResultTask =
                this.dataProcessingService.RetrieveDataAsync(someQuery);

            DataProcessingServiceException
                actualDataProcessingServiceException =
                    await Assert.ThrowsAsync<DataProcessingServiceException>(
                        retrieveDataResultTask.AsTask);
            // then
            actualDataProcessingServiceException.Should().BeEquivalentTo(
                expectedDataProcessingServiceException);

            this.dataServiceMock.Verify(service =>
                service.RetrieveDataAsync(It.IsAny<string>()),
                    Times.Once);

            this.dataServiceMock.VerifyNoOtherCalls();
        }
    }
}
