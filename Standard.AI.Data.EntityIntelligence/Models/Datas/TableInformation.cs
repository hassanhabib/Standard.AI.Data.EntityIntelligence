// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standard.AI.Data.EntityIntelligence.Models.Datas
{
    internal class TableInformation
    {
        public string Name { get; set; }
        public string Schema { get; set; }
        public IEnumerable<TableColumn> Columns { get; set; }
    }
}
