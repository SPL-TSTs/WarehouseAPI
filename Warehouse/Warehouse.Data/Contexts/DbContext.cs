using Azure.Data.Tables;
using Microsoft.Extensions.Configuration;
using System;

namespace Warehouse.Data
{
    public class DbContext
    {
        public TableServiceClient TableClient { get;}
        
        public DbContext(IConfiguration configure, string section)
        {
            TableClient = new TableServiceClient(
                new Uri("test"),
                new TableSharedKeyCredential("accountName", "storageAccountKey"));
        }
    }
}
