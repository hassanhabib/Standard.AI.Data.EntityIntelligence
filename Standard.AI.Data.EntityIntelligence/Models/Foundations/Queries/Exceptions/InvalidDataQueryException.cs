// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Queries.Exceptions
{
    internal class InvalidDataQueryException : Xeption
    {
        public InvalidDataQueryException()
            : base(message: "Invalid query error occurred, fix the errors and try again.")
        { }

        public InvalidDataQueryException(Exception innerException)
            : base(message: "Invalid query error occurred, fix the errors and try again.", innerException)
        { }
    }
}
