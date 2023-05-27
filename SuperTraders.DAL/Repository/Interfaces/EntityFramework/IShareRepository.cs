using SuperTraders.DAL.Repository.Interfaces.EntityFramework.BaseRepos;
using SuperTraders.Entities;
using System.Linq.Expressions;

namespace SuperTraders.DAL.Repository.Interfaces.EntityFramework
{
    public interface IShareRepository : IRepository<Share>, IAsyncRepository<Share>
    {
        Task<Share> GetWithRelatedDataAsync(Expression<Func<Share, bool>> predicate);
    }
}
