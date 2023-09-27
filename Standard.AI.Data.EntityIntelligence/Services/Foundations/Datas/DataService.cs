// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Brokers.Datas;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas;
using DataResult = Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Data;

namespace Standard.AI.Data.EntityIntelligence.Services.Foundations.Datas
{
    internal partial class DataService : IDataService
    {
        private readonly IDataBroker dataBroker;

        public DataService(IDataBroker dataBroker) =>
            this.dataBroker = dataBroker;

        public ValueTask<DataResult> RetrieveDataAsync(string query) =>
        TryCatch(async () =>
        {
            ValidateQuery(query);

            IEnumerable<IDictionary<string, object>> retrievedRows =
                await this.dataBroker.ExecuteQueryAsync<IDictionary<string, object>>(query);

            return ToDataResult(retrievedRows);
        });

        private static DataResult ToDataResult(
            IEnumerable<IDictionary<string, object>> retrievedRows)
        {
            return new DataResult
            {
                ColumnGroups = retrievedRows.Select(row =>
                 new ColumnGroupData
                 {
                     Columns = row.Select(column => new ColumnData
                     {
                         Name = column.Key,
                         Value = column.Value,
                     })
                 })
            };
        }
    }
}
