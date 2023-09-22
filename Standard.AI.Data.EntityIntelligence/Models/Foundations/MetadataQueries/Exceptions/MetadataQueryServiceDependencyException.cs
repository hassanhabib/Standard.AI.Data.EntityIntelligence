// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.TableMetadatas.Exceptions
{
    internal class MetadataQueryServiceDependencyException : Xeption
    {
        public MetadataQueryServiceDependencyException(Xeption innerException)
           : base(message: "Metadata query service dependency error occurred, contact support.",
                 innerException)
        { }
    }
}
