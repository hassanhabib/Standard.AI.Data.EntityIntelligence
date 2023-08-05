// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Data;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions;

namespace Standard.AI.Data.EntityIntelligence.Services.Foundations.Datas
{
    internal partial class DataService
    {
        private const string ValidSqlStatementRegex =
            @"^\s*SELECT[^;]*FROM(?:[^;]*;){0,1}$";

        private static void ValidateQuery(string query) =>
            Validate(
                (Rule: IsInvalid(query), Parameter: nameof(query)),
                (Rule: IsInvalidSelectQuery(query), Parameter: nameof(query)));

        private static dynamic IsInvalidSelectQuery(string query) => new
        {
            Condition = !Regex.IsMatch(query, ValidSqlStatementRegex),
            Message = "Invalid select query."
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
