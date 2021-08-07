using Warehouse.Data.Contexts;
using Warehouse.Data.Entities;

namespace Warehouse.Data.Repositories
{
    public class GatewayRepository : DeviceRepository<GatewayEntity>, IGatewayRepository
    {
        public GatewayRepository(DbContext context) : base("Gateway", context)
        {
        }
    }
}
