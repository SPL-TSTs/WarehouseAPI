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
    public class ElectricMeterController : ControllerBase
    {
        private readonly IElectricMeterService _electricMeterService;

        public ElectricMeterController(IElectricMeterService service)
        {
            _electricMeterService = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Device device)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (device.Type != DeviceTypes.ElectricMeter)
            {
                return BadRequest($"Device type is not valid : {device.Type.ToString()}");
            }

            if (await _electricMeterService.ExistDeviceAsync(device))
            {
                return Conflict();
            }

            var result = await _electricMeterService.AddDeviceAsync(device);

            return Created("",result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new OkObjectResult(_electricMeterService.GetAll());
        }

    }
}
