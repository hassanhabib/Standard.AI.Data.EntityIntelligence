// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Datas;
using Standard.AI.Data.EntityIntelligence.Models.Datas.Brokers;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.TableMetadatas.Exceptions;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Foundations.Datas.TableMetadatas
{
    public partial class DataInformationServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveIfInvalidArgumentExceptionOccursAsync()
        {
            // given
            var invalidArgumentException = new ArgumentException();

            var invalidDataException =
                new InvalidDataException(invalidArgumentException);

            var expectedDataDependencyValidationException =
                new DataInformationServiceDependencyValidationException(invalidDataException);

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()))
                    .ThrowsAsync(invalidArgumentException);

            // when
            ValueTask<IEnumerable<TableInformation>> retrieveTableMetadatasTask =
                this.dataInformationService.RetrieveTableInformationsAsync();

            var actualTableMetadatasException =
                await Assert.ThrowsAsync<DataInformationServiceDependencyValidationException>(
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
                new DataInformationServiceDependencyValidationException(
                    invalidOperationDataException);

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()))
                    .ThrowsAsync(invalidOperationException);

            // when
            ValueTask<IEnumerable<TableInformation>> retrieveTableMetadatasTask =
                this.dataInformationService.RetrieveTableInformationsAsync();

            var actualTableMetadatasException =
                await Assert.ThrowsAsync<DataInformationServiceDependencyValidationException>(
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
                new DataInformationServiceDependencyException(
                    failedDataDependencyException);

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()))
                    .ThrowsAsync(sqlException);

            // when
            ValueTask<IEnumerable<TableInformation>> retrieveTableMetadatasTask =
                this.dataInformationService.RetrieveTableInformationsAsync();

            var actualTableInformationListException =
                await Assert.ThrowsAsync<DataInformationServiceDependencyException>(
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
                new FailedDataInformationServiceException(serviceException);

            var expectedDataInformationServiceException =
                new DataInformationServiceException(
                    failedDataInformationServiceException);

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<TableColumnMetadata>(It.IsAny<string>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<IEnumerable<TableInformation>> retrieveTableMetadatasTask =
                this.dataInformationService.RetrieveTableInformationsAsync();

            var actualTableInformationListException =
                await Assert.ThrowsAsync<DataInformationServiceException>(
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
