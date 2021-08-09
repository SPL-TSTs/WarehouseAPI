using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Business.Models;

namespace Warehouse.Business.Services
{
    public interface IWaterMeterService
    {
        public Task<bool> ExistDeviceAsync(WaterMeterModel device);
        public Task<WaterMeterModel> AddDeviceAsync(WaterMeterModel device);
        public IEnumerable<WaterMeterModel> GetAll();
    }
}
