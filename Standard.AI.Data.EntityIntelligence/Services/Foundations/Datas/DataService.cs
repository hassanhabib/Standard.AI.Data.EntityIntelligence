// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Brokers.Datas;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas;

namespace Standard.AI.Data.EntityIntelligence.Services.Foundations.Datas
{
    internal partial class DataService : IDataService
    {
        private readonly IDataBroker dataBroker;

        public DataService(IDataBroker dataBroker) =>
            this.dataBroker = dataBroker;

        public ValueTask<IEnumerable<ResultRow>> RetrieveDataAsync(string query) =>
        TryCatch(async () =>
        {
            ValidateQuery(query);

            IEnumerable<IDictionary<string, object>> retrievedRows =
                await this.dataBroker.ExecuteQueryAsync<IDictionary<string, object>>(query);

            return ToResultRows(retrievedRows);
        });

        private static IEnumerable<ResultRow> ToResultRows(
            IEnumerable<IDictionary<string, object>> retrievedRows) =>
                retrievedRows.Select(row =>
                    new ResultRow
                    {
                        Columns = row.Select(column => new ColumnData
                        {
                            Name = column.Key,
                            Value = column.Value,
                        })
                    });
    }
}
