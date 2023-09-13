// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Processings.AIs.Exceptions
{
    internal class AIProcessingDependencyValidationException : Xeption
    {
        public AIProcessingDependencyValidationException(Xeption innerException)
            : base(message: "AI dependency validation error occurred, fix errors and try again.",
                  innerException)
        { }

        public AIProcessingDependencyValidationException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
