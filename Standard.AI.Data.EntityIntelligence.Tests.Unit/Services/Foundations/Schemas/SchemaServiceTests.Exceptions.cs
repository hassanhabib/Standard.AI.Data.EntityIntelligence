// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Schemas;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Schemas.Exceptions;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Foundations.Schemas
{
    public partial class SchemaServiceTests
    {
        [Fact]
        private async Task ShouldThrowDependencyValidationExceptionOnRetrieveIfInvalidArgumentExceptionOccursAsync()
        {
            // given
            var invalidArgumentException = new ArgumentException();

            var invalidSchemaException =
                new InvalidSchemaException(
                    message: "Invalid schema validation error occurred, fix the errors and try again.",
                    invalidArgumentException);

            var expectedSchemaDependencyValidationException =
                new SchemaDependencyValidationException(
                    message: "Data validation error occurred, fix the errors and try again.",
                    invalidSchemaException);

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()))
                    .ThrowsAsync(invalidArgumentException);

            // when
            ValueTask<Schema> retrieveSchemaTask =
                this.schemaService.RetrieveSchemaAsync();

            SchemaDependencyValidationException actualSchemaDependencyValidationException =
                await Assert.ThrowsAsync<SchemaDependencyValidationException>(
                    retrieveSchemaTask.AsTask);

            // then
            actualSchemaDependencyValidationException.Should().BeEquivalentTo(
                expectedSchemaDependencyValidationException);

            this.dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()),
                    Times.Once);

            this.dataBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        private async Task ShouldThrowDependencyValidationExceptionOnRetrieveIfInvalidOperationExceptionOccursAsync()
        {
            // given
            var invalidOperationException = new InvalidOperationException();

            var invalidOperationSchemaException =
                new InvalidOperationSchemaException(
                    message: "Invalid operation data validation error occurred, fix the errors and try again.",
                    invalidOperationException);

            var expectedSchemaDependencyValidationException =
                new SchemaDependencyValidationException(
                    message: "Data validation error occurred, fix the errors and try again.",
                    invalidOperationSchemaException);

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()))
                    .ThrowsAsync(invalidOperationException);

            // when
            ValueTask<Schema> retrieveSchemaTask =
                this.schemaService.RetrieveSchemaAsync();

            SchemaDependencyValidationException actualSchemaDependencyValidationException =
                await Assert.ThrowsAsync<SchemaDependencyValidationException>(
                    retrieveSchemaTask.AsTask);

            // then
            actualSchemaDependencyValidationException.Should().BeEquivalentTo(
                expectedSchemaDependencyValidationException);

            this.dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()),
                    Times.Once);

            this.dataBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        private async Task ShouldThrowDependencyExceptionOnRetrieveIfSqlErrorOccursAsync()
        {
            // given
            SqlException sqlException = GetSqlException();

            var failedSchemaDependencyException =
                new FailedSchemaDependencyException(
                    message: "Failed schema dependency error ocurred, contact support.",
                    sqlException);

            var expectedSchemaDependencyException =
                new SchemaDependencyException(
                    message: "Schema dependency error occurred, contact support.",
                    failedSchemaDependencyException);

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()))
                    .ThrowsAsync(sqlException);

            // when
            ValueTask<Schema> retrieveSchemaTask =
                this.schemaService.RetrieveSchemaAsync();

            SchemaDependencyException actualSchemaDependencyException =
                await Assert.ThrowsAsync<SchemaDependencyException>(
                    retrieveSchemaTask.AsTask);

            // then
            actualSchemaDependencyException.Should().BeEquivalentTo(
                expectedSchemaDependencyException);

            this.dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()),
                    Times.Once);

            this.dataBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        private async Task ShouldThrowServiceExceptionOnRetrieveIfServiceErrorOccurredAsync()
        {
            // given
            var serviceException = new Exception();

            var failedSchemaInformationServiceException =
                new FailedSchemaServiceException(
                    message: "Failed schema service error occurred, contact support.",
                    serviceException);

            var expectedSchemaInformationServiceException =
                new SchemaServiceException(
                    message: "Schema service error occurred, contact support.",
                    failedSchemaInformationServiceException);

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<Schema> retrieveSchemaTask =
                this.schemaService.RetrieveSchemaAsync();

            SchemaServiceException actualSchemaServiceException =
                await Assert.ThrowsAsync<SchemaServiceException>(
                    retrieveSchemaTask.AsTask);

            // then
            actualSchemaServiceException.Should().BeEquivalentTo(expectedSchemaInformationServiceException);

            this.dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()),
                    Times.Once);

            this.dataBrokerMock.VerifyNoOtherCalls();
        }
    }
}
