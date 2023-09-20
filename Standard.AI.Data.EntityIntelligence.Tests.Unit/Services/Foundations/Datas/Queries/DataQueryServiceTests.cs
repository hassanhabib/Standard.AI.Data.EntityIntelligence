// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Moq;
using Standard.AI.Data.EntityIntelligence.Brokers.Datas;
using Standard.AI.Data.EntityIntelligence.Services.Foundations.Datas.Queries;
using Tynamix.ObjectFiller;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Foundations.Datas.Queries
{
    public partial class DataQueryServiceTests
    {
        private readonly Mock<IDataBroker> dataBrokerMock;
        private readonly IDataQueryService dataQueryService;

        public DataQueryServiceTests()
        {
            this.dataBrokerMock = new Mock<IDataBroker>();

            this.dataQueryService = new DataQueryService(
                dataBroker: this.dataBrokerMock.Object);
        }

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
