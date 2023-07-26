// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Standard.AI.Data.EntityIntelligence.Models.Datas;
using Standard.AI.Data.EntityIntelligence.Models.Processings.AIs.Exceptions;

namespace Standard.AI.Data.EntityIntelligence.Services.Processings.AIs
{
    internal partial class AIProcessingService : IAIProcessingService
    {
        private static void ValidateTablesAndNaturalQuery(List<TableInformation> tables, string naturalQuery)

        {
            // Validate tables
            ValidateTableInformations(tables);

            // Validate columns
            ValidateTableInformationsColumns(tables);
        }

        private static void DeleteMe()
        {
            List<TableInformation> tables = new List<TableInformation>
            {
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
                    Name = "Teachers",
                    Columns = new List<TableColumn>
                    {
                        new TableColumn
                        {
                            Name = "",
                            Type = "int"
                        },
                         new TableColumn
                        {
                            Name = "",
                            Type = ""
                        }
                    }
                },

                  new TableInformation
                {
                    Name = "Table3",
                    Columns = new List<TableColumn>
                    {
                        new TableColumn
                        {
                            Name = null,
                            Type = null
                        },
                        new TableColumn
                        {
                            Name = "some name",
                            Type = "some type"
                        }
                    }
                }


            };

            ValidateTableInformationsColumns(tables);
        }

        private static void ValidateTableInformationsColumns(List<TableInformation> tableInformations)
        {
            Validate(tableInformations.SelectMany((tableInformation, tableIndex) =>
                           ValidateTableInformationColumns(tableInformation, tableIndex)).ToArray());
        }

        private static IEnumerable<(dynamic, string)> ValidateTableInformationColumns(
                       TableInformation tableInformation, int tableIndex)
        {
            return tableInformation.Columns.SelectMany((tableColumn, columnIndex) =>
                 ValidateTableInformationColumn(tableColumn, columnIndex, tableIndex));
        }

        private static IEnumerable<(dynamic, string)> ValidateTableInformationColumn(TableColumn tableColumn, int columnIndex, int tableIndex)
        {
            return tableColumn switch
            {
                null => new List<(dynamic Rule, string Parameter)>
                {
                    (Rule: IsInvalid(tableColumn),
                    Parameter: $"Table[{tableIndex}] Column[{columnIndex}]")
                },

                _ => ValidateColumnProperties(tableColumn, columnIndex, tableIndex)
            };
        }

        private static IEnumerable<(dynamic Rule, string Parameter)> ValidateColumnProperties(TableColumn tableColumn, int columnIndex, int tableIndex)
        {
            return new List<(dynamic Rule, string Parameter)>
            {
                (Rule: IsInvalid(tableColumn.Name, nameof(TableColumn.Name)),
                    Parameter: $"Table[{tableIndex}] Column[{columnIndex}]"),

                (Rule: IsInvalid(tableColumn.Type, nameof(TableColumn.Type)),
                    Parameter: $"Table[{tableIndex}] Column[{columnIndex}]")
            }.Where(validation => validation.Rule.Condition is true);
        }

        private static void ValidateTableInformations(
            List<TableInformation> tableInformations)
        {
            Validate(
                tableInformations.SelectMany((tableInformation, index) =>
                    ValidateTableInformation(tableInformation, index)).ToArray());
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

                _ => ValidateTableInformationProperties(tableInformation, index)
            };
        }

        private static IEnumerable<(dynamic, string)> ValidateTableInformationProperties(
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

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidAIProcessingException =
                new InvalidAIProcessingException();

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

    }


}
