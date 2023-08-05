// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Datas.Services;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Foundations.Datas
{
    public partial class DataServiceTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task ShouldThrowValidationExceptionOnRunQueryIfQueryIsInvalidAsync(
            string invalidQuery)
        {
            // given
            var nullOrEmptyDataQueryException =
                new NullOrEmptyDataQueryException();

            var expectedDataValidationException =
                new DataValidationException(nullOrEmptyDataQueryException);

            ValueTask<IEnumerable<ResultRow>> runQueryTask = 
                this.dataService.RunQueryAsync(invalidQuery);

            DataValidationException actualDataValidationException =
                await Assert.ThrowsAsync<DataValidationException>(
                    runQueryTask.AsTask);

            this.dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<It.IsAnyType>(It.IsAny<string>()),
                    Times.Never);

            this.dataBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(InvalidMultiStatementQueries))]
        public async Task ShouldThrowValidationExceptionOnRunQueryIfQueryContainsMultipleStatementsAsync(
            string invalidQuery)
        {
            // given
            var invalidDataQueryException =
                new InvalidDataQueryException();

            var expectedDataValidationException =
                new DataValidationException(invalidDataQueryException);

            ValueTask<IEnumerable<ResultRow>> runQueryTask =
                this.dataService.RunQueryAsync(invalidQuery);

            DataValidationException actualDataValidationException =
                await Assert.ThrowsAsync<DataValidationException>(
                    runQueryTask.AsTask);

            this.dataBrokerMock.Verify(broker =>
                broker.ExecuteQueryAsync<It.IsAnyType>(It.IsAny<string>()),
                    Times.Never);

            this.dataBrokerMock.VerifyNoOtherCalls();
        }
    }
}
