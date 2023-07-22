// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Processings.AIs.Exceptions
{
    internal class InvalidNaturalQueryException : Xeption
    {
        public InvalidNaturalQueryException() : base(message: "Natural language query is null or empty.")
        { }
    }
}
