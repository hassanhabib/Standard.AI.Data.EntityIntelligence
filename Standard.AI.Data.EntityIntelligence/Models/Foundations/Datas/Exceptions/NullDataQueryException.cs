// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions
{
    internal class NullDataQueryException : Xeption
    {
        public NullDataQueryException()
            : base(message: "Data query is null.")
        { }

        public NullDataQueryException(string message)
            : base(message)
        { }
    }
}
