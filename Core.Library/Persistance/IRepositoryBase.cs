using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Library.Persistance
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IEnumerable<T>> FindAllAsync();
        Task<IEnumerable<T>> FindSpecifiedAmount(int? count);
        Task<T> GetDetailsAsync(int? id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAsync();
    }
}
