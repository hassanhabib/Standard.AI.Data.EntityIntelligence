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
                new NullTableInformationListAIProcessingException();

            var expectedAIProcessingValidationException =
                new AIProcessingValidationException(
                    tableInformationListAIProcessingException);

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
    }
}
