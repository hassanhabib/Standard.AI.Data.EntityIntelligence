// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas;
using Standard.AI.Data.EntityIntelligence.Models.Processings.Datas.Exceptions;
using Standard.AI.Data.EntityIntelligence.Services.Foundations.Datas;

namespace Standard.AI.Data.EntityIntelligence.Services.Processings.Datas
{
    internal partial class DataProcessingService : IDataProcessingService
    {
        private delegate ValueTask<DataResult> ReturningDataFunction();
        private async ValueTask<DataResult> TryCatch(ReturningDataFunction returningDataFunction)
        {
            try
            {
                return await returningDataFunction();
            }
            catch (InvalidQueryDataProcessingException invalidQueryDataProcessingException)
            {
                throw new DataProcessingValidationException(invalidQueryDataProcessingException);
            }
        }

    }
}
