// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.AIs.Exceptions
{
    internal class InvalidAIQueryException : Xeption
    {
        public InvalidAIQueryException()
            : base(message: "Invalid AI Query error occurred, fix the errors and try again.")
        { }

        public InvalidAIQueryException(Exception innerException)
            : base(message: "Invalid AI Query error occurred, fix the errors and try again.", innerException)
        { }
    }
}
