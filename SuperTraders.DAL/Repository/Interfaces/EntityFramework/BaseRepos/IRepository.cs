
using SuperTraders.Entities.Base;
using System.Linq.Expressions;

namespace SuperTraders.DAL.Repository.Interfaces.EntityFramework.BaseRepos
{
    public interface IRepository<T> where T : BaseEntity 
    {
        T Add(T entity);
        T Update(T entity);
        int Delete(T entity);
        T Get(Expression<Func<T, bool>> predicate);
        List<T> GetAll(Expression<Func<T, bool>>? predicate = null);
    }
}
