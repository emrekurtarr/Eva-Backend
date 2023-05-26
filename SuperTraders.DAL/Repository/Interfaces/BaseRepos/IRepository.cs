
using SuperTraders.Entities.Base;
using System.Linq.Expressions;

namespace SuperTraders.DAL.Repository.Interfaces.BaseRepos
{
    public interface IRepository<T> where T : BaseEntity 
    {
        T Add(T entity);
        T Update(T entity);
        long Delete(string id);
        T Get(Expression<Func<T, bool>> predicate);
        List<T> GetAll(Expression<Func<T, bool>>? predicate = null);
    }
}
