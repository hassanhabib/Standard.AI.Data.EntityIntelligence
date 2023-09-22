// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Queries.Exceptions
{
    internal class DataQueryServiceException : Xeption
    {
        public DataQueryServiceException(Xeption innerException)
           : base(message: "Data query service error occurred, contact support.",
                 innerException)
        { }
    }
}
