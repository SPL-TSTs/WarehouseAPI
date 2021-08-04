using Azure.Data.Tables;
using System;
using Azure;

namespace Warehouse.Data.Entities
{
    public abstract class Entity<TKey> : ITableEntity, IEntity<TKey>
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}
