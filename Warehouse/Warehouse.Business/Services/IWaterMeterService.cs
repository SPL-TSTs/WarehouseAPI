using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Business.Models;

namespace Warehouse.Business.Services
{
    public interface IWaterMeterService
    {
        public Task<bool> ExistDeviceAsync(Device device);
        public Task<WaterMeterModel> AddDeviceAsync(Device device);
        public IEnumerable<WaterMeterModel> GetAll();
    }
}
