// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Schemas.Exceptions
{
    internal class FailedSchemaServiceException : Xeption
    {
        public FailedSchemaServiceException(Exception innerException)
            : base(message: "Failed schema service error occurred, contact support.",
                  innerException)
        { }
        
        public FailedSchemaServiceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
