// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Queries;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Queries.Exceptions;

namespace Standard.AI.Data.EntityIntelligence.Services.Foundations.Queries
{
    internal partial class QueryService
    {
        private delegate ValueTask<IEnumerable<ResultRow>> ReturningResultRawsFunction();

        private static async ValueTask<IEnumerable<ResultRow>> TryCatch(
            ReturningResultRawsFunction returningResultRawsFunction)
        {
            try
            {
                return await returningResultRawsFunction();
            }
            catch (InvalidQueryException invalidQueryException)
            {
                throw new QueryValidationException(invalidQueryException);
            }
            catch (InvalidOperationException invalidOperationException)
            {
                var invalidQueryException =
                    new InvalidQueryException(invalidOperationException);

                throw new QueryServiceDependencyValidationException(invalidQueryException);
            }
            catch (ArgumentException argumentException)
            {
                var invalidQueryException =
                    new InvalidQueryException(argumentException);

                throw new QueryServiceDependencyValidationException(invalidQueryException);
            }
            catch (SqlException sqlException)
            {
                var invalidQueryException =
                    new FailedQueryStorageException(sqlException);

                throw new QueryServiceDependencyException(invalidQueryException);
            }
            catch (Exception exception)
            {
                var failedQueryServiceException =
                    new FailedQueryServiceException(exception);

                throw new QueryServiceException(failedQueryServiceException);
            }
        }
    }
}
