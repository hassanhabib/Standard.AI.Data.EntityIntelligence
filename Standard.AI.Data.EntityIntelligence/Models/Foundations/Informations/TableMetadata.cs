// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Informations
{
    internal class TableMetadata
    {
        public string Schema { get; init; }
        public string Name { get; init; }
        public IEnumerable<ColumnMetadata> ColumnsMetadata { get; init; }
    }
}
