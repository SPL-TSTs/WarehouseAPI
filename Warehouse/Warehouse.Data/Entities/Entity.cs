using Microsoft.Azure.Cosmos.Table;

namespace Warehouse.Data.Entities
{
    public abstract class Entity : TableEntity, IEntity
    {
        public string SerialNumber { get; set; }
    }
}
