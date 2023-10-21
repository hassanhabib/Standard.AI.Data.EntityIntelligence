// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Schemas.Exceptions
{
    internal class InvalidSchemaException : Xeption
    {
        public InvalidSchemaException(Exception innerException)
            : base(message: "Invalid schema validation error occurred, fix the errors and try again.",
                  innerException)
        { }

        public InvalidSchemaException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
