// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.TableMetadatas.Exceptions
{
    internal class DataInformationServiceDependencyException : Xeption
    {
        public DataInformationServiceDependencyException(Xeption innerException)
           : base(message: "Data information service dependency error occurred, contact support.",
                 innerException)
        { }
    }
}
