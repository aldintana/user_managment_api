using System.Threading.Tasks;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IBaseService<T, TSearch, TInsert, TUpdate> where T : class where TSearch : class where TInsert : class where TUpdate : class
    {
        Task<T> DeleteAsync(int id);
        Task<IEnumerable<T>> GetAsync(TSearch search = null);
        Task<T> GetByIdAsync(int id);
        Task<T> InsertAsync(TInsert request);
        Task<T> UpdateAsync(int id, TUpdate request);
    }
}
