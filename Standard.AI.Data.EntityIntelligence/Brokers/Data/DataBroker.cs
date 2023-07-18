// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Standard.AI.Data.EntityIntelligence.Models.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

using System.Data.SqlClient;
using Dapper;

namespace Standard.AI.Data.EntityIntelligence.Brokers.DataStorages
{
    public class DataBroker
    {
        private readonly DataStorageConfiguration configuration;

        public DataBroker(DataStorageConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IEnumerable<TableColumnMetadata>> SelectSqlTablesMetadataAsync()
        {
            const string query = 
                $@"SELECT 
	                    c.TABLE_SCHEMA AS [{nameof(TableColumnMetadata.TableSchema)}],
	                    c.TABLE_NAME AS [{nameof(TableColumnMetadata.TableName)}],
	                    c.COLUMN_NAME AS [{nameof(TableColumnMetadata.Name)}],
                        c.DATA_TYPE AS [{nameof(TableColumnMetadata.Type)}],
	                    C.CHARACTER_MAXIMUM_LENGTH AS [{nameof(TableColumnMetadata.MaxLength)}],
	                    CASE WHEN c.IS_NULLABLE = 'NO' THEN 0 ELSE 1 END AS [{nameof(TableColumnMetadata.IsNullable)}],
	                    CASE WHEN tc.CONSTRAINT_TYPE = 'PRIMARY KEY' THEN 1 ELSE 0 END AS [{nameof(TableColumnMetadata.IsPrimaryKey)}],
	                    ccu.ORDINAL_POSITION AS [{nameof(TableColumnMetadata.Ordinal)}],
	                    CASE WHEN tc.CONSTRAINT_TYPE = 'FOREIGN KEY' THEN 1 ELSE 0 END AS [{nameof(TableColumnMetadata.IsForeignKey)}],
	                    ccu.CONSTRAINT_NAME AS [{nameof(TableColumnMetadata.ConstraintName)}],
	                    ccu2.CONSTRAINT_NAME AS [{nameof(TableColumnMetadata.ReferencedConstraintName)}],
	                    ccu2.TABLE_SCHEMA AS [{nameof(TableColumnMetadata.ReferecedTableSchemaName)}],
	                    ccu2.TABLE_NAME AS [{nameof(TableColumnMetadata.ReferencedTableName)}],
	                    ccu2.COLUMN_NAME AS [{nameof(TableColumnMetadata.ReferencedColumnName)}]
                    FROM INFORMATION_SCHEMA.COLUMNS c
                    LEFT JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE ccu 
	                    ON ccu.TABLE_SCHEMA = c.TABLE_SCHEMA AND ccu.TABLE_NAME = c.TABLE_NAME AND ccu.COLUMN_NAME = c.COLUMN_NAME -- all the constraints
                    LEFT JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc 
	                    ON ccu.CONSTRAINT_NAME = tc.CONSTRAINT_NAME -- constraint types (PK, FK)
                    LEFT JOIN INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS rc 
	                    ON rc.CONSTRAINT_NAME = ccu.CONSTRAINT_NAME -- only fk constraints
                    LEFT JOIN INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE ccu2 
	                    ON ccu2.CONSTRAINT_NAME = rc.UNIQUE_CONSTRAINT_NAME -- referencing column constraint";

            using var connection = new SqlConnection(configuration.ConnectionString);

            return await connection.QueryAsync<TableColumnMetadata>(query);
        }
    }
}
