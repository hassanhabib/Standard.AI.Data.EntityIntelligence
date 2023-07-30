// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions;

namespace Standard.AI.Data.EntityIntelligence.Services.Foundations.Datas
{
    internal partial class DataService
    {
        private static void ValidateQuery(string query) =>
            Validate(validations: (Rule: IsInvalid(query), Parameter: nameof(query)));

        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Text is required."
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidDataQueryException = new InvalidDataQueryException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidDataQueryException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidDataQueryException.ThrowIfContainsErrors();
        }
    }
}
