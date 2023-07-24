using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions
{
    internal class DataServiceException : Xeption
    {
        public DataServiceException(Xeption innerException)
           : base(message: "Data service error occurred, contact support.",
                 innerException)
        { }
    }
}
