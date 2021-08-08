using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Business.Enums;
using Warehouse.Business.Models;
using Warehouse.Business.Services;

namespace WarehouseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WaterMeterController : ControllerBase
    {
        private readonly IWaterMeterService _WaterMeterService;

        public WaterMeterController(IWaterMeterService service)
        {
            _WaterMeterService = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Device device)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (device.Type != DeviceTypes.WaterMeter)
            {
                return BadRequest($"Device type is not valid : {device.Type.ToString()}");
            }

            if (await _WaterMeterService.ExistDeviceAsync(device))
            {
                return Conflict();
            }

            var result = await _WaterMeterService.AddDeviceAsync(device);

            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new OkObjectResult(_WaterMeterService.GetAll());
        }

    }
}
