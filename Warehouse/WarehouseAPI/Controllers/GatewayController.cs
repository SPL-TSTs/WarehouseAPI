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
    public class GatewayController : ControllerBase
    {
        private readonly IGatewayService _GatewayService;

        public GatewayController(IGatewayService service)
        {
            _GatewayService = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Device device)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (device.Type != DeviceTypes.Gateway)
            {
                return BadRequest($"Device type is not valid : {device.Type.ToString()}");
            }

            if (await _GatewayService.ExistDeviceAsync(device))
            {
                return Conflict();
            }

            var result = await _GatewayService.AddDeviceAsync(device);

            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new OkObjectResult(_GatewayService.GetAll());
        }

    }
}