// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Schemas.Exceptions
{
    internal class SchemaServiceException : Xeption
    {
        public SchemaServiceException(Xeption innerException)
           : base(message: "Schema service error occurred, contact support.",
                 innerException)
        { }

        public SchemaServiceException(string message, Xeption innerException)
           : base(message, innerException)
        { }
    }
}
