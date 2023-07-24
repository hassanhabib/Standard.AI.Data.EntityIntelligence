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
        [Theory]
        [MemberData(nameof(DataStorageDependencyValidationExceptions))]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveIfValidationExceptionOccursAsync(
            Exception dataStorageDependencyValidationException)
        {
            // given
            var failedDataDependencyValidationException =
                new FailedDataStorageDependencyValidationException(dataStorageDependencyValidationException);

            var expectedDataDependencyValidationException =
                new DataStorageDependencyValidationException(
                        failedDataDependencyValidationException);

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()))
                    .ThrowsAsync(dataStorageDependencyValidationException);

            // when
            var retrieveTablesDetailsTask = this.dataService.RetrieveTablesDetailsAsync();

            var actualTableInformationListException =
                await Assert.ThrowsAsync<DataStorageDependencyValidationException>(
                                       retrieveTablesDetailsTask.AsTask);

            // then
            actualTableInformationListException.Should().BeEquivalentTo(
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
                new FailedDataStorageDependencyValidationException(sqlException);

            var expectedDataDependencyException =
                new DataStorageDependencyException(
                    failedDataDependencyException);

            this.dataBrokerMock.Setup(broker => 
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()))
                    .ThrowsAsync(sqlException);

            // when
            var retrieveTablesDetailsTask = this.dataService.RetrieveTablesDetailsAsync();

            var actualTableInformationListException =
                await Assert.ThrowsAsync<DataStorageDependencyException>(
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
