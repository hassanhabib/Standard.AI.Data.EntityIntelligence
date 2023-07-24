// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions
{
    internal class FailedDataStorageDependencyException : Xeption
    {
        public FailedDataStorageDependencyException(Exception innerException)
            : base(message: "Failed data storage dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
