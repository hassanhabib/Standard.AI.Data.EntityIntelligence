// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Data;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using RESTFulSense.Models.Coordinations.Forms.Exceptions;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions;

namespace Standard.AI.Data.EntityIntelligence.Services.Foundations.Datas
{
    internal partial class DataService
    {
        private const string MultiStatementSelectQueryRegex =
            @"^(?i)(?=(\s*SELECT.*FROM))[^;]*;{0,1}$";

        private static void ValidateQuery(string query)
        {
            ValidateIsNullOrEmpty(query);

            Validate(
                (Rule: IsMultiStatementSelectQuery(query), Parameter: nameof(query)));
        }

        private static void ValidateIsNullOrEmpty(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                throw new NullOrEmptyDataQueryException();
            }
        }

        private static dynamic IsMultiStatementSelectQuery(string query) => new
        {
            Condition = !Regex.IsMatch(query, MultiStatementSelectQueryRegex),
            Message = "Query with multiple statements not allowed."
        };

        private static dynamic IsInvalid(string query) => new
        {
            Condition = String.IsNullOrWhiteSpace(query),
            Message = "Query is required."
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
