// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
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

        public static TheoryData<Tuple<dynamic, string>> InvalidTableInformationsAndInvalidNaturalQueries()
        {
            var randomTablesData = GenerateRandomTables();

            List<TableInformation> tableInfoWithEmptyTableNames =
                randomTablesData.Keys.Select(key =>
                {
                    return new TableInformation
                    {
                        Name = "",
                        Columns = randomTablesData[key].Keys.Select(tableColumnKey =>
                        {
                            return new TableColumn
                            {
                                Name = tableColumnKey,
                                Type = randomTablesData[key][tableColumnKey]
                            };
                        }).ToList()
                    };
                }).ToList();

            List<TableInformation> tableInfoWithNullTableNames =
               randomTablesData.Keys.Select(key =>
               {
                   return new TableInformation
                   {
                       Name = null,
                       Columns = randomTablesData[key].Keys.Select(tableColumnKey =>
                       {
                           return new TableColumn
                           {
                               Name = tableColumnKey,
                               Type = randomTablesData[key][tableColumnKey]
                           };
                       }).ToList()
                   };
               }).ToList();

            List<TableInformation> tableInfoWithNullColumns =
                randomTablesData.Keys.Select(key =>
               {
                   return new TableInformation
                   {
                       Name = key,
                       Columns = null
                   };
               }).ToList();

            List<TableInformation> tableInfoWithEmptyColumnsNames =
                randomTablesData.Keys.Select(key =>
                  {
                      return new TableInformation
                      {
                          Name = key,
                          Columns = randomTablesData[key].Keys.Select(tableColumnKey =>
                          {
                              return new TableColumn
                              {
                                  Name = "",
                                  Type = randomTablesData[key][tableColumnKey]
                              };
                          }).ToList()
                      };
                  }).ToList();

            List<TableInformation> tableInfoWithNullColumnsNames =
              randomTablesData.Keys.Select(key =>
              {
                  return new TableInformation
                  {
                      Name = key,
                      Columns = randomTablesData[key].Keys.Select(tableColumnKey =>
                      {
                          return new TableColumn
                          {
                              Name = null,
                              Type = randomTablesData[key][tableColumnKey]
                          };
                      }).ToList()
                  };
              }).ToList();

            List<TableInformation> tableInfoWithEmptyColumnsTypes =
                randomTablesData.Keys.Select(key =>
               {
                   return new TableInformation
                   {
                       Name = key,
                       Columns = randomTablesData[key].Keys.Select(tableColumnKey =>
                       {
                           return new TableColumn
                           {
                               Name = tableColumnKey,
                               Type = ""
                           };
                       }).ToList()
                   };
               }).ToList();

            List<TableInformation> tableInfoWithNullColumnsTypes =
                randomTablesData.Keys.Select(key =>
                {
                    return new TableInformation
                    {
                        Name = key,
                        Columns = randomTablesData[key].Keys.Select(tableColumnKey =>
                        {
                            return new TableColumn
                            {
                                Name = tableColumnKey,
                                Type = null
                            };
                        }).ToList()
                    };
                }).ToList();

            return new TheoryData<Tuple<dynamic, string>>
            {
                new (null,null),
                new (null,""),
                new (tableInfoWithEmptyTableNames, GenerateRandomString()),
                new (tableInfoWithNullTableNames,GenerateRandomString()),
                new (tableInfoWithNullColumns,GenerateRandomString()),
                new (tableInfoWithEmptyColumnsNames,GenerateRandomString()),
                new (tableInfoWithNullColumnsNames,GenerateRandomString()),
                new (tableInfoWithEmptyColumnsTypes,GenerateRandomString()),
                new (tableInfoWithNullColumnsTypes,GenerateRandomString())
            };
        }

        private static string GenerateRandomString() =>
            new MnemonicString().GetValue();

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();
    }
}
