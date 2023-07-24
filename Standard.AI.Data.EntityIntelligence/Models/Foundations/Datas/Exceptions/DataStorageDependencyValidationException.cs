// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions
{
    internal class DataStorageDependencyValidationException : Xeption
    {
        public DataStorageDependencyValidationException(Xeption innerException)
            : base(message: "Data storage validation error occurred, fix the errors and try again.",
                  innerException)
        { }
    }
}
