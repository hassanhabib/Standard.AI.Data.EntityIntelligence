// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.TableMetadatas.Exceptions
{
    internal class FailedMetadataQueryServiceException : Xeption
    {
        public FailedMetadataQueryServiceException(Exception innerException)
            : base(message: "Failed metadata query service error occurred, contact support.",
                  innerException)
        { }
    }
}
