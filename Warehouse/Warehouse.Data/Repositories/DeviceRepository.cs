using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Table;
using Warehouse.Data.Contexts;
using Warehouse.Data.Entities;
using Warehouse.Data.Helpers;

namespace Warehouse.Data.Repositories
{
    public abstract class DeviceRepository<TEntity> : IDeviceRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly CloudTable Repository;

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

            Repository = context.GetTable(tableName);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var insert = TableOperation.Insert(entity);
            var result = await Repository.ExecuteAsync(insert);
            result.EnsureSuccessResult();
            
            return result.Result as TEntity;
        }

        public async Task DeleteByIdAsync(string partitionKey, string rowKey)
        {
            var entity = await GetByIdAsync(partitionKey, rowKey);
            if (entity == null)
            {
                return;
            }
            
            var delete = TableOperation.Delete(entity);
            var result = await Repository.ExecuteAsync(delete);
            result.EnsureSuccessResult();
        }

        public async Task<TEntity> GetByIdAsync(string partitionKey, string rowKey)
        {
            var retrieve = TableOperation.Retrieve<TEntity>(partitionKey, rowKey);
            var result = await Repository.ExecuteAsync(retrieve);
            if (result.HttpStatusCode == (int) HttpStatusCode.NotFound)
            {
                return null;
            }

            result.EnsureSuccessResult();

            return result.Result as TEntity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var replace = TableOperation.Replace(entity);
            var result = await Repository.ExecuteAsync(replace);
            result.EnsureSuccessResult();

            return result.Result as TEntity;
        }
    }
}
