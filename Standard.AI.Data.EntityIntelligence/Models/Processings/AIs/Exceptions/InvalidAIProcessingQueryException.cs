// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Processings.AIs.Exceptions
{
    internal class InvalidAIProcessingQueryException : Xeption
    {
        public InvalidAIProcessingQueryException(Exception innerException)
           : base(message: "Invalid AI Processing Query error occurred, fix the errors and try again.", innerException)
        { }

        public InvalidAIProcessingQueryException()
           : base(message: "Invalid AI Processing Query error occurred, fix the errors and try again.")
        { }
    }
}
