using System;
using Microsoft.Azure.Cosmos.Table;

namespace Warehouse.Data.Entities
{
    public abstract class Entity : TableEntity, IEntity
    {
        public string Id { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
