// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Schemas.Exceptions
{
    internal class SchemaServiceException : Xeption
    {
        public SchemaServiceException(Xeption innerException)
           : base(message: "Metadata query service error occurred, contact support.",
                 innerException)
        { }
    }
}
