using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Business.Models;
using Warehouse.Business.Services;

namespace WarehouseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GatewayController : ControllerBase
    {
        private readonly IGatewayService _gatewayService;

        public GatewayController(IGatewayService service)
        {
            _gatewayService = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GatewayModel device)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (await _gatewayService.ExistDeviceAsync(device))
            {
                return Conflict();
            }

            var result = await _gatewayService.AddDeviceAsync(device);

            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new OkObjectResult(_gatewayService.GetAll());
        }

    }
}