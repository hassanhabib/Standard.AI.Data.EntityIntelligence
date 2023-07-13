// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Standard.AI.OpenAI.Models.Services.Foundations.Completions;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Foundations.AIs
{
    public partial class AIServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveSqlQueryAsync()
        {
            // given
            string randomNaturalQuery = GetRandomString();
            string inputNaturalQuery = randomNaturalQuery;
            string randomSqlQuery = GetRandomString();
            string retrievedSqlQuery = randomSqlQuery;
            string expectedSqlQuery = retrievedSqlQuery;

            var expectedInputCompletion = new Completion
            {
                Request = new CompletionRequest
                {
                    Prompts = new string[] {
                        inputNaturalQuery
                    },

                    Model = "text-davinci-003",
                    MaxTokens = 100
                }
            };

            Completion retrievedCompletion = expectedInputCompletion.DeepClone();

            retrievedCompletion.Response = new CompletionResponse
            {
                Choices = new Choice[]
                {
                    new Choice
                    {
                        Text = retrievedSqlQuery
                    }
                }
            };

            this.aiBrokerMock.Setup(broker =>
                broker.PromptCompletionAsync(It.Is(
                    SameCompletionAs(expectedInputCompletion))))
                        .ReturnsAsync(retrievedCompletion);

            // when
            string actualSqlQuery =
                await this.aiService.RetrieveSqlQueryAsync(inputNaturalQuery);

            // then
            actualSqlQuery.Should().Be(expectedSqlQuery);

            this.aiBrokerMock.Verify(broker =>
                broker.PromptCompletionAsync(It.Is(
                    SameCompletionAs(expectedInputCompletion))),
                        Times.Once);

            this.aiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
