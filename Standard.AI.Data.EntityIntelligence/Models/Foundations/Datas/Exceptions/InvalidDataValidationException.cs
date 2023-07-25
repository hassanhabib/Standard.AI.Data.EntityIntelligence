using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions
{
    internal class InvalidDataValidationException : Xeption
    {
        public InvalidDataValidationException(Exception innerException)
            : base(message: "Invalid data validation error occurred, fix the errors and try again.",
                  innerException)
        { }
    }
}
