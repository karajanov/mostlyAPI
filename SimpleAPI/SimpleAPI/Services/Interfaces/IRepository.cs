using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleAPI.Services.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task InsertAsync(T obj);
        Task UpdateAsync(T obj);
        Task DeleteAsync(object id);
        Task SaveAsync();
    }
}
