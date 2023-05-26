using SuperTraders.DAL.Repository.Interfaces.BaseRepos;
using SuperTraders.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.DAL.Repository.Implementation.EntityFramework
{
    public class GenericBaseEFRepository<T> : IRepository<T>, IAsyncRepository<T> where T : BaseEntity
    {
        public T Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public long Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<long> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll(Expression<Func<T, bool>>? predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
