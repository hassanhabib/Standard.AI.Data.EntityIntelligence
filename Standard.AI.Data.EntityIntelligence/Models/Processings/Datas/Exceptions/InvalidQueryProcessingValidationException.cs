// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Processings.Datas.Exceptions
{
    internal class InvalidQueryProcessingException : Xeption
    {
        public InvalidQueryProcessingException(Exception innerException)
           : base(message: "Invalid Query errors occurred, fix the errors and try again.", innerException)
        { }

        public InvalidQueryProcessingException(string message)
           : base(message) { }
    }
}
