// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.AIs.Exceptions;
using Standard.AI.OpenAI.Models.Services.Foundations.Completions;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Foundations.AIs
{
    public partial class AIServiceTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task ShouldThrowValidationExceptionOnRetrieveIfQueryIsInvalidAsync(
            string invalidAIQuery)
        {
            // given
            var invalidAIQueryException = 
                new InvalidAIQueryException();

            var expectedAIValidationException =
                new AIValidationException(invalidAIQueryException);

            // when
            ValueTask<string> retrieveSqlQueryTask =
                this.aiService.RetrieveSqlQueryAsync(invalidAIQuery);

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
