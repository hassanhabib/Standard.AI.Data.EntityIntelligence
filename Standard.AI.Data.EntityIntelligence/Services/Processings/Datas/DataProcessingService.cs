// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas;
using Standard.AI.Data.EntityIntelligence.Services.Foundations.Datas;

namespace Standard.AI.Data.EntityIntelligence.Services.Processings.Datas
{
    internal partial class DataProcessingService : IDataProcessingService
    {
        private readonly IDataService dataService;

        public DataProcessingService(IDataService dataService) =>
            this.dataService = dataService;

        public async ValueTask<DataResult> RetrieveDataAsync(string query) =>
            await this.dataService.RetrieveDataAsync(query);
    }
}
