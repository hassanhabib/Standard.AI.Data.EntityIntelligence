// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions
{
    internal class DataServiceDependencyException : Xeption
    {
        public DataServiceDependencyException(Xeption innerException)
           : base(message: "Data query service dependency error occurred, contact support.",
                 innerException)
        { }
    }
}
