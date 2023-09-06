// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Queries.Exceptions
{
    internal class QueryServiceDependencyException : Xeption
    {
        public QueryServiceDependencyException(Exception innerException)
            : base(message: "Query dependency error occurred, please contact support.",
                  innerException)
        { }

        public QueryServiceDependencyException(string message, Xeption innerException)
            : base(message: message, innerException)
        { }
    }
}
