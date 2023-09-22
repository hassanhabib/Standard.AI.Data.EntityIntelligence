// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.TableMetadatas.Exceptions
{
    internal class FailedDataDependencyException : Xeption
    {
        public FailedDataDependencyException(Exception innerException)
            : base(message: "Failed data dependency error ocurred, contact support.",
                  innerException)
        { }
    }
}