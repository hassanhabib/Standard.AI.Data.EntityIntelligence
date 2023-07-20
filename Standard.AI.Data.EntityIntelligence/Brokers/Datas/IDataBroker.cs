// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Models.Datas;

namespace Standard.AI.Data.EntityIntelligence.Brokers.Datas
{
    public interface IDataBroker
    {
        Task<IEnumerable<TableColumnMetadata>> SelectSqlTablesMetadataAsync();
    }
}