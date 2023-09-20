// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Queries.Exceptions
{
    internal class DataQueryServiceValidationException : Xeption
    {
        public DataQueryServiceValidationException(Xeption innerException)
            : base(message: "Data query service validation error occurred, fix the errors and try again.")
        { }
    }
}
