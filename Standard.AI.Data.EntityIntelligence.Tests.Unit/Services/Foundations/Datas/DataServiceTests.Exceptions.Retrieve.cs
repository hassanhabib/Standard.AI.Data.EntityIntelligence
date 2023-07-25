// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Datas.Brokers;
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

            var invalidDataValidationException =
                new InvalidDataValidationException(invalidArgumentException);

            var expectedDataDependencyValidationException =
                new DataDependencyValidationException(invalidDataValidationException);

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()))
                    .ThrowsAsync(invalidArgumentException);

            // when
            var retrieveTablesDetailsTask = this.dataService.RetrieveTablesDetailsAsync();

            var actualTableDetailsException =
                await Assert.ThrowsAsync<DataDependencyValidationException>(
                                       retrieveTablesDetailsTask.AsTask);

            // then
            actualTableDetailsException.Should().BeEquivalentTo(
                expectedDataDependencyValidationException);

            this.dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()),
                    Times.Once);
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveIfInvalidOperationExceptionOccursAsync()
        {
            // given
            var invalidOperationException = new InvalidOperationException();

            var invalidOperationDataValidationException =
                new InvalidOperationDataValidationException(invalidOperationException);

            var expectedDataDependencyValidationException =
                new DataDependencyValidationException(
                        invalidOperationDataValidationException);

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()))
                    .ThrowsAsync(invalidOperationException);

            // when
            var retrieveTablesDetailsTask = this.dataService.RetrieveTablesDetailsAsync();

            var actualTableDetailsException =
                await Assert.ThrowsAsync<DataDependencyValidationException>(
                                       retrieveTablesDetailsTask.AsTask);

            // then
            actualTableDetailsException.Should().BeEquivalentTo(
                expectedDataDependencyValidationException);

            this.dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()),
                    Times.Once);
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnSqlException()
        {
            // given
            SqlException sqlException = GetSqlException();

            var failedDataDependencyException =
                new FailedDataDependencyValidationException(sqlException);

            var expectedDataDependencyException =
                new DataDependencyException(
                    failedDataDependencyException);

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()))
                    .ThrowsAsync(sqlException);

            // when
            var retrieveTablesDetailsTask = this.dataService.RetrieveTablesDetailsAsync();

            var actualTableInformationListException =
                await Assert.ThrowsAsync<DataDependencyException>(
                                       retrieveTablesDetailsTask.AsTask);

            // then
            actualTableInformationListException.Should().BeEquivalentTo(
                expectedDataDependencyException);

            this.dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()),
                    Times.Once);
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
            var retrieveTablesDetailsTask = this.dataService.RetrieveTablesDetailsAsync();

            var actualTableInformationListException =
                await Assert.ThrowsAsync<DataServiceException>(
                                       retrieveTablesDetailsTask.AsTask);

            // then
            actualTableInformationListException.Should().BeEquivalentTo(expectedDataServiceException);

            this.dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()),
                    Times.Once);
        }
    }
}
