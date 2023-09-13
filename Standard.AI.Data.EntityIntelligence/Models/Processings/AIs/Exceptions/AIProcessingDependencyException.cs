// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Processings.AIs.Exceptions
{
    internal class AIProcessingDependencyException : Xeption
    {
        public AIProcessingDependencyException(Xeption innerException)
            : base(message: "AI dependency error occurred, contact support.",
                  innerException)
        { }

        public AIProcessingDependencyException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
