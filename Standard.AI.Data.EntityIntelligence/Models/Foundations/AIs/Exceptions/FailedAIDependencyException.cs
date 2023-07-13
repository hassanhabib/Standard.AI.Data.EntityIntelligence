// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.AIs.Exceptions
{
    internal class FailedAIDependencyException : Xeption
    {
        public FailedAIDependencyException(Exception innerException)
            : base(message: "Failed AI dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
