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
        private delegate ValueTask<List<TableMetadata>> ReturningFunction();

        private static async ValueTask<List<TableMetadata>> TryCatch(ReturningFunction returningFuction)
        {
            try
            {
                return await returningFuction();
            }
            catch (InvalidOperationException invalidOperationException)
            {
                var failedDependencyValidationException =
                    new FailedDataStorageDependencyValidationException(invalidOperationException);

                throw new DataStorageDependencyValidationException(failedDependencyValidationException);
            }
            catch (ArgumentException argumentException)
            {
                var failedDependencyValidationException =
                    new FailedDataStorageDependencyValidationException(argumentException);

                throw new DataStorageDependencyValidationException(failedDependencyValidationException);
            }
            catch (SqlException sqlException)
            {
                var failedDataStorageDependencyException =
                    new FailedDataStorageDependencyValidationException(sqlException);

                throw new DataStorageDependencyException(failedDataStorageDependencyException);
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
