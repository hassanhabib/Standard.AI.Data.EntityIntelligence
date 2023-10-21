// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Processings.Datas
{
    public partial class DataProcessingServiceTests
    {
        [Fact]
        private async Task ShouldRetrieveDataAsync()
        {
            // given
            string randomQuery = CreateRandomQuery();
            string inputQuery = randomQuery;

            DataResult randomDataResult =
                CreateRandomDataResult();

            DataResult retrievedDataResult =
                randomDataResult;

            DataResult expectedDataResult =
                retrievedDataResult.DeepClone();

            this.dataServiceMock.Setup(service =>
                service.RetrieveDataAsync(inputQuery))
                    .ReturnsAsync(retrievedDataResult);

            // when
            DataResult actualDataResult =
                await this.dataProcessingService
                    .RetrieveDataAsync(inputQuery);

            // then
            actualDataResult.Should().BeEquivalentTo(
                expectedDataResult);

            this.dataServiceMock.Verify(service =>
                service.RetrieveDataAsync(inputQuery),
                    Times.Once());

            this.dataServiceMock.VerifyNoOtherCalls();
        }
    }
}
