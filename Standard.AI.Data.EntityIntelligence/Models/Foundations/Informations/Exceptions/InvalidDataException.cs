using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Informations.Exceptions
{
    internal class InvalidDataException : Xeption
    {
        public InvalidDataException(Exception innerException)
            : base(message: "Invalid data validation error occurred, fix the errors and try again.",
                  innerException)
        { }

        public InvalidDataException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}
