// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions
{
    internal class FailedDataServiceException : Xeption
    {
        public FailedDataServiceException(Exception innerException)
            : base(message: "Failed data service error occurred, contact support.",
                  innerException)
        { }
    }
}
