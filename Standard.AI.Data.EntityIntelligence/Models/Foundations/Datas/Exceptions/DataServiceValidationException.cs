// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions
{
    internal class DataServiceValidationException : Xeption
    {
        public DataServiceValidationException(Xeption innerException)
            : base(message: "Data query service validation error occurred, fix the errors and try again.")
        { }
    }
}
