// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.AIs.Exceptions;
using Standard.AI.OpenAI.Models.Services.Foundations.Completions;
using Xeptions;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Foundations.AIs
{
    public partial class AIServiceTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        private async Task ShouldThrowValidationExceptionOnRetrieveIfQueryIsInvalidAsync(
            string invalidAIQuery)
        {
            // given
            var invalidAIQueryException =
                new InvalidAIQueryException(
                    message: "Invalid AI query error occurred, fix the errors and try again.");

            var expectedAIValidationException =
                new AIValidationException(
                    message: "AI validation error occurred, fix the errors and try again.",
                    invalidAIQueryException.InnerException as Xeption);

            // when
            ValueTask<string> retrieveSqlQueryTask =
                this.aiService.PromptQueryAsync(invalidAIQuery);

            AIValidationException actualAIValidationException =
                await Assert.ThrowsAsync<AIValidationException>(
                    retrieveSqlQueryTask.AsTask);

            // then
            actualAIValidationException.Should().BeEquivalentTo(
                expectedAIValidationException);

            this.aiBrokerMock.Verify(broker =>
                broker.PromptCompletionAsync(It.IsAny<Completion>()),
                    Times.Never);

            this.aiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
