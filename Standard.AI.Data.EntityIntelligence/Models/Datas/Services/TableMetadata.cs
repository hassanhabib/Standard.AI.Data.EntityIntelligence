// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;

namespace Standard.AI.Data.EntityIntelligence.Models.Datas.Services
{
    public class TableMetadata
    {
        public string Schema { get; init; }
        public string Name { get; init; }
        public IEnumerable<ColumnMetadata> ColumnsMetadata { get; init; }
    }
}
