// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions;
using DataResult = Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Data;

namespace Standard.AI.Data.EntityIntelligence.Services.Foundations.Datas
{
    internal partial class DataService
    {
        private delegate ValueTask<DataResult> ReturningDataResultFunction();

        private static async ValueTask<DataResult> TryCatch(
            ReturningDataResultFunction returningResultRawsFunction)
        {
            try
            {
                return await returningResultRawsFunction();
            }
            catch (NullOrEmptyDataQueryException nullOrEmptyDataQueryException)
            {
                throw new DataServiceValidationException(nullOrEmptyDataQueryException);
            }
            catch (InvalidDataQueryException invalidDataQueryException)
            {
                throw new DataServiceValidationException(invalidDataQueryException);
            }
            catch (ArgumentException argumentException)
            {
                var invalidDataException =
                    new InvalidDataException(argumentException);

                throw new DataServiceDependencyValidationException(invalidDataException);
            }
            catch (InvalidOperationException invalidOperationException)
            {
                var invalidOperationDataException =
                    new InvalidOperationDataException(invalidOperationException);

                throw new DataServiceDependencyValidationException(invalidOperationDataException);
            }
            catch (SqlException sqlException)
            {
                var failedDataDependencyException =
                    new FailedDataDependencyException(sqlException);

                throw new DataServiceDependencyException(failedDataDependencyException);
            }
            catch (Exception exception)
            {
                var failedDataQueryServiceException =
                    new FailedDataServiceException(exception);

                throw new DataServiceException(failedDataQueryServiceException);
            }
        }
    }
}
