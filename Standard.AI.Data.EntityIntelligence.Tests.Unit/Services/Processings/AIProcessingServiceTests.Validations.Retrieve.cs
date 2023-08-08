// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Datas;
using Standard.AI.Data.EntityIntelligence.Models.Processings.AIs.Exceptions;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Processings
{
    public partial class AIProcessingServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnRetrieveIfTableInformationsIsNullAsync()
        {
            // given
            string someNaturalQuery = GenerateRandomString();
            List<TableInformation> nullTableInformationList = null;

            var tableInformationListAIProcessingException =
                new NullTableInformationListAIProcessingException(
                    message: "Table information list is null.");

            var expectedAIProcessingValidationException =
                new AIProcessingValidationException(
                    message: "AI validation error occurred, fix errors and try again.",
                    innerException: tableInformationListAIProcessingException);

            // when
            ValueTask<string> retrieveSqlQueryTask =
                this.aiProcessingService.RetrieveSqlQueryAsync(
                    tableInformations: nullTableInformationList,
                    naturalQuery: someNaturalQuery);

            AIProcessingValidationException actualAIProcessingValidationException =
                await Assert.ThrowsAsync<AIProcessingValidationException>(
                    retrieveSqlQueryTask.AsTask);

            // then
            actualAIProcessingValidationException.Should().BeEquivalentTo(
                expectedAIProcessingValidationException);

            this.aiServiceMock.Verify(aiService =>
                aiService.PromptQueryAsync(It.IsAny<string>()),
                    Times.Never);

            this.aiServiceMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public async Task ShouldThrowValidationExceptionOnRetrieveIfNaturalQueryIsInvalidAsync(
            string invalidNaturalQuery)
        {
            // given
            List<TableInformation> someTableInformations =
                CreateRandomTableInformations();

            var invalidNaturalQueryAIProcessingException =
                new InvalidNaturalQueryAIProcessingException(
                    message: "Natural query is invalid, fix errors and try again.");

            var expectedAIProcessingValidationException =
                new AIProcessingValidationException(
                    message: "AI validation error occurred, fix errors and try again.",
                    innerException: invalidNaturalQueryAIProcessingException);

            // when
            ValueTask<string> retrieveSqlQueryTask =
                this.aiProcessingService.RetrieveSqlQueryAsync(
                    someTableInformations,
                    invalidNaturalQuery);

            AIProcessingValidationException actualAIProcessingValidationException =
               await Assert.ThrowsAsync<AIProcessingValidationException>(
                   retrieveSqlQueryTask.AsTask);

            // then
            actualAIProcessingValidationException.Should().BeEquivalentTo(
                expectedAIProcessingValidationException);

            this.aiServiceMock.Verify(aiService =>
                aiService.PromptQueryAsync(It.IsAny<string>()),
                    Times.Never);

            this.aiServiceMock.VerifyNoOtherCalls();
        }
    }
}
