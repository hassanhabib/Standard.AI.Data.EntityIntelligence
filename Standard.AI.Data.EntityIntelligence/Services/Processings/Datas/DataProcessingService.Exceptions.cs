// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

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
            catch (DataServiceValidationException dataServiceValidationException)
            {
                throw new DataProcessingDependencyValidationException(
                    dataServiceValidationException.InnerException as Xeption);
            }
            catch (DataServiceDependencyValidationException dataServiceDependencyValidationException)
            {
                throw new DataProcessingDependencyValidationException(
                    dataServiceDependencyValidationException.InnerException as Xeption);
            }
        }
    }
}
