// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Schemas;

namespace Standard.AI.Data.EntityIntelligence.Services.Processings.Schemas
{
    internal interface ISchemaProcessingService
    {
        ValueTask<Schema> RetrieveSchemaAsync();
    }
}
