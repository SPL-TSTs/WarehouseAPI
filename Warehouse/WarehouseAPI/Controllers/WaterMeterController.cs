using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Business.Models;
using Warehouse.Business.Services;

namespace WarehouseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WaterMeterController : ControllerBase
    {
        private readonly IWaterMeterService _waterMeterService;

        public WaterMeterController(IWaterMeterService service)
        {
            _waterMeterService = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] WaterMeterModel device)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (await _waterMeterService.ExistDeviceAsync(device))
            {
                return Conflict();
            }

            var result = await _waterMeterService.AddDeviceAsync(device);

            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new OkObjectResult(_waterMeterService.GetAll());
        }

    }
}
