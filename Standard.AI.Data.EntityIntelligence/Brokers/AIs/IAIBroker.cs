// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using Standard.AI.OpenAI.Models.Services.Foundations.Completions;

namespace Standard.AI.Data.EntityIntelligence.Brokers.AIs
{
    internal interface IAIBroker
    {
        ValueTask<Completion> PromptCompletionAsync(Completion completion);
    }
}
