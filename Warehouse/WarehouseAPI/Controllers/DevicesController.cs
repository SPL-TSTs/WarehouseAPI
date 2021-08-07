using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Warehouse.Data.Entities;
using Warehouse.Data.Repositories;

namespace WarehouseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevicesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IElectricMeterRepository _electricMeterRepo;
        private readonly IWaterMeterRepository _waterMeterRepo;
        private readonly IGatewayRepository _gatewayRepo;

        public DevicesController(IConfiguration configuration, IElectricMeterRepository electricMeterRepo,
            IWaterMeterRepository waterMeterRepo, IGatewayRepository gatewayRepo)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _electricMeterRepo = electricMeterRepo;
            _gatewayRepo = gatewayRepo;
            _waterMeterRepo = waterMeterRepo;
        }

        public JsonResult Get()
        {
            var n = new ElectricMeterEntity
            {
                FirmwareVersion = "123",
                PartitionKey = "ElectricMeter",
                RowKey = Guid.NewGuid().ToString(),
                SerialNumber = "3333",
                State = "fff"
            };
            var n2 = new WaterMeterEntity
            {
                FirmwareVersion = "12333321",
                PartitionKey = "WaterMeter",
                RowKey = Guid.NewGuid().ToString(),
                SerialNumber = "3333",
                State = "fff"
            };
            _electricMeterRepo.AddAsync(n);
            _waterMeterRepo.AddAsync(n2);
            return new JsonResult("ok");
        }

    }
}
