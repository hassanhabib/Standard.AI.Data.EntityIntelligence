// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions.Queries
{
    internal class QueryServiceDependencyValidationException : Xeption
    {
        public QueryServiceDependencyValidationException(Exception innerException)
            : base(message: "Query dependency validation error occurred, fix the errors and try again.",
                  innerException)
        { }

        public QueryServiceDependencyValidationException(string message, Xeption innerException)
            : base(message: message, innerException)
        { }
    }
}
