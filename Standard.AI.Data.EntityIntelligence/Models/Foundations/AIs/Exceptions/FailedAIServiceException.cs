// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.AIs.Exceptions
{
    internal class FailedAIServiceException : Xeption
    {
        public FailedAIServiceException(Exception innerException)
            : base(message: "Failed AI service error occurred, contact support.",
                  innerException)
        { }

        public FailedAIServiceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
