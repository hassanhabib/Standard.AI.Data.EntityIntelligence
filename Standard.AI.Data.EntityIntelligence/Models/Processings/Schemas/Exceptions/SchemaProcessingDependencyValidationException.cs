// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Processings.Schemas.Exceptions
{
    internal class SchemaProcessingDependencyValidationException : Xeption
    {
        public SchemaProcessingDependencyValidationException(Xeption innerException)
            : base(message: "Schema dependency validation error occurred, fix errors and try again.",
                  innerException)
        { }

        public SchemaProcessingDependencyValidationException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
