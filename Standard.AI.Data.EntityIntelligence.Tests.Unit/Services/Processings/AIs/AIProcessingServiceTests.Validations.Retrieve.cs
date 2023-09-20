// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.TableMetadatas;
using Standard.AI.Data.EntityIntelligence.Models.Processings.AIs.Exceptions;
using Tynamix.ObjectFiller;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Processings.AIs
{
    public partial class AIProcessingServiceTests
    {
        [Theory]
        [MemberData(nameof(InvalidTableInformationLists))]
        private async Task ShouldThrowValidationExceptionOnRetrieveIfTableInformationsIsInvalidAsync(
            List<TableInformation> invalidTableInformation)
        {
            // given
            string someNaturalQuery = CreateRandomString();

            var tableInformationListAIProcessingException =
                new InvalidTableInformationListAIProcessingException(
                    message: "Table information list is null or empty.");

            var expectedAIProcessingValidationException =
                new AIProcessingValidationException(
                    message: "AI validation error occurred, fix errors and try again.",
                    innerException: tableInformationListAIProcessingException);

            // when
            ValueTask<string> retrieveSqlQueryTask =
                aiProcessingService.RetrieveSqlQueryAsync(
                    tableInformations: invalidTableInformation,
                    naturalQuery: someNaturalQuery);

            AIProcessingValidationException actualAIProcessingValidationException =
                await Assert.ThrowsAsync<AIProcessingValidationException>(
                    retrieveSqlQueryTask.AsTask);

            // then
            actualAIProcessingValidationException.Should().BeEquivalentTo(
                expectedAIProcessingValidationException);

            aiServiceMock.Verify(aiService =>
                aiService.PromptQueryAsync(It.IsAny<string>()),
                    Times.Never);

            aiServiceMock.VerifyNoOtherCalls();
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
                aiProcessingService.RetrieveSqlQueryAsync(
                    someTableInformations,
                    invalidNaturalQuery);

            AIProcessingValidationException actualAIProcessingValidationException =
               await Assert.ThrowsAsync<AIProcessingValidationException>(
                   retrieveSqlQueryTask.AsTask);

            // then
            actualAIProcessingValidationException.Should().BeEquivalentTo(
                expectedAIProcessingValidationException);

            aiServiceMock.Verify(aiService =>
                aiService.PromptQueryAsync(It.IsAny<string>()),
                    Times.Never);

            aiServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        private async Task ShouldThrowValidationExceptionOnRetrieveIfTableInformationsHasInvalidItemsAsync()
        {
            // given
            string someNaturalQuery = CreateRandomString();

            List<TableInformation> randomTableInformations =
                CreateRandomTableInformations();

            List<TableInformation> invalidTableInformations =
                randomTableInformations;

            int randomInvalidItemsCount =
                new IntRange(min: 1, max: randomTableInformations.Count)
                    .GetValue();

            List<int> uniqueRandomNumbers = Shuffle(
                list: Enumerable.Range(0, invalidTableInformations.Count))
                    .Take(randomInvalidItemsCount).ToList();

            var invalidTableInformationListAIProcessingException =
                new InvalidTableInformationListAIProcessingException(
                    message: "Table information list is null or empty.");

            invalidTableInformations = invalidTableInformations.Select((tableInformation, index) =>
            {
                if (uniqueRandomNumbers.Contains(index))
                {
                    invalidTableInformationListAIProcessingException.AddData(
                        key: $"Element at {index}",
                        values: "Object is required");

                    return null;
                }

                return tableInformation;
            }).ToList();

            var expectedAIProcessingValidationException =
                new AIProcessingValidationException(
                    message: "AI validation error occurred, fix errors and try again.",
                    innerException: invalidTableInformationListAIProcessingException);

            // when
            ValueTask<string> retrieveSqlQueryTask =
                aiProcessingService.RetrieveSqlQueryAsync(
                    invalidTableInformations,
                    someNaturalQuery);

            AIProcessingValidationException actualAIProcessingValidationException =
               await Assert.ThrowsAsync<AIProcessingValidationException>(
                   retrieveSqlQueryTask.AsTask);

            // then
            actualAIProcessingValidationException.Should().BeEquivalentTo(
                expectedAIProcessingValidationException);

            aiServiceMock.Verify(aiService =>
                aiService.PromptQueryAsync(It.IsAny<string>()),
                    Times.Never);

            aiServiceMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(InvalidTableInformations))]
        private async Task ShouldThrowValidationExceptionOnRetrieveIfTableInformationHasInvalidTableNamesOrColumnsAsync(
            TableInformation invalidTableInformation)
        {
            // given
            string someNaturalQuery = CreateRandomString();

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
                new InvalidTableInformationAIProcessingException(
                    message: "Table information is invalid.");

            invalidTableInformations = invalidTableInformations.Select((tableInformation, index) =>
            {
                if (uniqueRandomNumbers.Contains(index))
                {
                    tableInformation = invalidTableInformation;

                    invalidTableInformationAIProcessingException.AddData(
                        key: $"Name at {index}",
                        values: "Name is required");

                    invalidTableInformationAIProcessingException.AddData(
                       key: $"Columns at {index}",
                       values: "Columns are required");
                }

                return tableInformation;

            }).ToList();

            var expectedAIProcessingValidationException =
                new AIProcessingValidationException(
                    message: "AI validation error occurred, fix errors and try again.",
                    innerException: invalidTableInformationAIProcessingException);

            // when
            ValueTask<string> retrieveSqlQueryTask =
                aiProcessingService.RetrieveSqlQueryAsync(
                    invalidTableInformations,
                    someNaturalQuery);

            AIProcessingValidationException actualAIProcessingValidationException =
               await Assert.ThrowsAsync<AIProcessingValidationException>(
                   retrieveSqlQueryTask.AsTask);

            // then
            actualAIProcessingValidationException.Should().BeEquivalentTo(
                expectedAIProcessingValidationException);

            aiServiceMock.Verify(aiService =>
                aiService.PromptQueryAsync(It.IsAny<string>()),
                    Times.Never);

            aiServiceMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(InvalidTableInformationColumns))]
        private async Task ShouldThrowValidationExceptionOnRetrieveIfTableInformationHasInvalidColumns(TableColumn invalidColumn)
        {
            // given
            string someNaturalQuery = CreateRandomString();

            List<TableInformation> randomTableInformation =
                CreateRandomTableInformations();

            List<TableInformation> tableInformationsWithInvalidColumns =
                randomTableInformation;

            int randomCountOfTableInformationsWithInvalidColumns =
                new IntRange(min: 1, max: randomTableInformation.Count)
                    .GetValue();

            List<int> uniqueRandomNumbers = Shuffle(
                list: Enumerable.Range(0, tableInformationsWithInvalidColumns.Count))
                    .Take(randomCountOfTableInformationsWithInvalidColumns).ToList();

            var invalidTableInformationColumnAIProcessingException =
                new InvalidTableInformationColumnAIProcessingException(
                    message: "Table column is invalid.");

            tableInformationsWithInvalidColumns = tableInformationsWithInvalidColumns.Select((tableInformation, tableIndex) =>
            {
                if (uniqueRandomNumbers.Contains(tableIndex))
                {
                    int randomInvalidColumnsCount = new IntRange(min: 1, max: tableInformation.Columns.Count()).GetValue();

                    List<int> uniqueInvalidRandomColumnIndices = Shuffle(
                        list: Enumerable.Range(0, tableInformation.Columns.Count()))
                            .Take(randomInvalidColumnsCount).ToList();

                    tableInformation.Columns = tableInformation.Columns.Select((column, columnIndex) =>
                    {
                        if (uniqueInvalidRandomColumnIndices.Contains(columnIndex))
                        {
                            column = invalidColumn;
                            invalidTableInformationColumnAIProcessingException.AddData(
                               key: $"Table {tableInformation.Name} Column {columnIndex}",
                               values: "Column is invalid");
                        }

                        return column;
                    }).ToList();
                }

                return tableInformation;

            }).ToList();

            var expectedAIProcessingValidationException =
                new AIProcessingValidationException(
                    message: "AI validation error occurred, fix errors and try again.",
                    innerException: invalidTableInformationColumnAIProcessingException);

            // when
            ValueTask<string> retrieveSqlQueryTask =
                aiProcessingService.RetrieveSqlQueryAsync(
                    tableInformationsWithInvalidColumns,
                    someNaturalQuery);

            AIProcessingValidationException actualAIProcessingValidationException =
               await Assert.ThrowsAsync<AIProcessingValidationException>(
                   retrieveSqlQueryTask.AsTask);

            // then
            actualAIProcessingValidationException.Should().BeEquivalentTo(
                expectedAIProcessingValidationException);

            aiServiceMock.Verify(aiService =>
                aiService.PromptQueryAsync(It.IsAny<string>()),
                    Times.Never);

            aiServiceMock.VerifyNoOtherCalls();
        }
    }
}
