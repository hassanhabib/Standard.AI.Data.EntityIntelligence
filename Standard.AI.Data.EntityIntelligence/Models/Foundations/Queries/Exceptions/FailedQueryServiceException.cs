// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Queries.Exceptions
{
    internal class FailedQueryServiceException : Xeption
    {
        public FailedQueryServiceException(Exception innerException)
            : base(message: "Failed query service error occurred, contact support.",
                  innerException)
        { }

        public FailedQueryServiceException(string message, Xeption innerException)
            : base(message: message, innerException)
        { }
    }
}
