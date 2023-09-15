// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Processings.AIs.Exceptions
{
    internal class InvalidTableInformationColumnAIProcessingException : Xeption
    {
        public InvalidTableInformationColumnAIProcessingException()
            : base(message: "Table column is invalid.")
        { }

        public InvalidTableInformationColumnAIProcessingException(string message)
            : base(message) { }
    }
}
