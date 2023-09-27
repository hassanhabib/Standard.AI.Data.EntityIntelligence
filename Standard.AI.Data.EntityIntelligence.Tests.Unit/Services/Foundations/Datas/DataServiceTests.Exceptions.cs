// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Foundations.Datas
{
    public partial class DataServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRunQueryIfInvalidArgumentExceptionOccursAsync()
        {
            // arrange
            string query = GetValidQuery();

            var invalidArgumentException = new ArgumentException();

            var invalidDataException =
                new InvalidDataException(invalidArgumentException);

            var expectedDataDependencyValidationException =
                new DataServiceDependencyValidationException(invalidDataException);

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<IDictionary<string, object>>(query))
                    .ThrowsAsync(invalidArgumentException);

            // act
            ValueTask<IEnumerable<ResultRow>> runQueryTask =
                this.dataQueryService.RetrieveDataAsync(query);

            var actualRunQueryException =
                await Assert.ThrowsAsync<DataServiceDependencyValidationException>(
                    runQueryTask.AsTask);

            // assert
            actualRunQueryException.Should().BeEquivalentTo(
                expectedDataDependencyValidationException);

            this.dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<It.IsAnyType>(query),
                    Times.Once);

            this.dataBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRunQueryIfInvalidOperationExceptionOccursAsync()
        {
            // arrange
            string query = GetValidQuery();

            var invalidOperationException = new InvalidOperationException();

            var invalidOperationDataException =
                new InvalidOperationDataException(invalidOperationException);

            var expectedDataQueryServiceDependencyValidationException =
                new DataServiceDependencyValidationException(invalidOperationDataException);

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<IDictionary<string, object>>(query))
                    .ThrowsAsync(invalidOperationException);

            // act
            ValueTask<IEnumerable<ResultRow>> runQueryTask =
                this.dataQueryService.RetrieveDataAsync(query);

            var actualRunQueryException =
                await Assert.ThrowsAsync<DataServiceDependencyValidationException>(
                    runQueryTask.AsTask);

            // assert
            actualRunQueryException.Should().BeEquivalentTo(
                expectedDataQueryServiceDependencyValidationException);

            this.dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<It.IsAnyType>(query),
                    Times.Once);

            this.dataBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowSqlDependencyExceptionOnRunQueryIfSqlDependencyExceptionOccursAsync()
        {
            // arrange
            string query = GetValidQuery();
            SqlException sqlException = GetSqlException();

            var failedDataQueryDependencyException =
                new FailedDataDependencyException(sqlException);

            var expectedDataDependencyException =
                new DataServiceDependencyException(
                    failedDataQueryDependencyException);

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<IDictionary<string, object>>(query))
                    .ThrowsAsync(sqlException);

            // act
            ValueTask<IEnumerable<ResultRow>> runQueryTask =
                this.dataQueryService.RetrieveDataAsync(query);

            var actualRunQueryException =
                await Assert.ThrowsAsync<DataServiceDependencyException>(
                    runQueryTask.AsTask);

            // assert
            actualRunQueryException.Should().BeEquivalentTo(
                expectedDataDependencyException);

            this.dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<It.IsAnyType>(query),
                    Times.Once);

            this.dataBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnRunQueryIfServiceErrorOccurredAsync()
        {
            // arrange
            string query = GetValidQuery();
            var serviceException = new Exception();

            var failedDataQueryServiceException =
                new FailedDataServiceException(serviceException);

            var expectedDataQueryServiceException =
                new DataServiceException(
                    failedDataQueryServiceException);

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<IDictionary<string, object>>(query))
                    .ThrowsAsync(serviceException);

            // act
            ValueTask<IEnumerable<ResultRow>> runQueryTask =
                this.dataQueryService.RetrieveDataAsync(query);

            var actualRunQueryException =
                await Assert.ThrowsAsync<DataServiceException>(
                    runQueryTask.AsTask);

            // assert
            actualRunQueryException.Should().BeEquivalentTo(
                expectedDataQueryServiceException);

            this.dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<It.IsAnyType>(query),
                    Times.Once);

            this.dataBrokerMock.VerifyNoOtherCalls();
        }
    }
}
