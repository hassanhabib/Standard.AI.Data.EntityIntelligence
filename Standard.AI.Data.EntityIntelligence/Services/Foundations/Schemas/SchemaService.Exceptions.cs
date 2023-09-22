// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Schemas;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Schemas.Exceptions;

namespace Standard.AI.Data.EntityIntelligence.Services.Foundations.Schemas
{
    internal partial class SchemaService : ISchemaService
    {
        private delegate ValueTask<IEnumerable<TableInformation>> ReturningTableInformationFunction();

        private static async ValueTask<IEnumerable<TableInformation>> TryCatch(
            ReturningTableInformationFunction returningTableInformationFunction)
        {
            try
            {
                return await returningTableInformationFunction();
            }
            catch (InvalidOperationException invalidOperationException)
            {
                var invalidOperationDataException =
                    new InvalidOperationDataException(invalidOperationException);

                throw new SchemaServiceDependencyValidationException(invalidOperationDataException);
            }
            catch (ArgumentException argumentException)
            {
                var invalidDataException =
                    new InvalidDataException(argumentException);

                throw new SchemaServiceDependencyValidationException(invalidDataException);
            }
            catch (SqlException sqlException)
            {
                var failedDataDependencyException =
                    new FailedDataDependencyException(sqlException);

                throw new SchemaServiceDependencyException(failedDataDependencyException);
            }
            catch (Exception exception)
            {
                var failedDataInformationServiceException =
                    new FailedSchemaServiceException(exception);

                throw new SchemaServiceException(failedDataInformationServiceException);
            }
        }
    }
}
