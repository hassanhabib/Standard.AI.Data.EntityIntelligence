// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.TableMetadatas.Exceptions
{
    internal class DataInformationServiceDependencyValidationException : Xeption
    {
        public DataInformationServiceDependencyValidationException(Xeption innerException)
            : base(message: "Data validation error occurred, fix the errors and try again.",
                  innerException)
        { }
    }
}
