// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Brokers.Datas;
using Standard.AI.Data.EntityIntelligence.Models.Datas.Brokers;
using Standard.AI.Data.EntityIntelligence.Models.Datas.Services;

namespace Standard.AI.Data.EntityIntelligence.Services.Foundations.Datas
{
    internal partial class DataService : IDataService
    {
        private readonly IDataBroker dataBroker;

        public DataService(IDataBroker dataBroker) =>
            this.dataBroker = dataBroker;

        public ValueTask<IEnumerable<TableMetadata>> RetrieveTableMetadatasAsync() =>
        TryCatch(async () =>
        {
            IEnumerable<TableColumnMetadata> retrievedTablesColumnsMetadatas =
              await this.dataBroker.ExecuteQueryAsync<TableColumnMetadata>(SelectAllTableMetadatasQuery);

            return ToTablesMetadata(retrievedTablesColumnsMetadatas);
        });

        private static IEnumerable<TableMetadata> ToTablesMetadata(
            IEnumerable<TableColumnMetadata> tableColumnsMetadatas)
        {
            IEnumerable<IGrouping<(string TableSchema, string TableName), TableColumnMetadata>> groupedColumns =
                tableColumnsMetadatas
                    .GroupBy(tableColumnMetadata =>
                        (tableColumnMetadata.TableSchema, tableColumnMetadata.TableName));

            return groupedColumns.Select(ToTableMetadata);
        }

        static TableMetadata ToTableMetadata(
                IGrouping<(string TableSchema, string Name),
                TableColumnMetadata> tableColumnsMetadatas) =>
                    new TableMetadata
                    {
                        Schema = tableColumnsMetadatas.Key.TableSchema,
                        Name = tableColumnsMetadatas.Key.Name,

                        ColumnsMetadata =
                            tableColumnsMetadatas.Select(columnsMetadata =>
                                new ColumnMetadata
                                {
                                    Name = columnsMetadata.Name,
                                    DataType = columnsMetadata.DataType,
                                }),
                    };

        private static readonly string SelectAllTableMetadatasQuery =
            String.Join(
                separator: Environment.NewLine,
                "SELECT",
                $"columnMetadata.TABLE_SCHEMA AS [{nameof(TableColumnMetadata.TableSchema)}],",
                $"columnMetadata.TABLE_NAME AS [{nameof(TableColumnMetadata.TableName)}],",
                $"columnMetadata.COLUMN_NAME AS [{nameof(TableColumnMetadata.Name)}],",
                $"columnMetadata.DATA_TYPE AS [{nameof(TableColumnMetadata.DataType)}]",
                "FROM INFORMATION_SCHEMA.COLUMNS columnMetadata");
    }
}
