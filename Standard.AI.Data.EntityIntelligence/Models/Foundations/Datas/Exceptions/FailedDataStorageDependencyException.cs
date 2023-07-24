using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions
{
    internal class FailedDataStorageDependencyException : Xeption
    {
        public FailedDataStorageDependencyException(Exception innerException)
            : base(message: "Failed data storage dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
