// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;
namespace Standard.AI.Data.EntityIntelligence.Models.Processings.AIs.Exceptions
{
    internal class AIProcessingValidationException : Xeption
    {
        public AIProcessingValidationException(Exception innerException)
         : base(message: "Invalid AI Query error occurred, fix the errors and try again.", innerException)
        { }
    }
}
