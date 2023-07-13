// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.AIs.Exceptions;
using Standard.AI.OpenAI.Models.Clients.Completions.Exceptions;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Services.Foundations.AIs
{
    internal partial class AIService : IAIService
    {
        private delegate ValueTask<string> ReturningStringFunction();

        private static async ValueTask<string> TryCatch(ReturningStringFunction returningStringFunction)
        {
            try
            {
                return await returningStringFunction();
            }
            catch (InvalidAIQueryException invalidAIQueryException)
            {
                throw new AIValidationException(invalidAIQueryException);
            }
            catch (CompletionClientValidationException completionClientValidationException)
            {
                var invalidAIQueryException = 
                    new InvalidAIQueryException(
                        completionClientValidationException.InnerException as Xeption);

                throw new AIDependencyValidationException(invalidAIQueryException);
            }
            catch (CompletionClientDependencyException completionClientDependencyException)
            {
                var failedAIDependencyException =
                    new FailedAIDependencyException(
                        completionClientDependencyException.InnerException as Xeption);

                throw new AIDependencyException(failedAIDependencyException);
            }
            catch (CompletionClientServiceException completionClientServiceException)
            {
                var failedAIDependencyException =
                    new FailedAIDependencyException(
                        completionClientServiceException.InnerException as Xeption);

                throw new AIDependencyException(failedAIDependencyException);
            }
            catch (Exception exception)
            {
                var failedAIServiceException =
                    new FailedAIServiceException(exception);

                throw new AIServiceException(failedAIServiceException);
            }
        }
    }
}
