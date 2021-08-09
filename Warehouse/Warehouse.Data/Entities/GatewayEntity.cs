namespace Warehouse.Data.Entities
{
    public class GatewayEntity : Entity
    {
        public string FirmwareVersion { get; set; }
        public string State { get; set; }
        public string IP { get; set; }
        public int?  Port { get; set; }

        public GatewayEntity()
        {
            PartitionKey = "Gateway";
        }
    }
}
