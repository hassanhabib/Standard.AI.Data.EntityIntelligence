// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.AIs.Exceptions;
using Standard.AI.Data.EntityIntelligence.Models.Processings.AIs.Exceptions;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Services.Processings.AIs
{
    internal partial class AIProcessingService
    {
        private delegate ValueTask<string> ReturningStringFunction();

        private async ValueTask<string> TryCatch(ReturningStringFunction returningStringFunction)
        {
            try
            {
                return await returningStringFunction();
            }
            catch (InvalidTableInformationListAIProcessingException invalidTableInformationListAIProcessingException)
            {
                throw new AIProcessingValidationException(invalidTableInformationListAIProcessingException);
            }
            catch (InvalidTableInformationAIProcessingException invalidTableInformationAIProcessingException)
            {
                throw new AIProcessingValidationException(invalidTableInformationAIProcessingException);
            }
            catch (InvalidTableInformationColumnAIProcessingException invalidTableInformationColumnAIProcessingException)
            {
                throw new AIProcessingValidationException(invalidTableInformationColumnAIProcessingException);
            }
            catch (InvalidNaturalQueryAIProcessingException invalidNaturalQueryAIProcessingException)
            {
                throw new AIProcessingValidationException(invalidNaturalQueryAIProcessingException);
            }
            catch (AIValidationException aiValidationException)
            {
                throw new AIProcessingDependencyValidationException(
                    aiValidationException.InnerException as Xeption);
            }
            catch (AIDependencyValidationException aiDependencyValidationException)
            {
                throw new AIProcessingDependencyValidationException(
                    aiDependencyValidationException.InnerException as Xeption);
            }
            catch (AIDependencyException aiDependencyException)
            {
                throw new AIProcessingDependencyException(
                    aiDependencyException.InnerException as Xeption);
            }
            catch (AIServiceException aiServiceException)
            {
                throw new AIProcessingDependencyException(
                    aiServiceException.InnerException as Xeption);
            }
            catch (Exception exception)
            {
                var failedAIProcessingServiceException =
                    new FailedAIProcessingServiceException(exception);

                throw new AIProcessingServiceException(failedAIProcessingServiceException);
            }
        }
    }
}
