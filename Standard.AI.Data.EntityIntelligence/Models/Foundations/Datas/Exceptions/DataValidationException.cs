using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions
{
    internal class DataValidationException : Xeption
    {
        public DataValidationException(Xeption innerException)
            : base(message: "Data validation error occurred, fix the errors and try again.")
        { }
    }
}
