// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Processings.Schemas.Exceptions
{
    internal class SchemaProcessingDependencyException : Xeption
    {
        public SchemaProcessingDependencyException(Xeption innerException)
            : base(message: "Schema dependency error occurred, contact support.",
                  innerException)
        { }

        public SchemaProcessingDependencyException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
