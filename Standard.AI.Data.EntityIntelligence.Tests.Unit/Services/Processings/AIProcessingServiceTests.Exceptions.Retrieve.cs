// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Datas;
using Standard.AI.Data.EntityIntelligence.Models.Processings.AIs.Exceptions;
using Xeptions;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Processings
{
    public partial class AIProcessingServiceTests
    {
        [Theory]
        [MemberData(nameof(AIDependencyValidationExceptions))]
        private async Task ShouldThrowDependencyValidationExceptionOnRetrieveIfDependencyValidationErrorOccursAsync(
            Xeption dependencyValidationException)
        {
            // given
            List<TableInformation> someTableInformation = CreateRandomTableInformations();
            string someNaturalQuery = CreateRandomString();

            var expectedAIProcessingDependencyValidationException =
                new AIProcessingDependencyValidationException(
                    message: "AI dependency validation error occurred, fix errors and try again.",
                    innerException: dependencyValidationException.InnerException as Xeption);

            this.aiServiceMock.Setup(service =>
                service.PromptQueryAsync(It.IsAny<string>()))
                    .ThrowsAsync(dependencyValidationException);

            // when
            ValueTask<string> retrieveSqlQueryTask =
                this.aiProcessingService.RetrieveSqlQueryAsync(
                    someTableInformation,
                    someNaturalQuery);

            AIProcessingDependencyValidationException actualAIProcessingDependencyValidationException =
                await Assert.ThrowsAsync<AIProcessingDependencyValidationException>(
                    retrieveSqlQueryTask.AsTask);

            // then
            actualAIProcessingDependencyValidationException.Should()
                .BeEquivalentTo(expectedAIProcessingDependencyValidationException);

            this.aiServiceMock.Verify(service =>
                service.PromptQueryAsync(It.IsAny<string>()),
                    Times.Once);

            this.aiServiceMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(AIDependencyExceptions))]
        private async Task ShouldThrowDependencyExceptionOnRetrieveIfDependencyErrorOccursAsync(
            Xeption dependencyException)
        {
            // given
            List<TableInformation> someTableInformation = CreateRandomTableInformations();
            string someNaturalQuery = CreateRandomString();

            var expectedAIProcessingDependencyException =
                new AIProcessingDependencyException(
                    message: "AI dependency error occurred, contact support.",
                    innerException: dependencyException.InnerException as Xeption);

            this.aiServiceMock.Setup(service =>
                service.PromptQueryAsync(It.IsAny<string>()))
                    .ThrowsAsync(dependencyException);

            // when
            ValueTask<string> retrieveSqlQueryTask =
                this.aiProcessingService.RetrieveSqlQueryAsync(
                    someTableInformation,
                    someNaturalQuery);

            AIProcessingDependencyException actualAIProcessingDependencyException =
                await Assert.ThrowsAsync<AIProcessingDependencyException>(
                    retrieveSqlQueryTask.AsTask);

            // then
            actualAIProcessingDependencyException.Should()
                .BeEquivalentTo(expectedAIProcessingDependencyException);

            this.aiServiceMock.Verify(service =>
                service.PromptQueryAsync(It.IsAny<string>()),
                    Times.Once);

            this.aiServiceMock.VerifyNoOtherCalls();
        }
    }
}
