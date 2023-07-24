using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions
{
    internal class FailedDataStorageDependencyValidationException : Xeption
    {
        public FailedDataStorageDependencyValidationException(Exception innerException)
            : base(message: "Data storage validation error occurred, fix the errors and try again.",
                  innerException)
        { }
    }
}
