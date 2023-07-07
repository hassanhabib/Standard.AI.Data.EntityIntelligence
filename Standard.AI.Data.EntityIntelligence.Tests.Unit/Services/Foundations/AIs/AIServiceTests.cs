// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using KellermanSoftware.CompareNetObjects;
using Moq;
using Standard.AI.Data.EntityIntelligence.Brokers.AIs;
using Standard.AI.Data.EntityIntelligence.Services.Foundations.AIs;
using Standard.AI.OpenAI.Models.Services.Foundations.Completions;
using Tynamix.ObjectFiller;

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
