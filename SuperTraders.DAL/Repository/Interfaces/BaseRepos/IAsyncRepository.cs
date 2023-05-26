using SuperTraders.Entities.Base;
using System.Linq.Expressions;

namespace SuperTraders.DAL.Repository.Interfaces.BaseRepos
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<long> DeleteAsync(string id);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null);
    }
}
