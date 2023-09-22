// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.TableMetadatas.Exceptions
{
    internal class MetadataQueryServiceDependencyValidationException : Xeption
    {
        public MetadataQueryServiceDependencyValidationException(Xeption innerException)
            : base(message: "Data validation error occurred, fix the errors and try again.",
                  innerException)
        { }
    }
}
