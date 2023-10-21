// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Schemas.Exceptions
{
    internal class InvalidOperationSchemaException : Xeption
    {
        public InvalidOperationSchemaException(Exception innerException)
            : base(message: "Invalid operation data validation error occurred, fix the errors and try again.",
                  innerException)
        { }

        public InvalidOperationSchemaException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
