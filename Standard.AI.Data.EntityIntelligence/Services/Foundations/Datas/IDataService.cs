﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Models.Datas.Services;

namespace Standard.AI.Data.EntityIntelligence.Services.Foundations.Datas
{
    internal interface IDataService
    {
        ValueTask<List<TableMetadata>> RetrieveTablesDetailsAsync(); 
    }
}
