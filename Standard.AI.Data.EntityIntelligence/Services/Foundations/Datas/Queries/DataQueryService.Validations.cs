﻿// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Text.RegularExpressions;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Queries.Exceptions;

namespace Standard.AI.Data.EntityIntelligence.Services.Foundations.Datas.Queries
{
    internal partial class DataQueryService
    {
        private const string ValidSelectQueryRegex =
            @"^(?i)(?=(\s*SELECT.*FROM))(?!.*(?:CREATE|UPDATE|INSERT|ALTER|DELETE|EXEC|ATTACH|DETACH|TRUNCATE))[^;]*;{0,1}$";

        private static void ValidateQuery(string query)
        {
            ValidateIsNullOrEmpty(query);

            Validate(
                (Rule: IsInvalid(query), Parameter: nameof(query)));
        }

        private static void ValidateIsNullOrEmpty(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                throw new NullOrEmptyDataQueryException();
            }
        }

        private static dynamic IsInvalid(string query) => new
        {
            Condition = !Regex.IsMatch(query, ValidSelectQueryRegex),
            Message = "Query is invalid."
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
