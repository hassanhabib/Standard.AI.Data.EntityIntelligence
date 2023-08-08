// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Models.Processings.AIs.Exceptions;

namespace Standard.AI.Data.EntityIntelligence.Services.Processings.AIs
{
    internal partial class AIProcessingService : IAIProcessingService
    {
        private delegate ValueTask<string> ReturningStringFunction();

        private async ValueTask<string> TryCatch(ReturningStringFunction returningStringFunction)
        {
            try
            {
                return await returningStringFunction();
            }
            catch (NullTableInformationListAIProcessingException nullTableInformationListAIProcessingException)
            {
                throw new AIProcessingValidationException(nullTableInformationListAIProcessingException);
            }
            catch (InvalidNaturalQueryAIProcessingException invalidNaturalQueryAIProcessingException)
            {
                throw new AIProcessingValidationException(invalidNaturalQueryAIProcessingException);
            }
        }
    }
}
