// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Processings.AIs.Exceptions
{
    internal class InvalidAIProcessingException : Xeption
    {
        public InvalidAIProcessingException(Exception innerException)
           : base(message: "Invalid AI Processing Query errors occurred, fix the errors and try again.", innerException)
        { }

        public InvalidAIProcessingException()
           : base(message: "Invalid AI Processing Query errors occurred, fix the errors and try again.")
        { }
    }
}
