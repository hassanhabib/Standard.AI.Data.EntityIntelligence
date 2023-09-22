// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.TableMetadatas.Exceptions
{
    internal class MetadataQueryServiceException : Xeption
    {
        public MetadataQueryServiceException(Xeption innerException)
           : base(message: "Metadata query service error occurred, contact support.",
                 innerException)
        { }
    }
}
