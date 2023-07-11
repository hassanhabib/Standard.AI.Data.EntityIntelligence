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
            var someValidationException = new Exception();

            var completionClientValidationException =
                new CompletionClientValidationException(
                    someValidationException as Xeption);

            this.aiBrokerMock.Setup(broker =>
                broker.PromptCompletionAsync(It.IsAny<Completion>()))
                    .ThrowsAsync(completionClientValidationException);

            var expectedAIDependencyValidationException =
                new AIDependencyValidationException(
                    completionClientValidationException.InnerException as Xeption);

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
    }
}
