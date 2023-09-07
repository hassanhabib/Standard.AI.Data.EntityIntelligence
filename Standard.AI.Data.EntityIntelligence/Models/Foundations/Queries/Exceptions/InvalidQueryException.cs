// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Queries.Exceptions
{
    internal class InvalidQueryException : Xeption
    {
        public InvalidQueryException()
            : base(message: "Invalid query error occurred, fix the errors and try again.")
        { }

        public InvalidQueryException(Exception innerException)
            : base(message: "Invalid query error occurred, fix the errors and try again.",
                  innerException)
        { }

        public InvalidQueryException(string message)
            : base(message: message)
        { }

        public InvalidQueryException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}
