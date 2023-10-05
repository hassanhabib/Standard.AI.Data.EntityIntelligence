using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Processings.AIs.Exceptions
{
    internal class DataProcessingDependencyValidationException : Xeption
    {
        public DataProcessingDependencyValidationException(Xeption innerException)
           : base(message: "Data dependency validation error occurred, fix errors and try again.",
                 innerException)
        { }

        public DataProcessingDependencyValidationException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
