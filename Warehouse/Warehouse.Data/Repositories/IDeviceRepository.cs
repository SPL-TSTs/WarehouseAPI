using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Data.Entities;

namespace Warehouse.Data.Repositories
{
    public interface IDeviceRepository<TEntity> where TEntity : IEntity
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(string partitionKey, string rowKey);
        IEnumerable<TEntity> GetListAsync(string partitionKey);
        Task DeleteByIdAsync(string partitionKey, string rowKey);
        Task<TEntity> UpdateAsync(TEntity entity);

    }
}
