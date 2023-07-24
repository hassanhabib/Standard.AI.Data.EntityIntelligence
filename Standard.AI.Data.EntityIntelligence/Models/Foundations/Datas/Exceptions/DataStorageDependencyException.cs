using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions
{
    internal class DataStorageDependencyException : Xeption
    {
        public DataStorageDependencyException(Xeption innerException)
           : base(message: "Data storage dependency error occurred, contact support.",
                 innerException)
        { }
    }
}
