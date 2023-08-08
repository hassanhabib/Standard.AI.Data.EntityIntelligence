// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Processings.AIs.Exceptions
{
    internal class InvalidTableInformationListAIProcessingException : Xeption
    {
        public InvalidTableInformationListAIProcessingException()
            : base(message: "Table information list is null or empty.")
        { }

        public InvalidTableInformationListAIProcessingException(string message)
            : base(message) { }
    }
}
