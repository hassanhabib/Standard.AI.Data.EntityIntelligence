﻿// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Models.Datas;
using Standard.AI.Data.EntityIntelligence.Models.Datas.Services;

namespace Standard.AI.Data.EntityIntelligence.Services.Foundations.Datas.TableMetadatas
{
    internal interface IDataInformationService
    {
        ValueTask<IEnumerable<TableInformation>> RetrieveTableInformationsAsync();
    }
}
