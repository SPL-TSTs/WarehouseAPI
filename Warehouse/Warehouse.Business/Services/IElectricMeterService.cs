using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Business.Models;

namespace Warehouse.Business.Services
{
    public interface IElectricMeterService
    {
        public Task<bool> ExistDeviceAsync(Device device);
        public Task<ElectricMeterModel> AddDeviceAsync(Device device);
        public IEnumerable<ElectricMeterModel> GetAll();
    }
}
