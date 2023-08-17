// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Datas.Brokers;
using Standard.AI.Data.EntityIntelligence.Models.Datas.Services;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Foundations.Datas
{
    public partial class DataServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveIfInvalidArgumentExceptionOccursAsync()
        {
            // given
            var invalidArgumentException = new ArgumentException();

            var invalidDataException =
                new InvalidDataException(invalidArgumentException);

            var expectedDataDependencyValidationException =
                new DataDependencyValidationException(invalidDataException);

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
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveIfInvalidOperationExceptionOccursAsync()
        {
            // given
            var invalidOperationException = new InvalidOperationException();

            var invalidOperationDataException =
                new InvalidOperationDataException(invalidOperationException);

            var expectedDataDependencyValidationException =
                new DataDependencyValidationException(
                    invalidOperationDataException);

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
        public async Task ShouldThrowSqlDependencyExceptionOnRetrieveIfSqlDependencyExceptionOccursAsync()
        {
            // given
            SqlException sqlException = GetSqlException();

            var failedDataDependencyException =
                new FailedDataDependencyException(sqlException);

            var expectedDataDependencyException =
                new DataDependencyException(
                    failedDataDependencyException);

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
        public async Task ShouldThrowServiceExceptionOnRetrieveIfServiceErrorOccurredAsync()
        {
            // given
            var serviceException = new Exception();

            var failedDataServiceException =
                new FailedDataServiceException(serviceException);

            var expectedDataServiceException =
                new DataServiceException(
                    failedDataServiceException);

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
