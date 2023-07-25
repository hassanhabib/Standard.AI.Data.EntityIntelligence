// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions
{
    internal class FailedDataDependencyValidationException : Xeption
    {
        public FailedDataDependencyValidationException(Exception innerException)
            : base(message: "Data validation error occurred, fix the errors and try again.",
                  innerException)
        { }
    }
}