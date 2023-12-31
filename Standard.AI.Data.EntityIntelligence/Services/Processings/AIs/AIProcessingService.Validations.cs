﻿// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Schemas;
using Standard.AI.Data.EntityIntelligence.Models.Processings.AIs.Exceptions;

namespace Standard.AI.Data.EntityIntelligence.Services.Processings.AIs
{
    internal partial class AIProcessingService
    {
        private static void ValidateNaturalQuery(string naturalQuery)
        {
            if (string.IsNullOrWhiteSpace(naturalQuery))
            {
                throw new InvalidNaturalQueryAIProcessingException();
            }
        }

        private static void ValidateTableInformationList(List<SchemaTable> tableInformations)
        {
            ValidateTableInformationListNotNullOrEmpty(tableInformations);

            IEnumerable<(dynamic, string)> tableInformationListValidations =
               tableInformations.Select((tableInformation, index) =>
                   (Rule: IsInvalid(tableInformation), Parameter: $"Element at {index}"));

            Validate(tableInformationListValidations.ToArray());

            IEnumerable<(dynamic, string)> tableNameValidations =
                tableInformations.Select((tableInformation, index) =>
                    (Rule: IsInvalid(tableInformation.Name), Parameter: $"Name at {index}"));

            IEnumerable<(dynamic, string)> tableColumnsValidations =
                tableInformations.Select((tableInformation, index) =>
                    (Rule: IsInvalid(tableInformation.Columns), Parameter: $"Columns at {index}"));

            (dynamic, string)[] validations =
                tableNameValidations
                    .Concat(tableColumnsValidations)
                        .ToArray();

            ValidateForItems(validations);

            (dynamic, string)[] tableInformationIndividualColumnsValidations =
                tableInformations.SelectMany((tableInformation, index) =>
                    tableInformation.Columns.Select((tableColumn, columnIndex) =>
                        (Rule: IsInvalidColumn(tableColumn), Parameter: $"Table {tableInformation.Name} Column {columnIndex}")))
                            .ToArray();

            ValidateForColumnItems(tableInformationIndividualColumnsValidations);
        }

        private static void ValidateTableInformationListNotNullOrEmpty(List<SchemaTable> tableInformations)
        {
            if (tableInformations is null || tableInformations.Any() is false)
            {
                throw new InvalidTableInformationListAIProcessingException();
            }
        }

        private static dynamic IsInvalid(SchemaTable tableInformation) => new
        {
            Condition = tableInformation is null,
            Message = "Object is required"
        };

        private static dynamic IsInvalid(string name) => new
        {
            Condition = String.IsNullOrWhiteSpace(name),
            Message = "Name is required"
        };

        private static dynamic IsInvalidColumn(SchemaTableColumn column) => new
        {
            Condition = column == null || String.IsNullOrWhiteSpace(column.Name) || String.IsNullOrWhiteSpace(column.Type),
            Message = "Column is invalid"
        };

        private static dynamic IsInvalid(IEnumerable<SchemaTableColumn> tableColumns) => new
        {
            Condition = tableColumns is null || tableColumns.Any() is false,
            Message = "Columns are required"
        };

        private static dynamic IsInvalid(SchemaTableColumn tableColumn) => new
        {
            Condition = tableColumn is null,
            Message = "Column is invalid"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidTableInformationListAIProcessingException =
                new InvalidTableInformationListAIProcessingException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidTableInformationListAIProcessingException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidTableInformationListAIProcessingException.ThrowIfContainsErrors();
        }

        private static void ValidateForItems(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidTableInformationAIProcessingException =
                new InvalidTableInformationAIProcessingException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidTableInformationAIProcessingException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidTableInformationAIProcessingException.ThrowIfContainsErrors();
        }

        private static void ValidateForColumnItems(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidTableInformationColumnAIProcessingException =
                new InvalidTableInformationColumnAIProcessingException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidTableInformationColumnAIProcessingException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidTableInformationColumnAIProcessingException.ThrowIfContainsErrors();
        }
    }
}
