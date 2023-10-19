// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Schemas;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Schemas.Exceptions;
using Standard.AI.Data.EntityIntelligence.Models.Processings.Schemas.Exceptions;
using Xeptions;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Processings.Schemas
{
    public partial class SchemaProcessingServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveIfSchemaDependencyValidationErrorAsync()
        {
            // given
            var someInnerException = new Xeption();

            var schemaDependencyValidationException =
                new SchemaDependencyValidationException(someInnerException);

            var expectedSchemaProcessingDependencyValidationException =
                new SchemaProcessingDependencyValidationException(
                   message: "Schema dependency validation error occurred, fix errors and try again.",
                   innerException: someInnerException);

            this.schemaServiceMock.Setup(service =>
                service.RetrieveSchemaAsync())
                    .ThrowsAsync(schemaDependencyValidationException);

            // when
            ValueTask<Schema> retrieveSchemaTask =
                this.schemaProcessingService.RetrieveSchemaAsync();

            SchemaProcessingDependencyValidationException actualSchemaProcessingDependencyValidationException =
                await Assert.ThrowsAsync<SchemaProcessingDependencyValidationException>(
                    retrieveSchemaTask.AsTask);

            // then
            actualSchemaProcessingDependencyValidationException.Should()
                .BeEquivalentTo(expectedSchemaProcessingDependencyValidationException);

            this.schemaServiceMock.Verify(service =>
                service.RetrieveSchemaAsync(),
                    Times.Once());

            this.schemaServiceMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(SchemaDependencyExceptions))]
        public async Task ShouldThrowDependencyExceptionOnRetrieveIfSchemaDependencyValidationErrorAsync(
            Xeption schemaDependencyException)
        {
            // given
            var expectedSchemaProcessingDependencyException =
                new SchemaProcessingDependencyException(
                   message: "Schema dependency error occurred, contact support.",
                   innerException: schemaDependencyException.InnerException as Xeption);

            this.schemaServiceMock.Setup(service =>
                service.RetrieveSchemaAsync())
                    .ThrowsAsync(schemaDependencyException);

            // when
            ValueTask<Schema> retrieveSchemaTask =
                this.schemaProcessingService.RetrieveSchemaAsync();

            SchemaProcessingDependencyException actualSchemaProcessingDependencyException =
                await Assert.ThrowsAsync<SchemaProcessingDependencyException>(
                    retrieveSchemaTask.AsTask);

            // then
            actualSchemaProcessingDependencyException.Should()
                .BeEquivalentTo(expectedSchemaProcessingDependencyException);

            this.schemaServiceMock.Verify(service =>
                service.RetrieveSchemaAsync(),
                    Times.Once());

            this.schemaServiceMock.VerifyNoOtherCalls();
        }
    }
}
