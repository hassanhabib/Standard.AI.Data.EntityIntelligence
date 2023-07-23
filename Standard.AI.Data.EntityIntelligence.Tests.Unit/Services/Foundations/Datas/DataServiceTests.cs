using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
                (string schema__tableName, Dictionary<string, string> tableData) =
                    GenerateRandomTable();

                tablesDictionary.Add(schema__tableName, tableData);
            }

            return tablesDictionary;
        }

        private static Tuple<string, Dictionary<string, string>> GenerateRandomTable()
        {
            string randomTableName = GetRandomString();
            string randomSchemaName = GetRandomString();

            int randomColumnCount = GetRandomNumber();
            var columnsDictionary = new Dictionary<string, string>();

            for (int i = 0; i <= randomColumnCount; i++)
            {
                columnsDictionary.Add(
                    key: GetRandomString(),
                    value: GetRandomString());
            }

            return new($"{randomSchemaName}__{randomTableName}", columnsDictionary);
        }
    }
}
