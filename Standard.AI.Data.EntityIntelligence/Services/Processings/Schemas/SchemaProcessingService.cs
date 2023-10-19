// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Schemas;
using Standard.AI.Data.EntityIntelligence.Services.Foundations.Schemas;

namespace Standard.AI.Data.EntityIntelligence.Services.Processings.Schemas
{
    internal partial class SchemaProcessingService : ISchemaProcessingService
    {
        private readonly ISchemaService schemaService;

        public SchemaProcessingService(ISchemaService schemaService) =>
            this.schemaService = schemaService;

        public ValueTask<Schema> RetrieveSchemaAsync() => TryCatch(async () =>
            await this.schemaService.RetrieveSchemaAsync());
    }
}
