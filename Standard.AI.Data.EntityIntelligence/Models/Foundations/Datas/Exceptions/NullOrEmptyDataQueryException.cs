// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions
{
    internal class NullOrEmptyDataQueryException : Xeption
    {
        public NullOrEmptyDataQueryException()
            : base(message: "Data query is null or empty")
        { }
    }
}
