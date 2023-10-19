// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Schemas;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Schemas.Exceptions;
using Standard.AI.Data.EntityIntelligence.Models.Processings.Schemas.Exceptions;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Services.Processings.Schemas
{
    internal partial class SchemaProcessingService
    {
        private delegate ValueTask<Schema> ReturningSchemaFunction();

        private async ValueTask<Schema> TryCatch(
            ReturningSchemaFunction returningSchemaFunction)
        {
            try
            {
                return await returningSchemaFunction();
            }
            catch (SchemaDependencyValidationException schemaDependencyValidationException)
            {
                throw new SchemaProcessingDependencyValidationException(
                    schemaDependencyValidationException.InnerException as Xeption);
            }
            catch (SchemaDependencyException schemaDependencyException)
            {
                throw new SchemaProcessingDependencyException(
                    schemaDependencyException.InnerException as Xeption);
            }
            catch (SchemaServiceException schemaServiceException)
            {
                throw new SchemaProcessingDependencyException(
                    schemaServiceException.InnerException as Xeption);
            }
        }
    }
}
