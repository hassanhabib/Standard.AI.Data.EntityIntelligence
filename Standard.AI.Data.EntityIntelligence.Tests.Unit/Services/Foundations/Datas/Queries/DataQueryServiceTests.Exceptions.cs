// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Datas.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Xunit;
using FluentAssertions;
using System.Data.SqlClient;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Queries.Exceptions;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Foundations.Datas.Queries
{
    public partial class DataQueryServiceTests
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
                new DataQueryServiceDependencyValidationException(invalidDataException);

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<IDictionary<string, object>>(query))
                    .ThrowsAsync(invalidArgumentException);

            // act
            ValueTask<IEnumerable<ResultRow>> runQueryTask =
                this.dataQueryService.RunQueryAsync(query);

            var actualRunQueryException =
                await Assert.ThrowsAsync<DataQueryServiceDependencyValidationException>(
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
                new DataQueryServiceDependencyValidationException(invalidOperationDataException);

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<IDictionary<string, object>>(query))
                    .ThrowsAsync(invalidOperationException);

            // act
            ValueTask<IEnumerable<ResultRow>> runQueryTask =
                this.dataQueryService.RunQueryAsync(query);

            var actualRunQueryException =
                await Assert.ThrowsAsync<DataQueryServiceDependencyValidationException>(
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
                new FailedDataQueryDependencyException(sqlException);

            var expectedDataDependencyException =
                new DataQueryServiceDependencyException(
                    failedDataQueryDependencyException);

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<IDictionary<string, object>>(query))
                    .ThrowsAsync(sqlException);

            // act
            ValueTask<IEnumerable<ResultRow>> runQueryTask =
                this.dataQueryService.RunQueryAsync(query);

            var actualRunQueryException =
                await Assert.ThrowsAsync<DataQueryServiceDependencyException>(
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
                new FailedDataQueryServiceException(serviceException);

            var expectedDataQueryServiceException =
                new DataQueryServiceException(
                    failedDataQueryServiceException);

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<IDictionary<string, object>>(query))
                    .ThrowsAsync(serviceException);

            // act
            ValueTask<IEnumerable<ResultRow>> runQueryTask =
                this.dataQueryService.RunQueryAsync(query);

            var actualRunQueryException =
                await Assert.ThrowsAsync<DataQueryServiceException>(
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
