// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Processings.Datas.Exceptions
{
    internal class DataProcessingServiceException : Xeption
    {
        public DataProcessingServiceException(Xeption innerException)
            : base(message: "Data service error occurred, contact support.",
                  innerException)
        { }

        public DataProcessingServiceException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
