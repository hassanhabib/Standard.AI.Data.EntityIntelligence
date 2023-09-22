// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Schemas;

namespace Standard.AI.Data.EntityIntelligence.Services.Foundations.Schemas
{
    internal interface ISchemaService
    {
        ValueTask<IEnumerable<SchemaTable>> RetrieveSchemaAsync();
    }
}
