// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.AIs.Exceptions;

namespace Standard.AI.Data.EntityIntelligence.Services.Foundations.AIs
{
    internal partial class AIService : IAIService
    {
        private static void ValidateNaturalQuery(string naturalQuery) =>
            Validate(validations: (Rule: IsInvalid(naturalQuery), Parameter: nameof(naturalQuery)));

        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Text is required."
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidAIQueryException = new InvalidAIQueryException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidAIQueryException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidAIQueryException.ThrowIfContainsErrors();
        }
    }
}
