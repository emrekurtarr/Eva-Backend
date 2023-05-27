using SuperTraders.Entities.Base;
using System.Linq.Expressions;

namespace SuperTraders.DAL.Repository.Interfaces.EntityFramework.BaseRepos
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity);
        Task<int> DeleteAsync(T entity);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetAsyncAsNoTracking(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null);
    }
}
