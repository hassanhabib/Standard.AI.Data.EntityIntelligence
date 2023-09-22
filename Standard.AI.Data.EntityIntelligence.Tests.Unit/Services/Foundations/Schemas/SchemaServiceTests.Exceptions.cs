// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
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
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveIfInvalidArgumentExceptionOccursAsync()
        {
            // given
            var invalidArgumentException = new ArgumentException();

            var invalidDataException =
                new InvalidDataException(invalidArgumentException);

            var expectedDataDependencyValidationException =
                new SchemaServiceDependencyValidationException(invalidDataException);

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()))
                    .ThrowsAsync(invalidArgumentException);

            // when
            ValueTask<IEnumerable<TableInformation>> retrieveTableMetadatasTask =
                this.metadataQueryService.RetrieveTableInformationsAsync();

            var actualTableMetadatasException =
                await Assert.ThrowsAsync<SchemaServiceDependencyValidationException>(
                    retrieveTableMetadatasTask.AsTask);

            // then
            actualTableMetadatasException.Should().BeEquivalentTo(
                expectedDataDependencyValidationException);

            this.dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()),
                    Times.Once);

            this.dataBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveIfInvalidOperationExceptionOccursAsync()
        {
            // given
            var invalidOperationException = new InvalidOperationException();

            var invalidOperationDataException =
                new InvalidOperationDataException(invalidOperationException);

            var expectedDataDependencyValidationException =
                new SchemaServiceDependencyValidationException(
                    invalidOperationDataException);

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()))
                    .ThrowsAsync(invalidOperationException);

            // when
            ValueTask<IEnumerable<TableInformation>> retrieveTableMetadatasTask =
                this.metadataQueryService.RetrieveTableInformationsAsync();

            var actualTableMetadatasException =
                await Assert.ThrowsAsync<SchemaServiceDependencyValidationException>(
                    retrieveTableMetadatasTask.AsTask);

            // then
            actualTableMetadatasException.Should().BeEquivalentTo(
                expectedDataDependencyValidationException);

            this.dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()),
                    Times.Once);

            this.dataBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowSqlDependencyExceptionOnRetrieveIfSqlDependencyExceptionOccursAsync()
        {
            // given
            SqlException sqlException = GetSqlException();

            var failedDataDependencyException =
                new FailedDataDependencyException(sqlException);

            var expectedDataDependencyException =
                new SchemaServiceDependencyException(
                    failedDataDependencyException);

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()))
                    .ThrowsAsync(sqlException);

            // when
            ValueTask<IEnumerable<TableInformation>> retrieveTableMetadatasTask =
                this.metadataQueryService.RetrieveTableInformationsAsync();

            var actualTableInformationListException =
                await Assert.ThrowsAsync<SchemaServiceDependencyException>(
                    retrieveTableMetadatasTask.AsTask);

            // then
            actualTableInformationListException.Should().BeEquivalentTo(
                expectedDataDependencyException);

            this.dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()),
                    Times.Once);

            this.dataBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnRetrieveIfServiceErrorOccurredAsync()
        {
            // given
            var serviceException = new Exception();

            var failedDataInformationServiceException =
                new FailedSchemaServiceException(serviceException);

            var expectedDataInformationServiceException =
                new SchemaServiceException(
                    failedDataInformationServiceException);

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<IEnumerable<TableInformation>> retrieveTableMetadatasTask =
                this.metadataQueryService.RetrieveTableInformationsAsync();

            var actualTableInformationListException =
                await Assert.ThrowsAsync<SchemaServiceException>(
                    retrieveTableMetadatasTask.AsTask);

            // then
            actualTableInformationListException.Should().BeEquivalentTo(expectedDataInformationServiceException);

            this.dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()),
                    Times.Once);

            this.dataBrokerMock.VerifyNoOtherCalls();
        }
    }
}
