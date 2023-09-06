// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions.Queries
{
    internal class FailedQueryStorageException : Xeption
    {
        public FailedQueryStorageException(Exception innerException)
            : base(message: "Failed query storage error occurred, please contact support.",
                  innerException)
        { }

        public FailedQueryStorageException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}
