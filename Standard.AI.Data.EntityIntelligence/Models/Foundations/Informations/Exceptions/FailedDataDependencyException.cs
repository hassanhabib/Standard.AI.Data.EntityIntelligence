// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Informations.Exceptions
{
    internal class FailedDataDependencyException : Xeption
    {
        public FailedDataDependencyException(Exception innerException)
            : base(message: "Failed data dependency error occurred, contact support.",
                  innerException)
        { }

        public FailedDataDependencyException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}