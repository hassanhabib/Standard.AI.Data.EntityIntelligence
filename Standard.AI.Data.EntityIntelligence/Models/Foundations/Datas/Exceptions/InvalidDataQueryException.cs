// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions
{
    internal class InvalidDataQueryException : Xeption
    {
        public InvalidDataQueryException()
            : base(message: "Invalid query error occurred, fix the errors and try again.")
        { }

        public InvalidDataQueryException(string message)
            : base(message)
        { }
    }
}