// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.AIs.Exceptions
{
    internal class AIDependencyException : Xeption
    {
        public AIDependencyException(Xeption innerException)
            : base(message: "AI dependency error occurred, fix the errors and try agian.")
        { }
    }
}
