// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Standard.AI.Data.EntityIntelligence.Brokers.Parsers
{
    internal class SqlParserBroker : ISqlParserBroker
    {
        private readonly TSqlParser parser;

        internal SqlParserBroker(TSqlParser parser) =>
            this.parser = parser;

        public (TSqlFragment Fragment, IList<ParseError> Errors) Parse(string query)
        {
            TSqlFragment fragment =
                parser.Parse(
                    new StringReader(query),
                    out IList<ParseError> errors);

            return (fragment, errors);
        }
    }
}
