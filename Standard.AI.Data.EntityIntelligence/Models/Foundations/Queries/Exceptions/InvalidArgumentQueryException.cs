// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Queries.Exceptions
{
    internal class InvalidArgumentQueryException : Xeption
    {
        public InvalidArgumentQueryException(Exception innerException)
            : base(message: "Invalid argument query error occurred, fix the errors and try again.",
                  innerException)
        { }

        public InvalidArgumentQueryException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}
