// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions.Informations
{
    internal class DataDependencyException : Xeption
    {
        public DataDependencyException(Xeption innerException)
           : base(message: "Data dependency error occurred, contact support.",
                 innerException)
        { }
    }
}
