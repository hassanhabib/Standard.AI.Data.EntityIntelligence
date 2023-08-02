// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions
{
    internal class MultipleStatementQueryException : Xeption
    {
        public MultipleStatementQueryException()
             : base(message: "Invalid multi-statement query error occurred, fix the errors and try again.")
        { }

        public MultipleStatementQueryException(Exception innerException)
            : base(message: "Invalid multi-statement query error occurred, fix the errors and try again.", innerException)
        { }
    }
}
