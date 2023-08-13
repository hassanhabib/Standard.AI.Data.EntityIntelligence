﻿// ---------------------------------------------------------------------------------- 
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
        private async Task ShouldThrowDependencyValidationExceptionOnRetrieveIfValidationExceptionOccursAsync()
        {
            // given
            string someNaturalQuery = GetRandomString();
            var innerValidationException = new Xeption();

            var completionClientValidationException =
                new CompletionClientValidationException(
                        innerValidationException);

            var invalidAIException =
                new InvalidAIQueryException(
                    message: "Invalid AI Query error occurred, fix the errors and try again.",
                        innerException: innerValidationException);

            var expectedAIDependencyValidationException =
                new AIDependencyValidationException(
                    message: "AI validation error occurred, fix the errors and try again.",
                        innerException: invalidAIException);

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
        private async Task ShouldThrowDependencyExceptionOnRetrieveIfClientDependencyExceptionOccursAsync(
            Xeption clientDependencyException)
        {
            // given
            string someNaturalQuery = GetRandomString();

            var failedAIDependencyException =
                new FailedAIDependencyException(
                    message: "Failed AI dependency error occurred, contact support.",
                        innerException: clientDependencyException.InnerException as Xeption);

            var expectedAIDependencyException =
                new AIDependencyException(
                    message: "AI dependency error occurred, contact support.",
                        innerException: failedAIDependencyException);

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
        private async Task ShouldThrowServiceExceptionOnRetrieveIfServiceErrorOccurredAsync()
        {
            // given
            string someNaturalQuery = GetRandomString();
            var serviceException = new Exception();

            var failedAIServiceException =
                new FailedAIServiceException(
                    message: "Failed AI error occurred, contact support.",
                        innerException: serviceException);

            var expectedAIServiceException =
                new AIServiceException(
                    message: "AI error occurred, contact support.",
                        innerException: failedAIServiceException);

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