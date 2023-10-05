// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Processings.Datas.Exceptions
{
    internal class DataProcessingDependencyValidationException : Xeption
    {
        public DataProcessingDependencyValidationException(Xeption innerException)
           : base(message: "Data dependency validation error occurred, fix errors and try again.",
                 innerException)
        { }

        public DataProcessingDependencyValidationException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
