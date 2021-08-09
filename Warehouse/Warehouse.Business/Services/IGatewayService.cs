using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Business.Models;

namespace Warehouse.Business.Services
{
    public interface IGatewayService
    {
        public Task<bool> ExistDeviceAsync(GatewayModel device);
        public Task<GatewayModel> AddDeviceAsync(GatewayModel device);
        public IEnumerable<GatewayModel> GetAll();
    }
}
