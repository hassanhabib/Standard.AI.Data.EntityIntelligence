// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Processings.AIs.Exceptions
{
    internal class NullTableInformationListException : Xeption
    {
        public NullTableInformationListException() : base(message: "Table information list is null.")
        { }
    }
}
