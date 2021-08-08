using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Business.Models;

namespace Warehouse.Business.Services
{
    public interface IGatewayService
    {
        public Task<bool> ExistDeviceAsync(Device device);
        public Task<GatewayModel> AddDeviceAsync(Device device);
        public IEnumerable<GatewayModel> GetAll();
    }
}
