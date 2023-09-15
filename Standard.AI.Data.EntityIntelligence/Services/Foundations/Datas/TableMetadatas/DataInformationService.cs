// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Brokers.Datas;
using Standard.AI.Data.EntityIntelligence.Models.Datas;
using Standard.AI.Data.EntityIntelligence.Models.Datas.Brokers;

namespace Standard.AI.Data.EntityIntelligence.Services.Foundations.Datas.TableMetadatas
{
    internal partial class DataInformationService : IDataInformationService
    {
        private readonly IDataBroker dataBroker;

        public DataInformationService(IDataBroker dataBroker) =>
            this.dataBroker = dataBroker;

        public ValueTask<IEnumerable<TableInformation>> RetrieveTableMetadatasAsync() =>
        TryCatch(async () =>
        {
            IEnumerable<TableColumnMetadata> retrievedTablesColumnsMetadatas =
                await this.dataBroker.ExecuteQueryAsync<TableColumnMetadata>(SelectAllTableMetadatasQuery);

            return ToTablesMetadata(retrievedTablesColumnsMetadatas);
        });

        private static IEnumerable<TableInformation> ToTablesMetadata(
            IEnumerable<TableColumnMetadata> tableColumnsMetadatas)
        {
            IEnumerable<IGrouping<(string TableSchema, string TableName), TableColumnMetadata>> groupedColumns =
                tableColumnsMetadatas
                    .GroupBy(tableColumnMetadata =>
                        (tableColumnMetadata.TableSchema, tableColumnMetadata.TableName));

            return groupedColumns.Select(ToTableMetadata);
        }

        static TableInformation ToTableMetadata(
                IGrouping<(string TableSchema, string Name),
                TableColumnMetadata> tableColumnsMetadatas) =>
                    new TableInformation
                    {
                        Schema = tableColumnsMetadatas.Key.TableSchema,
                        Name = tableColumnsMetadatas.Key.Name,

                        Columns =
                            tableColumnsMetadatas.Select(columnsMetadata =>
                                new TableColumn
                                {
                                    Name = columnsMetadata.Name,
                                    Type = columnsMetadata.DataType,
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
