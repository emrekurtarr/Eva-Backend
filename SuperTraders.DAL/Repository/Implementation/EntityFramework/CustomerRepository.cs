using Microsoft.EntityFrameworkCore;
using SuperTraders.DAL.Repository.Interfaces.EntityFramework;
using SuperTraders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.DAL.Repository.Implementation.EntityFramework
{
    public class CustomerRepository : GenericBaseEFRepository<Customer>,ICustomerRepository
    {
        //This repository is created for if we have need extra functionality 

        private readonly DbSet<Customer> _customerTable;
        public CustomerRepository(EFDbContext context) : base(context)
        {
            _customerTable = _dbContext.Set<Customer>();
        }

        public async Task<Customer> GetWithRelatedDataAsync(Expression<Func<Customer, bool>> predicate)
        {
            return await _customerTable.Include(x=>x.Portfolio).AsNoTracking().Where(predicate).FirstOrDefaultAsync();

        }
    }
}
