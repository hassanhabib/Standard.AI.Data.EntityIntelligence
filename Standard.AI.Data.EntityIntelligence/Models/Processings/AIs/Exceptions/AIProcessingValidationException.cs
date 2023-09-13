// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;
namespace Standard.AI.Data.EntityIntelligence.Models.Processings.AIs.Exceptions
{
    internal class AIProcessingValidationException : Xeption
    {
        public AIProcessingValidationException(Xeption innerException)
         : base(message: "AI validation error occurred, fix errors and try again.",
               innerException)
        { }

        public AIProcessingValidationException(string message, Xeption innerException)
            : base(message: message, innerException)
        { }
    }
}
