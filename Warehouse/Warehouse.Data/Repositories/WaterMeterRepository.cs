using Warehouse.Data.Contexts;
using Warehouse.Data.Entities;

namespace Warehouse.Data.Repositories
{
    public class WaterMeterRepository : DeviceRepository<WaterMeterEntity>, IWaterMeterRepository
    {
        public WaterMeterRepository(DbContext context) : base("Meters", context)
        {
        }
    }
}
