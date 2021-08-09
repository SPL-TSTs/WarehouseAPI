using System.Collections.Generic;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Extensions.Configuration;

namespace Warehouse.Data.Contexts
{
    public class DbContext
    {
        private readonly CloudTableClient _tableClient;
        private readonly Dictionary<string, CloudTable> _tableClients = new Dictionary<string, CloudTable>();
        private static readonly object _lock = new object();
        
        public DbContext(IConfiguration configure)
        {
            var connString = configure.GetSection("AzureConnectionString").Value;
            var storageAccountClient = CloudStorageAccount.Parse(connString);
            _tableClient = storageAccountClient.CreateCloudTableClient(new TableClientConfiguration());
        }

        public CloudTable GetTable(string tableName)
        {
            if (_tableClients.TryGetValue(tableName, out var table))
            {
                return table;
            }

            lock (_lock)
            {
                if (_tableClients.TryGetValue(tableName, out table))
                {
                    return table;
                }
                table = _tableClient.GetTableReference(tableName);
                table.CreateIfNotExists();
                _ = _tableClients.TryAdd(tableName, table);
                return table;
            }
        }
    }
}
