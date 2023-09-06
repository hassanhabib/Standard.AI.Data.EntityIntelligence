// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Informations;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Informations.Exceptions;

namespace Standard.AI.Data.EntityIntelligence.Services.Foundations.Informations
{
    internal partial class DataInformationService : IDataInformationService
    {
        private delegate ValueTask<IEnumerable<TableMetadata>> ReturningTableMetadatasFunction();

        private static async ValueTask<IEnumerable<TableMetadata>> TryCatch(ReturningTableMetadatasFunction returningTableMetadatasFunction)
        {
            try
            {
                return await returningTableMetadatasFunction();
            }
            catch (InvalidOperationException invalidOperationException)
            {
                var invalidOperationDataException =
                    new InvalidOperationDataException(invalidOperationException);

                throw new DataDependencyValidationException(invalidOperationDataException);
            }
            catch (ArgumentException argumentException)
            {
                var invalidDataException =
                    new InvalidDataException(argumentException);

                throw new DataDependencyValidationException(invalidDataException);
            }
            catch (SqlException sqlException)
            {
                var failedDataDependencyException =
                    new FailedDataDependencyException(sqlException);

                throw new DataDependencyException(failedDataDependencyException);
            }
            catch (Exception exception)
            {
                var failedDataServiceException =
                    new FailedDataServiceException(exception);

                throw new DataServiceException(failedDataServiceException);
            }
        }
    }
}
