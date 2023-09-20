// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Queries.Exceptions
{
    internal class DataQueryServiceDependencyValidationException : Xeption
    {
        public DataQueryServiceDependencyValidationException(Xeption innerException)
            : base(message: "Data validation error occurred, fix the errors and try again.",
                  innerException)
        { }
    }
}
