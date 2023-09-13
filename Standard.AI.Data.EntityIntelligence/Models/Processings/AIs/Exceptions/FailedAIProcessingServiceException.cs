using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Processings.AIs.Exceptions
{
    internal class FailedAIProcessingServiceException : Xeption
    {
        public FailedAIProcessingServiceException(Exception innerException)
            : base(message: "Failed AI service error occurred, contact support.",
                  innerException)
        { }

        public FailedAIProcessingServiceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
