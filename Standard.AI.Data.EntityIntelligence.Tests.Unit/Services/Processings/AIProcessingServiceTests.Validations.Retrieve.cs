// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Standard.AI.Data.EntityIntelligence.Models.Datas;
using Standard.AI.Data.EntityIntelligence.Models.Processings.AIs.Exceptions;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Processings
{
    public partial class AIProcessingServiceTests
    {

        [Fact]
        public async Task ShouldThrowNullTableInformationListExceptionOnRetrieveIfTableInformationListIsNullAsync()
        {
            // given
            string randomNaturalQuery = GenerateRandomString();
            string inputNaturalQuery = randomNaturalQuery;
            List<TableInformation> nullTableInformationList = null;
            List<TableInformation> inputTableInformationList = nullTableInformationList;

            var expectedTableInformationListException =
                new NullTableInformationListException();

            // when
            ValueTask<string> retrieveSqlQueryTask =
                this.aiProcessingService.RetrieveSqlQueryAsync(inputTableInformationList, inputNaturalQuery);

            NullTableInformationListException actualTableInformationListException =
                await Assert.ThrowsAsync<NullTableInformationListException>(
                                       retrieveSqlQueryTask.AsTask);

            // then
            actualTableInformationListException.Should().BeEquivalentTo(
                expectedTableInformationListException);

            this.aiServiceMock.Verify(aiService => aiService.PromptQueryAsync(It.IsAny<string>()),
                                   Times.Never);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowInvalidNaturalQueryExceptionOnRetrieveIfNaturalQueryIsNullOrEmptyAsync(string invalidNaturalQuery)
        {
            // given
            string inputNaturalQuery = invalidNaturalQuery;
            var randomTablesData = GenerateRandomTables();
            List<TableInformation> randomTableInformationList =
               randomTablesData.Keys.Select(key =>
               {
                   return new TableInformation
                   {
                       Name = "",
                       Columns = randomTablesData[key].Keys.Select(tableColumnKey =>
                       {
                           return new TableColumn
                           {
                               Name = tableColumnKey,
                               Type = randomTablesData[key][tableColumnKey]
                           };
                       }).ToList()
                   };
               }).ToList();

            List<TableInformation> inputTableInformationList = randomTableInformationList;

            var expectedInvalidAIProcessingQueryException =
                new InvalidAIProcessingException();

            // when
            ValueTask<string> retrieveSqlQueryTask =
                this.aiProcessingService.RetrieveSqlQueryAsync(inputTableInformationList, inputNaturalQuery);

            InvalidAIProcessingException actualTableInformationListException =
                await Assert.ThrowsAsync<InvalidAIProcessingException>(
                                       retrieveSqlQueryTask.AsTask);

            // then
            actualTableInformationListException.Should().BeEquivalentTo(
                expectedInvalidAIProcessingQueryException);

            this.aiServiceMock.Verify(aiService => aiService.PromptQueryAsync(It.IsAny<string>()),
                                   Times.Never);
        }

        [Fact]
        public async Task ShouldThrowInvalidAIProcessingExceptionOnRetrieveIfAnyTableInformationIsNullAsync()
        {
            // given
            string randomNaturalQuery = GenerateRandomString();
            string inputNaturalQuery = randomNaturalQuery;
            var randomTablesData = GenerateRandomTables();
            int randomNullTableIndex = GetRandomNumber(0, randomTablesData.Count - 1);

            List<TableInformation> randomTableInformationListWithNullTable =
               randomTablesData.Keys.Select((key, index) =>
               {
                   if (index == randomNullTableIndex)
                   {
                       return null;
                   }
                   else
                   {
                       return new TableInformation
                       {
                           Name = key,
                           Columns = randomTablesData[key].Keys.Select(tableColumnKey =>
                           {
                               return new TableColumn
                               {
                                   Name = tableColumnKey,
                                   Type = randomTablesData[key][tableColumnKey]
                               };
                           }).ToList()
                       };
                   }
               }).ToList();

            List<TableInformation> inputTableInformationList = randomTableInformationListWithNullTable;

            var expectedInvalidAIProcessingException =
                new InvalidAIProcessingException();

            // when
            ValueTask<string> retrieveSqlQueryTask =
                this.aiProcessingService.RetrieveSqlQueryAsync(inputTableInformationList, inputNaturalQuery);

            InvalidAIProcessingException actualAIProcessingException =
                await Assert.ThrowsAsync<InvalidAIProcessingException>(
                                       retrieveSqlQueryTask.AsTask);

            // then
            actualAIProcessingException.Should().BeEquivalentTo(
                expectedInvalidAIProcessingException);

            this.aiServiceMock.Verify(aiService => aiService.PromptQueryAsync(It.IsAny<string>()),
                                   Times.Never);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowInvalidAIProcesingExceptionOnRetrieveIfAnyTableInformationIsInvalidAsync(string invalidTableName)
        {
            // given
            string randomNaturalQuery = GenerateRandomString();
            string inputNaturalQuery = randomNaturalQuery;
            var randomTablesData = GenerateRandomTables();
            int randomInvalidTableIndex = GetRandomNumber(0, randomTablesData.Count - 1);
            IEnumerable<TableColumn> invalidColumns = null;

            List<TableInformation> randomTableInformationListWithInvalidTable =
               randomTablesData.Keys.Select((key, index) =>
               {
                   if (index == randomInvalidTableIndex)
                   {
                       return new TableInformation
                       {
                           Name = invalidTableName,
                           Columns = invalidColumns
                       };
                   }
                   else
                   {
                       return new TableInformation
                       {
                           Name = key,
                           Columns = randomTablesData[key].Keys.Select(tableColumnKey =>
                           {
                               return new TableColumn
                               {
                                   Name = tableColumnKey,
                                   Type = randomTablesData[key][tableColumnKey]
                               };
                           }).ToList()
                       };
                   }
               }).ToList();

            List<TableInformation> inputTableInformationList = randomTableInformationListWithInvalidTable;

            var expectedInvalidAIProcessingException =
                new InvalidAIProcessingException();

            // when
            ValueTask<string> retrieveSqlQueryTask =
                this.aiProcessingService.RetrieveSqlQueryAsync(inputTableInformationList, inputNaturalQuery);

            InvalidAIProcessingException actualAIProcessingException =
                await Assert.ThrowsAsync<InvalidAIProcessingException>(
                                       retrieveSqlQueryTask.AsTask);

            // then
            actualAIProcessingException.Should().BeEquivalentTo(
                expectedInvalidAIProcessingException);

            this.aiServiceMock.Verify(aiService => aiService.PromptQueryAsync(It.IsAny<string>()),
                                   Times.Never);
        }


        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "")]
        [InlineData("", null)]
        [InlineData("", "")]
        [InlineData(" ", " ")]
        public async Task ShouldThrowInvalidAIProcesingExceptionOnRetrieveIfAnyTableColumnsIsInvalidAsync(string invalidColumnName, string invalidColumnType)
        {
            // given
            string randomNaturalQuery = GenerateRandomString();
            string inputNaturalQuery = randomNaturalQuery;
            var randomTablesData = GenerateRandomTables();

            List<TableInformation> randomTableInformationListWithInvalidColumns =
               randomTablesData.Keys.Select((key) =>
               {
                   int randomInvalidColumnIndex = GetRandomNumber(0, randomTablesData[key].Count - 1);

                   return new TableInformation
                   {
                       Name = key,
                       Columns = randomTablesData[key].Keys.Select((tableColumnKey, index) =>
                       {
                           if (index == randomInvalidColumnIndex)
                           {
                               return new TableColumn
                               {
                                   Name = invalidColumnName,
                                   Type = invalidColumnType
                               };
                           }
                           else
                           {
                               return new TableColumn
                               {
                                   Name = tableColumnKey,
                                   Type = randomTablesData[key][tableColumnKey]
                               };
                           }
                       }).ToList()
                   };
               }
               ).ToList();

            List<TableInformation> inputTableInformationList = randomTableInformationListWithInvalidColumns;

            var expectedInvalidAIProcessingException =
                new InvalidAIProcessingException();

            // when
            ValueTask<string> retrieveSqlQueryTask =
                this.aiProcessingService.RetrieveSqlQueryAsync(inputTableInformationList, inputNaturalQuery);

            InvalidAIProcessingException actualAIProcessingException =
                await Assert.ThrowsAsync<InvalidAIProcessingException>(
                                       retrieveSqlQueryTask.AsTask);

            // then
            actualAIProcessingException.Should().BeEquivalentTo(
                expectedInvalidAIProcessingException);

            this.aiServiceMock.Verify(aiService => aiService.PromptQueryAsync(It.IsAny<string>()),
                                   Times.Never);
        }
    }
}
