// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

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
        [MemberData(nameof(DataDepndencyValidationExceptions))]
        private async Task ShouldThrowDependencyValidationExceptionOnRetrieveIfDependencyyValidationeErrorOccursAsync(Xeption dependencyValidationException)
        {
            // given
            string someQuery = CreateRandomQuery();

            var expectedDataProcessingDependencyValidationException = new DataProcessingDependencyValidationException(
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
    }
}
