// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Processings.Datas.Exceptions
{
    internal class DataProcessingDependencyException : Xeption
    {
        public DataProcessingDependencyException(Xeption innerException)
            : base(message: "Data dependency error occurred, contact support.",
                  innerException)
        { }

        public DataProcessingDependencyException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
