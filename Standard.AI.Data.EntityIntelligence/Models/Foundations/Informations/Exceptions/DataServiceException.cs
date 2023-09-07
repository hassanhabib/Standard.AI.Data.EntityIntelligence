// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Informations.Exceptions
{
    internal class DataServiceException : Xeption
    {
        public DataServiceException(Xeption innerException)
           : base(message: "Data service error occurred, contact support.",
                 innerException)
        { }

        public DataServiceException(string message, Xeption innerException)
            : base(message: message, innerException)
        { }
    }
}
