// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Services.Foundations.AIs.Exceptions
{
    internal class InvalidAIQueryException : Xeption
    {
        public InvalidAIQueryException()
            : base(message: "Invalid AI Query error occurred, fix the errors and try again.")
        { }
    }
}
