// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

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
                throw new AIDependencyValidationException(
                    completionClientValidationException.InnerException as Xeption);
            }
        }
    }
}
