// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.TableMetadatas.Exceptions
{
    internal class FailedDataInformationServiceException : Xeption
    {
        public FailedDataInformationServiceException(Exception innerException)
            : base(message: "Failed data information service error occurred, contact support.",
                  innerException)
        { }
    }
}
