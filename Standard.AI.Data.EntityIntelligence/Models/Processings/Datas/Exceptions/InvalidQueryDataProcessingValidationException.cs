// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Processings.Datas.Exceptions
{
    internal class InvalidQueryDataProcessingException : Xeption
    {
        public InvalidQueryDataProcessingException()
           : base(message: "Invalid Query errors occurred, fix the errors and try again.")
        { }

        public InvalidQueryDataProcessingException(string message)
           : base(message) { }
    }
}
