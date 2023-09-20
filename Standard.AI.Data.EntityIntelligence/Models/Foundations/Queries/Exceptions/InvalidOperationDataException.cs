// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Queries.Exceptions
{
    internal class InvalidOperationDataException : Xeption
    {
        public InvalidOperationDataException(Exception innerException)
            : base(message: "Invalid operation data validation error occurred, fix the errors and try again.",
                  innerException)
        { }
    }
}
