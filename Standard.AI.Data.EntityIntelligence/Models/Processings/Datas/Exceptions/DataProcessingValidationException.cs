// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Processings.Datas.Exceptions
{
    internal class DataProcessingValidationException : Xeption
    {
        public DataProcessingValidationException(Xeption innerException)
         : base(message: "Data validation error occurred, fix errors and try again.",
               innerException)
        { }

        public DataProcessingValidationException(string message, Xeption innerException)
            : base(message: message, innerException)
        { }
    }
}
