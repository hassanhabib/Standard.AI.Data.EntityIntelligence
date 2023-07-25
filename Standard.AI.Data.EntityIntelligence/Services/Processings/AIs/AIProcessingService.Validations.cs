// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using Standard.AI.Data.EntityIntelligence.Models.Datas;
using Standard.AI.Data.EntityIntelligence.Models.Processings.AIs.Exceptions;

namespace Standard.AI.Data.EntityIntelligence.Services.Processings.AIs
{
    internal partial class AIProcessingService : IAIProcessingService
    {
        private static void ValidateTablesAndNaturalQuery(List<TableInformation> tables, string naturalQuery)

        {
            // break the circuit if no tables
            ValidateTablesAreNotNullOrEmpty(tables);

            // continous validation
            // TODO: Is there a better way to test these nested objects?
            Validate(
                (Rule: IsInvalidNaturalQuery(naturalQuery), Parameter: nameof(naturalQuery)),
                (Rule: IsInvalidTables(tables), Parameter: nameof(tables)),
                (Rule: IsInvalidTableColumns(tables), Parameter: nameof(tables))
                );


            var listOfTables = new List<TableInformation>
            {
                null,

                new TableInformation
                {
                    Name = "Students",
                    Columns = new List<TableColumn>
                    {
                        new TableColumn
                        {
                            Name = "Name",
                            Type = "varchar(max)" // 2GB
                        }
                    }
                },

                new TableInformation
                {
                    Name = null,
                    Columns = new List<TableColumn>()
                },

                new TableInformation
                {
                    Name = "Teachers",
                    Columns = null
                },
            };





            // Break if List<TableInformation> is null NullTableInformationListException()
            // Break if naturalQuery is null, empty or whitespace InvalidNaturalQueryException()

            // Break if any of List<TableInformation> is null InvalidAIProcessingException() [BAD]

            // Validate if any tableinformation.TableName is null, empty or whitespace
            // Validate if any tableinformation.columns is null or empty
            // Then Break InvalidAIProcessingException() with Data having the issues

            // Validate if any ColumnName is not null, empty or whitespace
            // Validate if any ColumnValue is not null, empty or whitespace
            // Then Break InvalidAIProcessingException()

        }

        private static void ValidateTablesAreNotNullOrEmpty(List<TableInformation> tables)
        {
            if (tables is null || tables.Count == 0)
            {
                throw new NullOrEmptyTableInformationException();
            }
        }

        private static dynamic IsInvalidNaturalQuery(string naturalQuery) => new
        {
            Condition = string.IsNullOrWhiteSpace(naturalQuery),
            Message = "Natural query is required."
        };

        private static dynamic IsInvalidTables(List<TableInformation> tables) => new
        {
            Condition = tables.Any(tableInformation => string.IsNullOrEmpty(tableInformation.Name) || tableInformation.Columns == null
            || tableInformation.Columns.Count() == 0),
            Message = "Each table should have a name and associated columns."
            // One or more tables are null
        };

        private static dynamic IsInvalidTableColumns(List<TableInformation> tables) => new
        {
            Condition = tables.Any(tableInformation => tableInformation.Columns.Any(column => string.IsNullOrEmpty(column.Name) ||
                string.IsNullOrEmpty(column.Type))),
            Message = "Each table column should have a name and a type."
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidAIProcessingException =
                new InvalidAIProcessingQueryException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidAIProcessingException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidAIProcessingException.ThrowIfContainsErrors();
        }

        private static void DeleteMe()
        {
            var invalidTableInformations = new List<TableInformation>
            {
                null,

                new TableInformation
                {

                },

                new TableInformation
                {
                    Name = null,
                    Columns = new List<TableColumn>()
                },

                new TableInformation
                {
                    Name = "Students",
                    Columns = null
                },
            };

            ValidateTableInformations(invalidTableInformations);
        }

        private static void ValidateTableInformations(
            List<TableInformation> tableInformations)
        {
            var invalidAIProcessingException =
                new InvalidAIProcessingQueryException();

            Validate(
                tableInformations.SelectMany((tableInformation, index) =>
                    ValidateTableInformation(tableInformation, index)).ToArray());

            return;
        }

        private static IEnumerable<(dynamic, string)> ValidateTableInformation(
            TableInformation tableInformation,
            int index)
        {
            return tableInformation switch
            {
                null => new List<(dynamic Rule, string Parameter)>
                {
                    (Rule: IsInvalid(tableInformation),
                    Parameter: $"Item[{index}]")
                },

                _ => ValidateTableInformationPropeties(tableInformation, index)
            };
        }

        private static IEnumerable<(dynamic, string)> ValidateTableInformationPropeties(
            TableInformation tableInformation,
            int index)
        {
            return new List<(dynamic Rule, string Parameter)>
            {
                (Rule: IsInvalid(tableInformation.Name, nameof(TableInformation.Name)),
                Parameter: $"Item[{index}]"),

                (Rule: IsInvalid(tableInformation.Columns, nameof(TableInformation.Columns)),
                Parameter: $"Item[{index}]")
            }.Where(validation => validation.Rule.Condition is true);
        }

        private static dynamic IsInvalid(
            string value,
            string propertyName) => new
            {
                Condition = String.IsNullOrWhiteSpace(value),
                Message = $"{propertyName} is required"
            };

        private static dynamic IsInvalid(
            object @object,
            string propertyName) => new
            {
                Condition = @object is null,
                Message = $"{propertyName} Value is required"
            };

        private static dynamic IsInvalid(object @object) => new
        {
            Condition = @object is null,
            Message = $"Value is required"
        };
    }
}
