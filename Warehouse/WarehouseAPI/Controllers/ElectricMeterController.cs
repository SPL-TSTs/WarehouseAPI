using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Post([FromBody] ElectricMeterModel device)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
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
            var t = new OkObjectResult(_electricMeterService.GetAll());
            return new OkObjectResult(_electricMeterService.GetAll());
        }

    }
}
