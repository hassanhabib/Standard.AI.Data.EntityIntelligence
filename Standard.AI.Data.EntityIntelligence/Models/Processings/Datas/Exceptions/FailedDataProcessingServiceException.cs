// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Processings.Datas.Exceptions
{
    internal class FailedDataProcessingServiceException : Xeption
    {
        public FailedDataProcessingServiceException(Xeption innerException)
            : base(message: "Failed Data service error occurred, contact support.",
                  innerException)
        { }

        public FailedDataProcessingServiceException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
