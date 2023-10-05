// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions;
using Standard.AI.Data.EntityIntelligence.Models.Processings.Datas.Exceptions;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Services.Processings.Datas
{
    internal partial class DataProcessingService : IDataProcessingService
    {
        private delegate ValueTask<DataResult> ReturningDataFunction();

        private async ValueTask<DataResult> TryCatch(ReturningDataFunction returningDataFunction)
        {
            try
            {
                return await returningDataFunction();
            }
            catch (InvalidQueryDataProcessingException invalidQueryDataProcessingException)
            {
                throw new DataProcessingValidationException(invalidQueryDataProcessingException);
            }
            catch (DataServiceValidationException dataValidationException)
            {
                throw new DataProcessingDependencyValidationException(
                    dataValidationException.InnerException as Xeption);
            }
            catch (DataServiceDependencyValidationException dataDependencyValidationException)
            {
                throw new DataProcessingDependencyValidationException(
                    dataDependencyValidationException.InnerException as Xeption);
            }
            catch (DataServiceDependencyException dataDependencyException)
            {
                throw new DataProcessingDependencyException(
                    dataDependencyException.InnerException as Xeption);
            }
            catch (DataServiceException dataServiceException)
            {
                throw new DataProcessingDependencyException(
                    dataServiceException.InnerException as Xeption);
            }
            catch (Exception exception)
            {
                var failedDataProcessingException =
                    new FailedDataProcessingServiceException(exception);

                throw new DataProcessingServiceException(failedDataProcessingException);
            }
        }
    }
}
