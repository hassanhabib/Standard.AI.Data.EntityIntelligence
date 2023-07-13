// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using KellermanSoftware.CompareNetObjects;
using Moq;
using Standard.AI.Data.EntityIntelligence.Brokers.AIs;
using Standard.AI.Data.EntityIntelligence.Services.Foundations.AIs;
using Standard.AI.OpenAI.Models.Clients.Completions.Exceptions;
using Standard.AI.OpenAI.Models.Services.Foundations.Completions;
using Tynamix.ObjectFiller;
using Xeptions;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Foundations.AIs
{
    public partial class AIServiceTests
    {
        private readonly Mock<IAIBroker> aiBrokerMock;
        private readonly IAIService aiService;
        private readonly ICompareLogic compareLogic;

        public AIServiceTests()
        {
            this.aiBrokerMock = new Mock<IAIBroker>();
            this.compareLogic = new CompareLogic();

            this.aiService = new AIService(
                aiBroker: this.aiBrokerMock.Object);
        }

        public static TheoryData AIClientDependencyExceptions()
        {
            var innerAIDependencyException = new Xeption();

            return new TheoryData<Xeption>
            {
                new CompletionClientDependencyException(innerAIDependencyException),
                new CompletionClientServiceException(innerAIDependencyException)
            };
        }

        private static string GetRandomString() => 
            new MnemonicString(wordCount: GetRandomNumber()).GetValue();

        private static int GetRandomNumber() =>
            new IntRange(min: 10, max: 20).GetValue();

        private Expression<Func<Completion, bool>> SameCompletionAs(Completion expectedCompletion)
        {
            return actualCompletion => 
                this.compareLogic.Compare(expectedCompletion, actualCompletion).AreEqual;
        }
    }
}
