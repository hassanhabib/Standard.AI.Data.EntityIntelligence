// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Schemas;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Processings.Schemas
{
    public partial class SchemaProcessingServiceTests
    {
        [Fact]
        private async Task ShouldRetrieveSchemaAsync()
        {
            // given
            Schema randomSchema = CreateRandomSchema();
            Schema retrievedSchema = randomSchema;
            Schema expectedSchema = retrievedSchema.DeepClone();

            this.schemaServiceMock.Setup(service =>
                service.RetrieveSchemaAsync())
                    .ReturnsAsync(retrievedSchema);

            // when
            Schema actualSchema =
                await this.schemaProcessingService.RetrieveSchemaAsync();

            // then
            actualSchema.Should().BeEquivalentTo(expectedSchema);

            this.schemaServiceMock.Verify(service =>
                service.RetrieveSchemaAsync(),
                    Times.Once());

            this.schemaServiceMock.VerifyNoOtherCalls();
        }
    }
}
