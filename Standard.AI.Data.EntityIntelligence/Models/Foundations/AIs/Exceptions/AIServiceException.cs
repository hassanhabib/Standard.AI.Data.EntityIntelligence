// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.AIs.Exceptions
{
    internal class AIServiceException : Xeption
    {
        public AIServiceException(Xeption innerException)
            : base(message: "AI error occurred, contact support.",
                  innerException)
        { }
    }
}
