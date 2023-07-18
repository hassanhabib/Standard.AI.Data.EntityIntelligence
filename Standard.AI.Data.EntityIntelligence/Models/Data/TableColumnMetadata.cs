// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

namespace Standard.AI.Data.EntityIntelligence.Models.Data
{
    public class TableColumnMetadata
    {
        public string TableSchema { get; }

        public string TableName { get; }

        public string Name { get; }

        public string Type { get; }

        public int? MaxLength { get; }

        public bool IsNullable { get; }

        public bool IsPrimaryKey { get; }

        public short? Ordinal { get; }

        public bool IsForeignKey { get; }

        public string ConstraintName { get; }

        public string ReferencedConstraintName { get; }

        public string ReferecedTableSchemaName { get; }

        public string ReferencedTableName { get; }

        public string ReferencedColumnName { get; }
    }
}