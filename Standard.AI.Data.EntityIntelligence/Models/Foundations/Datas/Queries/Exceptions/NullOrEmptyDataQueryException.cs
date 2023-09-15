// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Queries.Exceptions
{
    internal class NullOrEmptyDataQueryException : Xeption
    {
        public NullOrEmptyDataQueryException()
            : base(message: "Data query is null or empty")
        { }
    }
}
