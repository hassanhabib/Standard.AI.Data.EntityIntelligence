// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Processings.Datas.Exceptions
{
    internal class FailedDataProcessingServiceException : Xeption
    {
        public FailedDataProcessingServiceException(Exception innerException)
            : base(message: "Failed data service error occurred, contact support.",
                  innerException)
        { }

        public FailedDataProcessingServiceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
