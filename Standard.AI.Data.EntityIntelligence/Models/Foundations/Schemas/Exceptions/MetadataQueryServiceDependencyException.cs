// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Schemas.Exceptions
{
    internal class SchemaServiceDependencyException : Xeption
    {
        public SchemaServiceDependencyException(Xeption innerException)
           : base(message: "Metadata query service dependency error occurred, contact support.",
                 innerException)
        { }
    }
}
