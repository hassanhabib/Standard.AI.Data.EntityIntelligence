// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Processings.Schemas.Exceptions
{
    internal class FailedSchemaProcessingServiceException : Xeption
    {
        public FailedSchemaProcessingServiceException(Exception innerException)
            : base(message: "Failed Schema service error occurred, contact support.",
                  innerException)
        { }

        public FailedSchemaProcessingServiceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
