// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Models.Datas;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.TableMetadatas.Exceptions;

namespace Standard.AI.Data.EntityIntelligence.Services.Foundations.Datas.TableMetadatas
{
    internal partial class DataInformationService : IDataInformationService
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

                throw new DataInformationServiceDependencyValidationException(invalidOperationDataException);
            }
            catch (ArgumentException argumentException)
            {
                var invalidDataException =
                    new InvalidDataException(argumentException);

                throw new DataInformationServiceDependencyValidationException(invalidDataException);
            }
            catch (SqlException sqlException)
            {
                var failedDataDependencyException =
                    new FailedDataDependencyException(sqlException);

                throw new DataInformationServiceDependencyException(failedDataDependencyException);
            }
            catch (Exception exception)
            {
                var failedDataInformationServiceException =
                    new FailedDataInformationServiceException(exception);

                throw new DataInformationServiceException(failedDataInformationServiceException);
            }
        }
    }
}
