// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Informations;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Informations.Exceptions;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Foundations.Informations
{
    public partial class DataInformationServiceTests
    {
        [Fact]
        private async Task ShouldThrowDependencyValidationExceptionOnRetrieveIfInvalidArgumentExceptionOccursAsync()
        {
            // given
            var invalidArgumentException = new ArgumentException();

            var invalidDataException =
                new InvalidDataException(
                    message: "Invalid data validation error occurred, fix the errors and try again.",
                    innerException: invalidArgumentException);

            var expectedDataDependencyValidationException =
                new DataDependencyValidationException(
                    message: "Data validation error occurred, fix the errors and try again.",
                    innerException: invalidDataException);

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()))
                    .ThrowsAsync(invalidArgumentException);

            // when
            ValueTask<IEnumerable<TableMetadata>> retrieveTableMetadatasTask = 
                this.dataService.RetrieveTableMetadatasAsync();

            var actualTableMetadatasException =
                await Assert.ThrowsAsync<DataDependencyValidationException>(
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
        private async Task ShouldThrowDependencyValidationExceptionOnRetrieveIfInvalidOperationExceptionOccursAsync()
        {
            // given
            var invalidOperationException = new InvalidOperationException();

            var invalidOperationDataException =
                new InvalidOperationDataException(
                    message: "Invalid operation data validation error occurred, fix the errors and try again.",
                    innerException: invalidOperationException);

            var expectedDataDependencyValidationException =
                new DataDependencyValidationException(
                    message: "Data validation error occurred, fix the errors and try again.",
                    innerException: invalidOperationDataException);

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()))
                    .ThrowsAsync(invalidOperationException);

            // when
            ValueTask<IEnumerable<TableMetadata>> retrieveTableMetadatasTask = 
                this.dataService.RetrieveTableMetadatasAsync();

            var actualTableMetadatasException =
                await Assert.ThrowsAsync<DataDependencyValidationException>(
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
        private async Task ShouldThrowSqlDependencyExceptionOnRetrieveIfSqlDependencyExceptionOccursAsync()
        {
            // given
            SqlException sqlException = GetSqlException();

            var failedDataDependencyException =
                new FailedDataDependencyException(
                    message: "Failed data dependency error occurred, contact support.",
                    innerException: sqlException);

            var expectedDataDependencyException =
                new DataDependencyException(
                    message: "Data dependency error occurred, contact support.",
                    innerException: failedDataDependencyException);

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()))
                    .ThrowsAsync(sqlException);

            // when
            ValueTask<IEnumerable<TableMetadata>> retrieveTableMetadatasTask = 
                this.dataService.RetrieveTableMetadatasAsync();

            var actualTableInformationListException =
                await Assert.ThrowsAsync<DataDependencyException>(
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
        private async Task ShouldThrowServiceExceptionOnRetrieveIfServiceErrorOccurredAsync()
        {
            // given
            var serviceException = new Exception();

            var failedDataServiceException =
                new FailedDataServiceException(
                    message: "Failed data service error occurred, contact support.",
                    innerException: serviceException);

            var expectedDataServiceException =
                new DataServiceException(
                    message: "Data service error occurred, contact support.",
                    innerException: failedDataServiceException);

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<IEnumerable<TableMetadata>> retrieveTableMetadatasTask = 
                this.dataService.RetrieveTableMetadatasAsync();

            var actualTableInformationListException =
                await Assert.ThrowsAsync<DataServiceException>(
                    retrieveTableMetadatasTask.AsTask);

            // then
            actualTableInformationListException.Should().BeEquivalentTo(expectedDataServiceException);

            this.dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()),
                    Times.Once);

            this.dataBrokerMock.VerifyNoOtherCalls();
        }
    }
}
