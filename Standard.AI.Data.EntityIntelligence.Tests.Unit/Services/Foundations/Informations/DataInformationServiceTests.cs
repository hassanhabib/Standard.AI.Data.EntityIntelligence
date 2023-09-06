// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Moq;
using Standard.AI.Data.EntityIntelligence.Brokers.Datas;
using Standard.AI.Data.EntityIntelligence.Services.Foundations.Informations;
using Tynamix.ObjectFiller;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Foundations.Informations
{
    public partial class DataInformationServiceTests
    {
        private readonly Mock<IDataBroker> dataBrokerMock;
        private readonly IDataInformationService dataService;

        public DataInformationServiceTests()
        {
            this.dataBrokerMock = new Mock<IDataBroker>();

            this.dataService = new DataInformationService(
                dataBroker: this.dataBrokerMock.Object);
        }

        private static SqlException GetSqlException() =>
            (SqlException)System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(SqlException));

        private static string GetRandomString() =>
            new MnemonicString().GetValue();

        private static int GetRandomNumber() =>
            new IntRange(2, 10).GetValue();

        private static Dictionary<string, Dictionary<string, string>> GenerateRandomTableMetadatas()
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

            return Tuple.Create(
                    Tuple.Create(randomSchemaName, randomTableName),
                    columnsDictionary);
        }
    }
}
