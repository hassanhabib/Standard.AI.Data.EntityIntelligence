// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Standard.AI.Data.EntityIntelligence.Models.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Standard.AI.Data.EntityIntelligence.Brokers.DataStorages
{
    public interface IDataBroker
    {
        Task<IEnumerable<TableColumnMetadata>> SelectSqlTablesMetadataAsync();
    }
}