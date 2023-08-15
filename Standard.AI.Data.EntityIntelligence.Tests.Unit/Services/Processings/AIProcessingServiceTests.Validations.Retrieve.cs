// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Datas;
using Standard.AI.Data.EntityIntelligence.Models.Processings.AIs.Exceptions;
using Tynamix.ObjectFiller;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Processings
{
    public partial class AIProcessingServiceTests
    {
        [Theory]
        [MemberData(nameof(InvalidTableInformations))]
        private async Task ShouldThrowValidationExceptionOnRetrieveIfTableInformationsIsInvalidAsync(
            List<TableInformation> invalidTableInformation)
        {
            // given
            string someNaturalQuery = GenerateRandomString();

            var tableInformationListAIProcessingException =
                new InvalidTableInformationListAIProcessingException(
                    message: "Table information list is null or empty.");

            var expectedAIProcessingValidationException =
                new AIProcessingValidationException(
                    message: "AI validation error occurred, fix errors and try again.",
                    innerException: tableInformationListAIProcessingException);

            // when
            ValueTask<string> retrieveSqlQueryTask =
                this.aiProcessingService.RetrieveSqlQueryAsync(
                    tableInformations: invalidTableInformation,
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
        private async Task ShouldThrowValidationExceptionOnRetrieveIfNaturalQueryIsInvalidAsync(
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

        [Fact]
        private async Task ShouldThrowValidationExceptionOnRetrieveIfTableInformationsHasInvalidItemsAsync()
        {
            // given
            string someNaturalQuery = GenerateRandomString();

            List<TableInformation> randomTableInformation =
                CreateRandomTableInformations();

            List<TableInformation> invalidTableInformations =
                randomTableInformation;

            int randomInvalidItemsCount =
                new IntRange(min: 1, max: randomTableInformation.Count)
                    .GetValue();

            List<int> uniqueRandomNumbers = Shuffle(
                list: Enumerable.Range(0, invalidTableInformations.Count))
                    .Take(randomInvalidItemsCount).ToList();

            var invalidTableInformationAIProcessingException =
                new InvalidTableInformationListAIProcessingException(
                    message: "Table information list is null or empty.");

            invalidTableInformations = invalidTableInformations.Select((tableInformation, index) =>
            {
                if (uniqueRandomNumbers.Contains(index))
                {
                    invalidTableInformationAIProcessingException.AddData(
                        key: $"Element at {index}",
                        values: "Object is required");
                    return null;
                }

                return tableInformation;
            }).ToList();

            var expectedAIProcessingValidationException =
                new AIProcessingValidationException(
                    message: "AI validation error occurred, fix errors and try again.",
                    innerException: invalidTableInformationAIProcessingException);
            
            // when
            ValueTask<string> retrieveSqlQueryTask =
                this.aiProcessingService.RetrieveSqlQueryAsync(
                    invalidTableInformations,
                    someNaturalQuery);

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
