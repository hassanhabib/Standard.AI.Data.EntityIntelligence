// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Queries.Exceptions
{
    internal class InvalidQueryException : Xeption
    {
        public InvalidQueryException()
            : base(message: "Invalid query error occurred, fix the errors and try again.")
        { }

        public InvalidQueryException(string message)
            : base(message: message)
        { }
    }
}
