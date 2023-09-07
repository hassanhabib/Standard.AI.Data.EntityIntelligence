// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Queries;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Queries.Exceptions;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Foundations.Queries
{
    public partial class QueryServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRunQueryIfInvalidArgumentExceptionOccursAsync()
        {
            // given
            string query = GetRandomString();
            var invalidArgumentException = new ArgumentException();

            var invalidArgumentQueryException =
                new InvalidArgumentQueryException(
                    message: "Invalid argument query error occurred, fix the errors and try again.",
                    innerException: invalidArgumentException);

            var expectedQueryServiceDependencyValidationException =
                new QueryServiceDependencyValidationException(
                    message: "Query dependency validation error occurred, fix the errors and try again.",
                    innerException: invalidArgumentQueryException);

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<IDictionary<string, object>>(query))
                    .ThrowsAsync(invalidArgumentException);

            // when
            ValueTask<IEnumerable<ResultRow>> runQueryTask =
                this.queryService.RunQueryAsync(query);

            var actualRunQueryException =
                await Assert.ThrowsAsync<QueryServiceDependencyValidationException>(
                    runQueryTask.AsTask);

            // then
            actualRunQueryException.Should().BeEquivalentTo(
                expectedQueryServiceDependencyValidationException);

            this.dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<It.IsAnyType>(query),
                    Times.Once);

            this.dataBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRunQueryIfInvalidOperationExceptionOccursAsync()
        {
            // given
            string query = GetRandomString();
            var invalidOperationException = new InvalidOperationException();

            var invalidQueryException =
                new InvalidQueryException(
                    message: "Invalid query error occurred, fix the errors and try again.",
                    innerException: invalidOperationException);

            var expectedQueryServiceDependencyValidationException =
                new QueryServiceDependencyValidationException(
                    message: "Query dependency validation error occurred, fix the errors and try again.",
                    innerException: invalidQueryException);

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<IDictionary<string, object>>(query))
                    .ThrowsAsync(invalidOperationException);

            // when
            ValueTask<IEnumerable<ResultRow>> runQueryTask =
                this.queryService.RunQueryAsync(query);

            var actualRunQueryException =
                await Assert.ThrowsAsync<QueryServiceDependencyValidationException>(
                    runQueryTask.AsTask);

            // then
            actualRunQueryException.Should().BeEquivalentTo(
                expectedQueryServiceDependencyValidationException);

            this.dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<It.IsAnyType>(query),
                    Times.Once);

            this.dataBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowQueryServiceDependencyExceptionOnRunQueryIfSqlExceptionOccursAsync()
        {
            // given
            string query = GetRandomString();
            SqlException sqlException = GetSqlException();

            var failedQueryStorageException =
                new FailedQueryStorageException(
                    message: "Failed query storage error occurred, please contact support.",
                    innerException: sqlException);

            var expectedQueryServiceDependencyException =
                new QueryServiceDependencyException(
                    message: "Query dependency error occurred, please contact support.",
                    innerException: failedQueryStorageException);

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<IDictionary<string, object>>(query))
                    .ThrowsAsync(sqlException);

            // when
            ValueTask<IEnumerable<ResultRow>> runQueryTask =
                this.queryService.RunQueryAsync(query);

            var actualRunQueryException =
                await Assert.ThrowsAsync<QueryServiceDependencyException>(
                    runQueryTask.AsTask);

            // then
            actualRunQueryException.Should().BeEquivalentTo(
                expectedQueryServiceDependencyException);

            this.dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<It.IsAnyType>(query),
                    Times.Once);

            this.dataBrokerMock.VerifyNoOtherCalls();
        }
        [Fact]
        public async Task ShouldThrowServiceExceptionOnRunQueryIfServiceErrorOccurredAsync()
        {
            // given
            string query = GetRandomString();
            var serviceException = new Exception();

            var failedQueryServiceException =
                new FailedQueryServiceException(serviceException);

            var expectedQueryServiceException =
                new QueryServiceException(
                    failedQueryServiceException);

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<IDictionary<string, object>>(query))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<IEnumerable<ResultRow>> runQueryTask =
                this.queryService.RunQueryAsync(query);

            var actualRunQueryException =
                await Assert.ThrowsAsync<QueryServiceException>(
                    runQueryTask.AsTask);

            // then
            actualRunQueryException.Should().BeEquivalentTo(
                expectedQueryServiceException);

            this.dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<It.IsAnyType>(query),
                    Times.Once);

            this.dataBrokerMock.VerifyNoOtherCalls();
        }
    }
}
