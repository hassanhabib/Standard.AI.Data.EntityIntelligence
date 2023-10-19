// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Processings.Schemas.Exceptions
{
    internal class SchemaProcessingServiceException : Xeption
    {
        public SchemaProcessingServiceException(Xeption innerException)
            : base(message: "Schema service error occurred, contact support.",
                  innerException)
        { }

        public SchemaProcessingServiceException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
