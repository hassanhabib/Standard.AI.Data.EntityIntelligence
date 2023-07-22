// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Standard.AI.Data.EntityIntelligence.Brokers.Datas
{
    public interface IDataBroker
    {
        ValueTask<IEnumerable<T>> ExecuteQuery<T>(string query);
    }
}