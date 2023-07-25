using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Processings.AIs.Exceptions
{
    internal class InvalidAIProcessingException : Xeption
    {
        public InvalidAIProcessingException()
           : base(message: "Invalid AI Processing Query error occurred, fix the errors and try again.")
        { }
    }
}
