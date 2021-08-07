using System.Net;
using System.Net.Http;
using Microsoft.Azure.Cosmos.Table;

namespace Warehouse.Data.Helpers
{
    internal static class TableResultExtensions
    {
        internal static void EnsureSuccessResult(this TableResult tableResult)
        {
            switch (tableResult.HttpStatusCode)
            {
                case (int)HttpStatusCode.Created:
                case (int)HttpStatusCode.OK:
                case (int)HttpStatusCode.NoContent:
                    break;
                default:
                    throw new HttpRequestException(
                        $"Table operation failed, returned status code : {tableResult.HttpStatusCode}");
            }
        }
    }
}
