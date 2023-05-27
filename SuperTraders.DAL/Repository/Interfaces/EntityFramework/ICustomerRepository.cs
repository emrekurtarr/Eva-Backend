using SuperTraders.DAL.Repository.Interfaces.EntityFramework.BaseRepos;
using SuperTraders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.DAL.Repository.Interfaces.EntityFramework
{
    public interface ICustomerRepository : IRepository<Customer>,IAsyncRepository<Customer>
    {
        Task<Customer> GetWithRelatedDataAsync(Expression<Func<Customer, bool>> predicate);
    }
}
