using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions
{
    internal class DataStorageDependencyValidationException : Xeption
    {
        public DataStorageDependencyValidationException(Xeption innerException)
            : base(message: "Data storage validation error occurred, fix the errors and try again.",
                  innerException)
        { }
    }
}
