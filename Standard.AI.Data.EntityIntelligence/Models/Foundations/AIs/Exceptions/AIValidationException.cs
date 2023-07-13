// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.AIs.Exceptions
{
    internal class AIValidationException : Xeption
    {
        public AIValidationException(Xeption innerException)
            : base(message: "AI validation error occurred, fix the errors and try again.")
        { }
    }
}
