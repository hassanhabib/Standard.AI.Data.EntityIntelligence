// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Datas.Brokers;
using Standard.AI.Data.EntityIntelligence.Models.Datas.Services;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Xunit;
using FluentAssertions;

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
                new DataDependencyValidationException(invalidDataException);

            this.dataBrokerMock.Setup(broker =>
                broker.ExecuteQueryAsync<It.IsAnyType>(query))
                    .ThrowsAsync(invalidArgumentException);

            // act
            ValueTask<IEnumerable<ResultRow>> runQueryTask =
                this.dataService.RunQueryAsync(query);

            var actualRunQueryException =
                await Assert.ThrowsAsync<DataDependencyValidationException>(
                    runQueryTask.AsTask);

            // assert
            actualRunQueryException.Should().BeEquivalentTo(
                expectedDataDependencyValidationException);

            this.dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<It.IsAnyType>(query),
                    Times.Once);

            this.dataBrokerMock.VerifyNoOtherCalls();
        }
    }
}
