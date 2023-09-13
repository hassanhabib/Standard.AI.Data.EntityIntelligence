// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Processings.AIs.Exceptions
{
    internal class InvalidTableInformationAIProcessingException : Xeption
    {
        public InvalidTableInformationAIProcessingException()
            : base(message: "Table information is invalid.")
        { }

        public InvalidTableInformationAIProcessingException(string message)
            : base(message) { }
    }
}
