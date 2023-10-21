// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Schemas.Exceptions
{
    internal class SchemaDependencyValidationException : Xeption
    {
        public SchemaDependencyValidationException(Xeption innerException)
            : base(message: "Data validation error occurred, fix the errors and try again.",
                  innerException)
        { }

        public SchemaDependencyValidationException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
