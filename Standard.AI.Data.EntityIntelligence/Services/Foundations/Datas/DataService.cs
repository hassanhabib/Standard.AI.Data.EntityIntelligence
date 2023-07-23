using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Brokers.Datas;
using Standard.AI.Data.EntityIntelligence.Models.Datas.Services;

namespace Standard.AI.Data.EntityIntelligence.Services.Foundations.Datas
{
    internal class DataService : IDataService
    {
        private readonly IDataBroker dataBroker;

        public DataService(IDataBroker dataBroker) => 
            this.dataBroker = dataBroker;

        public ValueTask<List<TableMetadata>> RetrieveTablesDetailsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
