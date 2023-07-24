// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Moq;
using Standard.AI.Data.EntityIntelligence.Brokers.Datas;
using Standard.AI.Data.EntityIntelligence.Services.Foundations.Datas;
using Tynamix.ObjectFiller;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Foundations.Datas
{
    public partial class DataServiceTests
    {
        private readonly Mock<IDataBroker> dataBrokerMock;
        private readonly IDataService dataService;

        public DataServiceTests()
        {
            this.dataBrokerMock = new Mock<IDataBroker>();

            this.dataService = new DataService(
                dataBroker: this.dataBrokerMock.Object);
        }

        private static string GetRandomString() =>
            new MnemonicString().GetValue();

        private static int GetRandomNumber(int min = 5, int max = 10) =>
            new IntRange(min, max).GetValue();

        private static Dictionary<string, Dictionary<string, string>> GenerateRandomTablesMetadata()
        {
            int tablesCount = GetRandomNumber();
            var tablesDictionary = new Dictionary<string, Dictionary<string, string>>();

            for (int i = 0; i < tablesCount; i++)
            {
                ((string schema, string tableName), Dictionary<string, string> tableData) =
                    GenerateRandomTable();

                tablesDictionary.Add($"{schema}.{tableName}", tableData);
            }

            return tablesDictionary;
        }

        private static Tuple<Tuple<string, string>, Dictionary<string, string>> GenerateRandomTable()
        {
            string randomSchemaName = GetRandomString();
            string randomTableName = GetRandomString();

            int randomColumnCount = GetRandomNumber();
            var columnsDictionary = new Dictionary<string, string>();

            for (int i = 0; i <= randomColumnCount; i++)
            {
                columnsDictionary.Add(
                    key: GetRandomString(),
                    value: GetRandomString());
            }

            return new(new(randomSchemaName, randomTableName), columnsDictionary);
        }
    }
}
