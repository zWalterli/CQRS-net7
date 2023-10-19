using System.Linq.Expressions;

namespace CQRS.Infrastructure.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> ListAsync(Func<T, bool> predicate);
        Task<List<T>> ListAsync(Func<T, bool> predicate, params Expression<Func<T, Object>>[] includes);
        Task<List<T>> ListAsync(int page, int pageSize, params Expression<Func<T, Object>>[] includes);
        Task<List<T>> ListAsync(Func<T, bool> predicate, int page, int pageSize, params Expression<Func<T, Object>>[] includes);
        Task<T> AddAsync(T model);
        Task<List<T>> AddAsync(List<T> models);
        Task<T> UpdateAsync(T model);
        Task<List<T>> UpdateAsync(List<T> models);
        Task RemoveAsync(T model);
        Task RemoveAsync(List<T> models);
    }
}
