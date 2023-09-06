// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Queries.Exceptions
{
    internal class QueryValidationException : Xeption
    {
        public QueryValidationException(Exception innerException)
            : base(message: "Query validation error occurred, fix the errors and try again.",
                  innerException)
        { }

        public QueryValidationException(string message, Xeption innerException)
            : base(message: message, innerException)
        { }
    }
}
