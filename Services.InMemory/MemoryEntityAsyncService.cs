using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.InMemory
{
    internal class MemoryEntityAsyncService<T> : MemoryEntityService<T>, IEntityAsyncService<T> where T : Entity
    {
        public Task CreateAsync(T entity)
        {
            return Task.Run(() => Create(entity));
        }

        public Task<bool> DeleteAsync(int id)
        {
            return Task.Run(() => Delete(id));
        }

        public Task<T?> ReadAsync(int id)
        {
            return Task.Run(() => Read(id));
        }

        public Task<List<T>> ReadAsync()
        {
            return Task.Run(() => Read());
        }

        public Task<bool> UpdateAsync(int id, T entity)
        {
            return Task.Run(() => Update(id, entity));
        }
    }
}
