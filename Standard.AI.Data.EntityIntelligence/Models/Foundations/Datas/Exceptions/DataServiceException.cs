// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions
{
    internal class DataServiceException : Xeption
    {
        public DataServiceException(Xeption innerException)
           : base(message: "Data service error occurred, contact support.",
                 innerException)
        { }
    }
}
