// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Standard.AI.Data.EntityIntelligence.Brokers.Parsers
{
    internal interface ISqlParserBroker
    {
        (TSqlFragment Fragment, IList<ParseError> Errors) Parse(string query);
    }
}
