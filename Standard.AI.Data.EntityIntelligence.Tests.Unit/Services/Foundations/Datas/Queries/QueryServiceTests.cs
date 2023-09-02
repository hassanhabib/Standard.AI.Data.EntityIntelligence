// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using Moq;
using Standard.AI.Data.EntityIntelligence.Brokers.Datas;
using Standard.AI.Data.EntityIntelligence.Services.Foundations.Datas.Queries;
using Tynamix.ObjectFiller;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Foundations.Datas.Queries
{
    public partial class QueryServiceTests
    {
        private readonly Mock<IDataBroker> dataBrokerMock;
        private readonly IQueryService queryService;

        public QueryServiceTests()
        {
            this.dataBrokerMock = new Mock<IDataBroker>();

            this.queryService = new QueryService(
                dataBroker: this.dataBrokerMock.Object);
        }

        private static string GetRandomString() =>
            new MnemonicString().GetValue();

        private static int GetRandomNumber() =>
            new IntRange(2, 10).GetValue();

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
