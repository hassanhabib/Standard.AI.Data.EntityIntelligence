// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.AIs.Exceptions;
using Standard.AI.OpenAI.Models.Clients.Completions.Exceptions;
using Standard.AI.OpenAI.Models.Services.Foundations.Completions;
using Xeptions;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Foundations.AIs
{
    public partial class AIServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveIfValidationExceptionOccursAsync()
        {
            // given
            string someNaturalQuery = GetRandomString();
            var innerValidationException = new Xeption();

            var completionClientValidationException =
                new CompletionClientValidationException(
                    innerValidationException);

            var invalidAIException =
                new InvalidAIQueryException(
                    innerValidationException);

            var expectedAIDependencyValidationException =
                new AIDependencyValidationException(
                    invalidAIException);

            this.aiBrokerMock.Setup(broker =>
                broker.PromptCompletionAsync(It.IsAny<Completion>()))
                    .ThrowsAsync(completionClientValidationException);

            // when
            ValueTask<string> retrieveSqlQueryTask =
                this.aiService.RetrieveSqlQueryAsync(someNaturalQuery);

            AIDependencyValidationException actualAIDependencyValidationException =
                await Assert.ThrowsAsync<AIDependencyValidationException>(
                    retrieveSqlQueryTask.AsTask);

            // then
            actualAIDependencyValidationException.Should().BeEquivalentTo(
                expectedAIDependencyValidationException);

            this.aiBrokerMock.Verify(broker =>
                broker.PromptCompletionAsync(It.IsAny<Completion>()),
                    Times.Once);

            this.aiBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(AIClientDependencyExceptions))]
        public async Task ShouldThrowDependencyExceptionOnRetrieveIfClientDependencyExceptionOccursAsync(
            Xeption clientDependencyException)
        {
            // given
            string someNaturalQuery = GetRandomString();

            var failedAIDependencyException =
                new FailedAIDependencyException(
                    clientDependencyException.InnerException as Xeption);

            var expectedAIDependencyException =
                new AIDependencyException(
                    failedAIDependencyException);

            this.aiBrokerMock.Setup(broker =>
                broker.PromptCompletionAsync(It.IsAny<Completion>()))
                    .ThrowsAsync(clientDependencyException);

            // when
            ValueTask<string> retrieveSqlQueryTask =
                this.aiService.RetrieveSqlQueryAsync(someNaturalQuery);

            AIDependencyException actualAIDependencyException =
                await Assert.ThrowsAsync<AIDependencyException>(
                    retrieveSqlQueryTask.AsTask);

            // then
            actualAIDependencyException.Should().BeEquivalentTo(
                expectedAIDependencyException);

            this.aiBrokerMock.Verify(broker =>
                broker.PromptCompletionAsync(It.IsAny<Completion>()),
                    Times.Once);

            this.aiBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnRetrieveIfServiceErrorOccurredAsync()
        {
            // given
            string someNaturalQuery = GetRandomString();
            var serviceException = new Exception();

            var failedAIServiceException =
                new FailedAIServiceException(
                    serviceException);

            var expectedAIServiceException =
                new AIServiceException(
                    failedAIServiceException);

            this.aiBrokerMock.Setup(broker =>
                broker.PromptCompletionAsync(It.IsAny<Completion>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<string> retrieveSqlQueryTask =
                this.aiService.RetrieveSqlQueryAsync(someNaturalQuery);

            AIServiceException actualAIServiceException =
                await Assert.ThrowsAsync<AIServiceException>(
                    retrieveSqlQueryTask.AsTask);

            // then
            actualAIServiceException.Should().BeEquivalentTo(
                expectedAIServiceException);

            this.aiBrokerMock.Verify(broker =>
                broker.PromptCompletionAsync(It.IsAny<Completion>()),
                    Times.Once);

            this.aiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
