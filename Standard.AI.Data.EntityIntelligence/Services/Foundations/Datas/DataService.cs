using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Brokers.Datas;
using Standard.AI.Data.EntityIntelligence.Models.Datas.Brokers;
using Standard.AI.Data.EntityIntelligence.Models.Datas.Services;

namespace Standard.AI.Data.EntityIntelligence.Services.Foundations.Datas
{
    internal class DataService : IDataService
    {
        private readonly IDataBroker dataBroker;

        public DataService(IDataBroker dataBroker) => 
            this.dataBroker = dataBroker;

        public async ValueTask<List<TableMetadata>> RetrieveTablesDetailsAsync()
        {
            var query = GetSelectAllTablesMetadataQuery();

            var retrievedTablesColumnsMetadata =
                await this.dataBroker.ExecuteQueryAsync<TableColumnMetadata>(query);

            return ToTablesMetadata(retrievedTablesColumnsMetadata);
        }

        private static List<TableMetadata> ToTablesMetadata(IEnumerable<TableColumnMetadata> retrievedTablesColumnsMetadata)
        {
            var groupedColumns =
                retrievedTablesColumnsMetadata
                    .GroupBy(tableColumnMetadata =>
                        (tableColumnMetadata.TableSchema, tableColumnMetadata.Name));

            return groupedColumns.Select(ToTableMetadata).ToList();

            static TableMetadata ToTableMetadata(
                IGrouping<(string TableSchema, string Name),
                TableColumnMetadata> tableColumnsMetadata) =>
                new()
                {
                    Schema = tableColumnsMetadata.Key.TableSchema,
                    Name = tableColumnsMetadata.Key.Name,
                    ColumnsMetadata =
                        tableColumnsMetadata.Select(columnsMetadata =>
                            new ColumnMetadata
                            {
                                Name = columnsMetadata.Name,
                                DataType = columnsMetadata.Type,
                            }).ToList(),
                };
        }

        private static string GetSelectAllTablesMetadataQuery() => 
            $@"SELECT 
	           c.TABLE_SCHEMA AS [{nameof(TableColumnMetadata.TableSchema)}],
	           c.TABLE_NAME AS [{nameof(TableColumnMetadata.TableName)}],
	           c.COLUMN_NAME AS [{nameof(TableColumnMetadata.Name)}],
               c.DATA_TYPE AS [{nameof(TableColumnMetadata.Type)}]
               FROM INFORMATION_SCHEMA.COLUMNS c";
    }
}
