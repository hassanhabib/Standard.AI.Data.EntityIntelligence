// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Processings.AIs.Exceptions
{
    internal class AIProcessingServiceException : Xeption
    {
        public AIProcessingServiceException(Xeption innerException)
            : base(message: "AI service error occurred, contact support.",
                  innerException)
        { }

        public AIProcessingServiceException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
