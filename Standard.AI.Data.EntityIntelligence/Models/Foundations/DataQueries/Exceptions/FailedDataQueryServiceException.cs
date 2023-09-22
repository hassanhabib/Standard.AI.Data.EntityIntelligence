// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Queries.Exceptions
{
    internal class FailedDataQueryServiceException : Xeption
    {
        public FailedDataQueryServiceException(Exception innerException)
            : base(message: "Failed data query service error occurred, contact support.",
                  innerException)
        { }
    }
}
