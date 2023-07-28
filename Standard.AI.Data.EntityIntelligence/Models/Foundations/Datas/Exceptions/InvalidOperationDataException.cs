using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions
{
    internal class InvalidOperationDataException : Xeption
    {
        public InvalidOperationDataException(Exception innerException)
            : base(message: "Invalid operation data validation error occurred, fix the errors and try again.",
                  innerException)
        { }
    }
}
