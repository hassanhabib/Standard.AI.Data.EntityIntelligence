// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Standard.AI.Data.EntityIntelligence.Services.Foundations.AIs;
using Standard.AI.Data.EntityIntelligence.Services.Processings.AIs;
using Tynamix.ObjectFiller;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Processings
{
    internal partial class AIProcessingServiceTests
    {
        private readonly Mock<IAIService> aiServiceMock;
        private readonly IAIProcessingService aiProcessingService;

        public AIProcessingServiceTests()
        {
            this.aiServiceMock = new Mock<IAIService>();

            this.aiProcessingService = new AIProcessingService(
                aiService: this.aiServiceMock.Object);
        }

        private static List<Dictionary<string, Dictionary<string, string>>>
            GenerateRandomTablesInformation()
        {
            int tablesCount = GetRandomNumber();

            return Enumerable.Range(0, tablesCount)
                .Select(item => GenerateRandomTable())
                    .ToList();
        }

        private static Dictionary<string, Dictionary<string, string>> GenerateRandomTable()
        {
            string randomTableName = GenerateRandomString();
            int randomColumnCount = GetRandomNumber();
            var columnsDictionary = new Dictionary<string, string>();
            
            var tableDictionary = 
                new Dictionary<string, Dictionary<string, string>>();

            for(int i = 0; i <= randomColumnCount; i++)
            {
                columnsDictionary.Add(
                    key: GenerateRandomString(), 
                    value: GenerateRandomString());
            }

            tableDictionary.Add(randomTableName, columnsDictionary);

            return tableDictionary;
        }

        private static string GenerateRandomString() =>
            new MnemonicString().GetValue();

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();
    }
}
