// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Processings.AIs.Exceptions;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Processings
{
    public partial class AIProcessingServiceTests
    {
        //TODO: the member data is only accepting functions that return one value and thats why we are using a tuple.
        [Theory]
        [MemberData(nameof(InvalidTableInformationsAndInvalidNaturalQueries))]
        public async Task ShouldThrowValidationExceptionOnRetrieveSqlQueryIfTableInformationOrNaturalQueryAreInvalid(
            Tuple<dynamic, string> tableInformationsAndNaturalQuery)
        {
            // given
            var invalidTableInformations = tableInformationsAndNaturalQuery.Item1;
            var invalidNaturalQuery = tableInformationsAndNaturalQuery.Item2;

            var invalidAIProcessingException =
                new InvalidAIProcessingQueryException();

            var expectedAIValidationException =
                new AIProcessingValidationException(invalidAIProcessingException);

            // when
            ValueTask<string> retrieveSqlQueryTask =
                this.aiProcessingService.RetrieveSqlQueryAsync(invalidTableInformations, invalidNaturalQuery);

            AIProcessingValidationException actualAIProcessingValidationException =
                await Assert.ThrowsAsync<AIProcessingValidationException>(
                    retrieveSqlQueryTask.AsTask);

            // then
            actualAIProcessingValidationException.Should().BeEquivalentTo(
                expectedAIValidationException);

            this.aiServiceMock.Verify(aiService =>
                aiService.PromptQueryAsync(It.IsAny<string>()),
                    Times.Never);

        }
    }
}
