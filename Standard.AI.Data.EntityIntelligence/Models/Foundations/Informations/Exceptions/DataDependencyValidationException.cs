// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Informations.Exceptions
{
    internal class DataDependencyValidationException : Xeption
    {
        public DataDependencyValidationException(Xeption innerException)
            : base(message: "Data validation error occurred, fix the errors and try again.",
                  innerException)
        { }

        public DataDependencyValidationException(string message, Xeption innerException)
            : base(message: message, innerException)
        { }
    }
}
