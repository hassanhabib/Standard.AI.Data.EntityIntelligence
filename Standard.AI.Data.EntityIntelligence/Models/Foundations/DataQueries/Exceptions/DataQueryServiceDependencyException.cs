// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Queries.Exceptions
{
    internal class DataQueryServiceDependencyException : Xeption
    {
        public DataQueryServiceDependencyException(Xeption innerException)
           : base(message: "Data query service dependency error occurred, contact support.",
                 innerException)
        { }
    }
}
