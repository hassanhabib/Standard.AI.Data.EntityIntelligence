// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Collections.Generic;

namespace Standard.AI.Data.EntityIntelligence.Brokers.Datas.Parsers
{
    internal interface ISqlParserBroker
    {
        (TSqlFragment Fragment, IList<ParseError> Errors) Parse(string query);
    }
}
