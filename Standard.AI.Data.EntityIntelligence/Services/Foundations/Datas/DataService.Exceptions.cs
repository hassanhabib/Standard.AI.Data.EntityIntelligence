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
                var invalidOperationDataValidationException =
                    new InvalidOperationDataValidationException(invalidOperationException);

                throw new DataDependencyValidationException(invalidOperationDataValidationException);
            }
            catch (ArgumentException argumentException)
            {
                var invalidDataValidationException =
                    new InvalidDataValidationException(argumentException);

                throw new DataDependencyValidationException(invalidDataValidationException);
            }
            catch (SqlException sqlException)
            {
                var failedDataDependencyException =
                    new FailedDataDependencyValidationException(sqlException);

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
