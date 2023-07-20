// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Processings.AIs.Exceptions
{
    internal class NullOrEmptyTableInformationException : Xeption
    {
        public NullOrEmptyTableInformationException() : base(message: "Table information is null or empty.")
        { }
    }
}
