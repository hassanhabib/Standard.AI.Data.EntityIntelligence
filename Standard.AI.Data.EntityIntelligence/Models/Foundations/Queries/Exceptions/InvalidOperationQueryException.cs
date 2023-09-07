// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Queries.Exceptions
{
    internal class InvalidOperationQueryException : Xeption
    {
        public InvalidOperationQueryException(Exception innerException)
            : base(message: "Invalid operation query error occurred, fix the errors and try again.",
                  innerException)
        { }

        public InvalidOperationQueryException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}
