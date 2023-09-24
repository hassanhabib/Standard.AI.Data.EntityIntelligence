// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Brokers.Datas;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Schemas;

namespace Standard.AI.Data.EntityIntelligence.Services.Foundations.Schemas
{
    internal partial class SchemaService : ISchemaService
    {
        private readonly IDataBroker dataBroker;

        public SchemaService(IDataBroker dataBroker) =>
               this.dataBroker = dataBroker;

        public ValueTask<Schema> RetrieveSchemaAsync() =>
        TryCatch(async () =>
        {
            IEnumerable<TableColumnMetadata> retrievedTablesColumnsMetadatas =
                await this.dataBroker.ExecuteQueryAsync<TableColumnMetadata>(SelectAllTableInformationsQuery);

            return ToSchema(retrievedTablesColumnsMetadatas);
        });

        private static Schema ToSchema(
            IEnumerable<TableColumnMetadata> tableColumnsMetadatas)
        {
            IEnumerable<IGrouping<(string TableSchema, string TableName), TableColumnMetadata>> groupedColumns =
                tableColumnsMetadatas
                    .GroupBy(tableColumnMetadata =>
                        (tableColumnMetadata.TableSchema, tableColumnMetadata.TableName));

            Schema schema = new Schema();
            schema.SchemaTables = groupedColumns.Select(ToSchemaTable);
            return schema;
        }

        static SchemaTable ToSchemaTable(
                IGrouping<(string TableSchema, string Name),
                TableColumnMetadata> tableColumnsMetadatas) =>
                    new SchemaTable
                    {
                        Schema = tableColumnsMetadatas.Key.TableSchema,
                        Name = tableColumnsMetadatas.Key.Name,

                        Columns =
                            tableColumnsMetadatas.Select(columnsMetadata =>
                                new SchemaTableColumn
                                {
                                    Name = columnsMetadata.Name,
                                    Type = columnsMetadata.DataType,
                                }),
                    };

        private static readonly string SelectAllTableInformationsQuery =
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
