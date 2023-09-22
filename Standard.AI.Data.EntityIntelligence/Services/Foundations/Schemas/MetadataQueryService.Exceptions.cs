// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.TableMetadatas;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.TableMetadatas.Exceptions;

namespace Standard.AI.Data.EntityIntelligence.Services.Foundations.MetadataQueries
{
    internal partial class MetadataQueryService : ISchemaService
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

                throw new MetadataQueryServiceDependencyValidationException(invalidOperationDataException);
            }
            catch (ArgumentException argumentException)
            {
                var invalidDataException =
                    new InvalidDataException(argumentException);

                throw new MetadataQueryServiceDependencyValidationException(invalidDataException);
            }
            catch (SqlException sqlException)
            {
                var failedDataDependencyException =
                    new FailedDataDependencyException(sqlException);

                throw new MetadataQueryServiceDependencyException(failedDataDependencyException);
            }
            catch (Exception exception)
            {
                var failedDataInformationServiceException =
                    new FailedMetadataQueryServiceException(exception);

                throw new MetadataQueryServiceException(failedDataInformationServiceException);
            }
        }
    }
}
