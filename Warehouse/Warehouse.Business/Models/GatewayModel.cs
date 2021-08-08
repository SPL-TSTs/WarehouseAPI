namespace Warehouse.Business.Models
{
    public class GatewayModel : EntityModel
    {
        public string FirmwareVersion { get; set; }
        public string State { get; set; }
        public string IP { get; set; }
        public int? Port { get; set; }
    }
}
