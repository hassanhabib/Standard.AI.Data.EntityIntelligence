using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Standard.AI.Data.EntityIntelligence.Models.Datas.Services;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.AIs.Exceptions;
using Standard.AI.Data.EntityIntelligence.Models.Foundations.Datas.Exceptions;

namespace Standard.AI.Data.EntityIntelligence.Services.Foundations.Datas
{
    internal partial class DataService : IDataService
    {
        private delegate ValueTask<List<TableMetadata>> ReturningFunction();

        private static async ValueTask<List<TableMetadata>> TryCatch(ReturningFunction returningFuction)
        {
            try
            {
                return await returningFuction();
            }
            catch (SqlException sqlException)
            {
                var failedDataStorageDependencyException = 
                    new FailedDataStorageDependencyException(sqlException);

                throw new DataStorageDependencyException(failedDataStorageDependencyException);
            }
            catch (Exception exception) 
            {
                var failedDataServiceException = 
                    new FailedDataServiceException(exception);

                throw new DataServiceException(failedDataServiceException);
            }
        }
    }
}
