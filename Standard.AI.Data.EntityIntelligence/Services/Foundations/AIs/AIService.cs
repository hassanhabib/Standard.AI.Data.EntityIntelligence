// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Brokers.AIs;

namespace Standard.AI.Data.EntityIntelligence.Services.Foundations.AIs
{
    internal class AIService : IAIService
    {
        private readonly IAIBroker aiBroker;

        public AIService(IAIBroker aiBroker) =>
            this.aiBroker = aiBroker;

        public ValueTask<string> RetrieveSqlQueryAsync(string naturalQuery)
        {
            throw new NotImplementedException();
        }
    }
}
