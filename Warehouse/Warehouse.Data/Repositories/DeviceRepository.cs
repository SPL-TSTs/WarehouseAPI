using Azure.Data.Tables.Models;
using System;
using System.Threading.Tasks;
using Warehouse.Data.Entities;

namespace Warehouse.Data.Repositories
{
    public abstract class DeviceRepository<TKey, TEntity> : IDeviceRepository<TKey, TEntity> where TEntity : Entity<TKey>, new()
    {
        protected readonly TableItem TableItem;

        protected DeviceRepository(string tableName, DbContext context)
        {
            if (string.IsNullOrEmpty(tableName))
            {
                throw new ArgumentNullException(nameof(tableName));
            }

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            TableItem = context.TableClient.CreateTable(tableName);
        }
        public Task AddAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task GetByIdAsync(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
