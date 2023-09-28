﻿// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------


using Moq;
using Standard.AI.Data.EntityIntelligence.Services.Foundations.Datas;
using Standard.AI.Data.EntityIntelligence.Services.Processings.Datas;
using Tynamix.ObjectFiller;
using DataResult = Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Data;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Processings.Datas
{
    public partial class DataProcessingServiceTests
    {
        private readonly Mock<IDataService> dataServiceMock;
        private readonly IDataProcessingService dataProcessingService;

        public DataProcessingServiceTests()
        {
            this.dataServiceMock = new Mock<IDataService>();

            this.dataProcessingService = new DataProcessingService(
                dataService: this.dataServiceMock.Object);
        }

        private static string CreateRandomQuery() =>
            new MnemonicString().GetValue();

        private static string CreateRandomString() =>
            new MnemonicString().GetValue();

        private static DataResult CreateRandomDataResult() =>
            CreateDataResultFiller().Create();

        private static Filler<DataResult> CreateDataResultFiller()
        {
            var filler = new Filler<DataResult>();

            filler.Setup()
                .OnType<object>().Use(CreateRandomString);

            return filler;
        }
    }
}
