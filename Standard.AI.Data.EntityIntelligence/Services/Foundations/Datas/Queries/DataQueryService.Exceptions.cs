// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Models.Datas.Services;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Queries.Exceptions;

namespace Standard.AI.Data.EntityIntelligence.Services.Foundations.Datas.Queries
{
    internal partial class DataQueryService : IDataQueryService
    {
        private delegate ValueTask<IEnumerable<ResultRow>> ReturningResultRawsFunction();

        private static async ValueTask<IEnumerable<ResultRow>> TryCatch(
            ReturningResultRawsFunction returningResultRawsFunction)
        {
            try
            {
                return await returningResultRawsFunction();
            }
            catch (NullOrEmptyDataQueryException nullOrEmptyDataQueryException)
            {
                throw new DataQueryServiceValidationException(nullOrEmptyDataQueryException);
            }
            catch (InvalidDataQueryException invalidDataQueryException)
            {
                throw new DataQueryServiceValidationException(invalidDataQueryException);
            }
            catch (ArgumentException argumentException)
            {
                var invalidDataException =
                    new InvalidDataException(argumentException);

                throw new DataQueryServiceDependencyValidationException(invalidDataException);
            }
            catch (InvalidOperationException invalidOperationException)
            {
                var invalidOperationDataException =
                    new InvalidOperationDataException(invalidOperationException);

                throw new DataQueryServiceDependencyValidationException(invalidOperationDataException);
            }
            catch (SqlException sqlException)
            {
                var failedDataDependencyException =
                    new FailedDataQueryDependencyException(sqlException);

                throw new DataQueryServiceDependencyException(failedDataDependencyException);
            }
            catch (Exception exception)
            {
                var failedDataQueryServiceException =
                    new FailedDataQueryServiceException(exception);

                throw new DataQueryServiceException(failedDataQueryServiceException);
            }
        }
    }
}
