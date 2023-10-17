// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Schemas;
using Standard.AI.Data.EntityIntelligence.Services.Foundations.Schemas;
using Standard.AI.Data.EntityIntelligence.Services.Processings.Schemas;
using Tynamix.ObjectFiller;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Processings.Schemas
{
    public partial class SchemaProcessingServiceTests
    {
        private readonly Mock<ISchemaService> schemaServiceMock;
        private readonly ISchemaProcessingService schemaProcessingService;

        public SchemaProcessingServiceTests()
        {
            this.schemaServiceMock = new Mock<ISchemaService>();

            this.schemaProcessingService = new SchemaProcessingService(
                schemaService: this.schemaServiceMock.Object);
        }

        private static Schema CreateRandomSchema() =>
            CreateSchemaFiller().Create();

        private static Filler<Schema> CreateSchemaFiller() =>
            new Filler<Schema>();
    }
}
