// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions
{
    internal class InvalidDataException : Xeption
    {
        public InvalidDataException(Exception innerException)
            : base(message: "Invalid data validation error occurred, fix the errors and try again.",
                  innerException)
        { }
        
        public InvalidDataException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
