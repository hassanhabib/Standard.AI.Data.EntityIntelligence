// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Moq;
using Standard.AI.Data.EntityIntelligence.Brokers.Datas;
using Standard.AI.Data.EntityIntelligence.Services.Foundations.Datas;
using Tynamix.ObjectFiller;
using Xunit;

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

        public static TheoryData InvalidMultiStatementQueries() =>
            new TheoryData<string>
                {
                    "SELECT * FROM TableX;SELECT * FROM TableY;",
                    "SelECT * FROM TableX;SELECT * from TableY",
                    "select * FROM tableX;    selECT * FROM TableY;",
                    "SELECT * FROM TableX;    SELECT * FROM TableY",
                    "SELECT * FROM TableX;DROP TABLE TableY",
                };

        public static TheoryData InvalidQueries() =>
            new TheoryData<string>
                {
                    "CREATE TABLE TableX (Column1 INT, Column2 VARCHAR(50));",
                    "INSERT INTO TableX (Column1, Column2) VALUES (Value1, Value2);",
                    "UPDATE TableX SET Column1 = Value1 WHERE Condition;",
                    "DELETE FROM TableX WHERE Condition;",
                    "DROP TABLE TableX;",
                    "ALTER TABLE TableX ADD Column3 INT;",
                    "EXEC dbo.GetTableXData;",
                    "TRUNCATE TABLE TableX;",
                    "DETACH DATABASE alias_name;",
                    "ATTACH DATABASE 'another_database.db' AS alias_name;",
                };

        private static string GetValidQuery() => 
            $"SELECT * FROM [schema].[Table]";

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

        private static IEnumerable<KeyValuePair<int, (string ColumnName, object ColumnValue)>> 
            GenerateColumnDatas()
        {
            int rowsCount = GetRandomNumber();
            int columnsCount = GetRandomNumber();

            for (int rowNumber = 0; rowNumber < rowsCount; rowNumber++)
            {
                for (int columnNumber = 0; columnNumber < columnsCount; columnNumber++)
                {
                    var columnName = GetRandomString();
                    var columnValue = GetRandomString();

                    yield return KeyValuePair.Create(rowNumber, (columnName, columnValue as object));
                }
            }
        }
    }
}
