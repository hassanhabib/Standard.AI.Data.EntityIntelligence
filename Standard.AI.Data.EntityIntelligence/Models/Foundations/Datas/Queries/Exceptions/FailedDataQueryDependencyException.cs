// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Queries.Exceptions
{
    internal class FailedDataQueryDependencyException : Xeption
    {
        public FailedDataQueryDependencyException(Exception innerException)
            : base(message: "Failed data query dependency error ocurred, contact support.",
                  innerException)
        { }
    }
}
