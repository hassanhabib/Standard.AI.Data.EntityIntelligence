// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Processings.AIs.Exceptions
{
    internal class InvalidNaturalQueryAIProcessingException : Xeption
    {
        public InvalidNaturalQueryAIProcessingException()
            : base(message: "Natural query is invalid, fix errors and try again.")
        { }

        public InvalidNaturalQueryAIProcessingException(string message)
            : base(message) { }
    }
}
