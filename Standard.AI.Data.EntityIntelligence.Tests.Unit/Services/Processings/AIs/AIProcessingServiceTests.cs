// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.AIs.Exceptions;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Schemas;
using Standard.AI.Data.EntityIntelligence.Services.Foundations.AIs;
using Standard.AI.Data.EntityIntelligence.Services.Processings.AIs;
using Tynamix.ObjectFiller;
using Xeptions;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Processings.AIs
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
            return new TheoryData<List<SchemaTable>>
            {
                null,
                new List<SchemaTable> ()
            };
        }

        public static TheoryData InvalidTableInformationColumns()
        {
            return new TheoryData<SchemaTableColumn>
            {
                null,

                new SchemaTableColumn
                {
                    Name = null,
                    Type = null
                },

                new SchemaTableColumn
                {
                    Name = String.Empty,
                    Type = null
                },

                new SchemaTableColumn
                {
                    Name = " ",
                    Type = null
                },

                new SchemaTableColumn
                {
                    Name = null,
                    Type = String.Empty
                },

                new SchemaTableColumn
                {
                    Name = null,
                    Type = " "
                },

                new SchemaTableColumn
                {
                    Name = String.Empty,
                    Type = String.Empty
                },

            };
        }

        public static TheoryData InvalidTableInformations()
        {
            return new TheoryData<SchemaTable>
            {
                new SchemaTable {
                    Name= null,
                    Columns = null,
                },

                new SchemaTable
                {
                    Name= String.Empty,
                    Columns = null,
                },

                new SchemaTable
                {
                    Name= " ",
                    Columns = null,
                },

                new SchemaTable
                {
                    Name= null,
                    Columns = new List<SchemaTableColumn>()
                },

                new SchemaTable
                {
                    Name= String.Empty,
                    Columns = new List<SchemaTableColumn>()
                },

                new SchemaTable
                {
                    Name= " ",
                    Columns = new List<SchemaTableColumn>()
                }
            };
        }

        public static TheoryData AIDependencyValidationExceptions()
        {
            var innerException = new Xeption();

            return new TheoryData<Xeption>
            {
                new AIValidationException(innerException),
                new AIDependencyValidationException(innerException)
            };
        }

        public static TheoryData AIDependencyExceptions()
        {
            var innerException = new Xeption();

            return new TheoryData<Xeption>
            {
                new AIDependencyException(innerException),
                new AIServiceException(innerException)
            };
        }

        private static List<SchemaTable> CreateRandomTableInformations() =>
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
            string randomTableName = CreateRandomString();
            int randomColumnCount = GetRandomNumber();
            var columnsDictionary = new Dictionary<string, string>();

            var tableDictionary =
                new Dictionary<string, Dictionary<string, string>>();

            for (int i = 0; i <= randomColumnCount; i++)
            {
                columnsDictionary.Add(
                    key: CreateRandomString(),
                    value: CreateRandomString());
            }

            return new(randomTableName, columnsDictionary);
        }

        private static IEnumerable<T> Shuffle<T>(IEnumerable<T> list)
        {
            T[] shuffledTableInformaitons = list.ToArray();
            Random.Shared.Shuffle(shuffledTableInformaitons);

            return shuffledTableInformaitons;
        }

        private static string CreateRandomString() =>
            new MnemonicString().GetValue();

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static int GetRandomNumber(int minimum, int maximum) =>
          new IntRange(min: minimum, max: maximum).GetValue();

        private static Filler<SchemaTable> CreateTableInformationFiller() =>
            new Filler<SchemaTable>();
    }
}
