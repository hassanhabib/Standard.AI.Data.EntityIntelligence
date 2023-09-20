// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.TableMetadatas.Exceptions
{
    internal class DataInformationServiceException : Xeption
    {
        public DataInformationServiceException(Xeption innerException)
           : base(message: "Data information service error occurred, contact support.",
                 innerException)
        { }
    }
}
