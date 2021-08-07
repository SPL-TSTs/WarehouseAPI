using Warehouse.Data.Contexts;
using Warehouse.Data.Entities;

namespace Warehouse.Data.Repositories
{
    public class ElectricMeterRepository : DeviceRepository<ElectricMeterEntity>, IElectricMeterRepository
    {
        public ElectricMeterRepository(DbContext context) : base("Meters", context)
        {
        }
    }
}
