using System;
using System.ComponentModel.DataAnnotations;
using Warehouse.Business.Enums;
using Warehouse.Business.Helpers;

namespace Warehouse.Business.Models
{
    public class Device
    {
        [ValidEnumValue]
        public DeviceTypes Type { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        public string FirmwareVersion { get; set; }
        public string State { get; set; }
        public string IP { get; set; }
        public int? Port { get; set; }
        public Guid? Id { get; }
    }
}
