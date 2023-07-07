// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Models.AIs;
using Standard.AI.OpenAI.Clients.OpenAIs;
using Standard.AI.OpenAI.Models.Configurations;
using Standard.AI.OpenAI.Models.Services.Foundations.Completions;

namespace Standard.AI.Data.EntityIntelligence.Brokers.AIs
{
    internal class AIBroker : IAIBroker
    {
        private readonly AIConfigurations configurations;
        private readonly IOpenAIClient openAIClient;

        public AIBroker(AIConfigurations configurations)
        {
            this.configurations = configurations;
            this.openAIClient = InitializeOpenAIClient();
        }

        public async ValueTask<Completion> PromptCompletionAsync(Completion completion) =>
            await this.openAIClient.Completions.PromptCompletionAsync(completion);

        private IOpenAIClient InitializeOpenAIClient()
        {
            var openAIConfigurations = new OpenAIConfigurations();
            openAIConfigurations.ApiKey = this.configurations.AIApiKey;

            return new OpenAIClient(openAIConfigurations);
        }
    }
}
