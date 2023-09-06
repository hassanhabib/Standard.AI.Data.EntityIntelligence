// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Standard.AI.Data.EntityIntelligence.Models.Foundations.Queries.Exceptions;

namespace Standard.AI.Data.EntityIntelligence.Services.Foundations.Queries
{
    internal partial class QueryService
    {
        private static void ValidateQuery(string query)
        {
            ValidateIsNullOrEmpty(query);
        }

        private static void ValidateIsNullOrEmpty(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                throw new InvalidQueryException();
            }
        }
    }
}
