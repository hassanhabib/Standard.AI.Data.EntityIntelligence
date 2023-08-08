// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;
namespace Standard.AI.Data.EntityIntelligence.Models.Processings.AIs.Exceptions
{
    internal class AIProcessingValidationException : Xeption
    {
        public AIProcessingValidationException(Xeption innerException)
         : base(message: "Invalid AI Query error occurred, fix the errors and try again.",
               innerException)
        { }

        public AIProcessingValidationException(string message, Xeption innerException)
            : base(message: message, innerException)
        { }
    }
}
