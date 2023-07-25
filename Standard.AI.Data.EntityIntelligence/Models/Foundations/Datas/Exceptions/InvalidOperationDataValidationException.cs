using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions
{
    internal class InvalidOperationDataValidationException : Xeption
    {
        public InvalidOperationDataValidationException(Exception innerException)
            : base(message: "Invalid operation data validation error occurred, fix the errors and try again.",
                  innerException)
        { }
    }
}
