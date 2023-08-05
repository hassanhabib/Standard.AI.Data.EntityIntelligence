// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Models.Datas.Services;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions;

namespace Standard.AI.Data.EntityIntelligence.Services.Foundations.Datas
{
    internal partial class DataService : IDataService
    {
        private delegate ValueTask<IEnumerable<TableMetadata>> ReturningTableMetadatasFunction();
        private delegate ValueTask<IEnumerable<ResultRow>> ReturningResultRawsFunction();

        private static async ValueTask<IEnumerable<TableMetadata>> TryCatch(
            ReturningTableMetadatasFunction returningTableMetadatasFunction)
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

        private static async ValueTask<IEnumerable<ResultRow>> TryCatch(
            ReturningResultRawsFunction returningResultRawsFunction)
        {
            try
            {
                return await returningResultRawsFunction();
            }
            catch (NullOrEmptyDataQueryException nullOrEmptyDataQueryException)
            {
                throw new DataValidationException(nullOrEmptyDataQueryException);
            }
            catch (InvalidDataQueryException invalidDataQueryException)
            {
                throw new DataValidationException(invalidDataQueryException);
            }
        }
    }
}
