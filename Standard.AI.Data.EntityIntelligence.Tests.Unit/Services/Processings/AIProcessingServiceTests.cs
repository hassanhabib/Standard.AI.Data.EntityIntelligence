﻿// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Datas;
using Standard.AI.Data.EntityIntelligence.Services.Foundations.AIs;
using Standard.AI.Data.EntityIntelligence.Services.Processings.AIs;
using Tynamix.ObjectFiller;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Processings
{
    public partial class AIProcessingServiceTests
    {
        private readonly Mock<IAIService> aiServiceMock;
        private readonly IAIProcessingService aiProcessingService;

        public AIProcessingServiceTests()
        {
            this.aiServiceMock = new Mock<IAIService>();

            this.aiProcessingService = new AIProcessingService(
                aiService: this.aiServiceMock.Object);
        }

        public static TheoryData InvalidTableInformationLists()
        {
            return new TheoryData<List<TableInformation>>
            {
                null,
                new List<TableInformation> ()
            };
        }
        public static TheoryData InvalidTableInformations()
        {
            return new TheoryData<TableInformation>
            {
                new TableInformation {
                    Name= null,
                    Columns = null,
                },

                new TableInformation
                {
                    Name= String.Empty,
                    Columns = null,
                },

                new TableInformation
                {
                    Name= " ",
                    Columns = null,
                },

                new TableInformation
                {
                    Name= null,
                    Columns = new List<TableColumn>()
                },

                new TableInformation
                {
                    Name= String.Empty,
                    Columns = new List<TableColumn>()
                },

                new TableInformation
                {
                    Name= " ",
                    Columns = new List<TableColumn>()
                }
            };
        }

        private static List<TableInformation> CreateRandomTableInformations() =>
            CreateTableInformationFiller().Create(count: GetRandomNumber()).ToList();

        private static Dictionary<string, Dictionary<string, string>> GenerateRandomTables()
        {
            int tablesCount = GetRandomNumber();
            var tablesDictionary = new Dictionary<string, Dictionary<string, string>>();

            for (int i = 0; i < tablesCount; i++)
            {
                (string tableName, Dictionary<string, string> tableData) =
                    GenerateRandomTable();

                tablesDictionary.Add(tableName, tableData);
            }

            return tablesDictionary;
        }

        private static Tuple<string, Dictionary<string, string>> GenerateRandomTable()
        {
            string randomTableName = GenerateRandomString();
            int randomColumnCount = GetRandomNumber();
            var columnsDictionary = new Dictionary<string, string>();

            var tableDictionary =
                new Dictionary<string, Dictionary<string, string>>();

            for (int i = 0; i <= randomColumnCount; i++)
            {
                columnsDictionary.Add(
                    key: GenerateRandomString(),
                    value: GenerateRandomString());
            }

            return new(randomTableName, columnsDictionary);
        }

        private static IEnumerable<T> Shuffle<T>(IEnumerable<T> list)
        {
            T[] shuffledTableInformaitons = list.ToArray();
            Random.Shared.Shuffle(shuffledTableInformaitons);

            return shuffledTableInformaitons;
        }

        private static string GenerateRandomString() =>
            new MnemonicString().GetValue();

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static int GetRandomNumber(int minimum, int maximum) =>
          new IntRange(min: minimum, max: maximum).GetValue();

        private static Filler<TableInformation> CreateTableInformationFiller() =>
            new Filler<TableInformation>();
    }
}