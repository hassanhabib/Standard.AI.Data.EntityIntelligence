// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Standard.AI.Data.EntityIntelligence.Models.Datas;
using Standard.AI.Data.EntityIntelligence.Services.Foundations.AIs;

namespace Standard.AI.Data.EntityIntelligence.Services.Processings.AIs
{
    internal partial class AIProcessingService : IAIProcessingService
    {
        private readonly IAIService aiService;

        public AIProcessingService(IAIService aiService) =>
            this.aiService = aiService;

        public ValueTask<string> RetrieveSqlQueryAsync(
            List<TableInformation> tables,
            string naturalQuery)
        {
            throw new NotImplementedException();
        }
    }
}
