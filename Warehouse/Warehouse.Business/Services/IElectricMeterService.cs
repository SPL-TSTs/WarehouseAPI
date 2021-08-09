using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Business.Models;

namespace Warehouse.Business.Services
{
    public interface IElectricMeterService
    {
        public Task<bool> ExistDeviceAsync(ElectricMeterModel device);
        public Task<ElectricMeterModel> AddDeviceAsync(ElectricMeterModel device);
        public IEnumerable<ElectricMeterModel> GetAll();
    }
}
