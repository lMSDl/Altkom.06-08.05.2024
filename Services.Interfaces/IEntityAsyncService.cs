using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IEntityAsyncService<T>
    {
        Task CreateAsync(T entity);
        Task<T?> ReadAsync(int id);
        Task<List<T>> ReadAsync();
        Task<bool> UpdateAsync(int id, T entity);
        Task<bool> DeleteAsync(int id);
    }
}
