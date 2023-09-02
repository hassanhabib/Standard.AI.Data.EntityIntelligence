// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions.Queries
{
    internal class QueryServiceException : Xeption
    {
        public QueryServiceException(Exception innerException)
            : base(message: "Query service error occurred, contact support.",
                  innerException)
        { }

        public QueryServiceException(string message, Xeption innerException)
            : base(message: message, innerException)
        { }
    }
}
