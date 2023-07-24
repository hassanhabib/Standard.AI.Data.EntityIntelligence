// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions
{
    internal class DataStorageDependencyException : Xeption
    {
        public DataStorageDependencyException(Xeption innerException)
           : base(message: "Data storage dependency error occurred, contact support.",
                 innerException)
        { }
    }
}
