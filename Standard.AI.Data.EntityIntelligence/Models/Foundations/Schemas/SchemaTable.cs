// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Schemas
{
    internal class SchemaTable
    {
        public string Name { get; set; }
        public string Schema { get; set; }
        public IEnumerable<SchemaTableColumn> Columns { get; set; }
    }
}
