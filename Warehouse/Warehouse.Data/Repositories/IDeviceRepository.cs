using System.Threading.Tasks;
using Warehouse.Data.Entities;

namespace Warehouse.Data.Repositories
{
    public interface IDeviceRepository<TKey, TEntity> where TEntity : IEntity<TKey>
    {
        Task AddAsync(TEntity entity);
        Task GetByIdAsync(TKey id);
        Task DeleteByIdAsync(TKey id);
        Task UpdateAsync(TEntity entity);

    }
}
