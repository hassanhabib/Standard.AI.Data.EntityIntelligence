// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.TableMetadatas;

namespace Standard.AI.Data.EntityIntelligence.Services.Foundations.TableMetadatas
{
    internal interface IDataInformationService
    {
        ValueTask<IEnumerable<TableInformation>> RetrieveTableInformationsAsync();
    }
}
