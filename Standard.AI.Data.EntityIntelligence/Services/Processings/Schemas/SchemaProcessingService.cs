// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Schemas;
using Standard.AI.Data.EntityIntelligence.Services.Foundations.Schemas;

namespace Standard.AI.Data.EntityIntelligence.Services.Processings.Schemas
{
    internal class SchemaProcessingService : ISchemaProcessingService
    {
        private readonly ISchemaService schemaService;

        public SchemaProcessingService(ISchemaService schemaService) =>
            this.schemaService = schemaService;

        public async ValueTask<Schema> RetrieveSchemaAsync() =>
            await this.schemaService.RetrieveSchemaAsync();
    }
}
