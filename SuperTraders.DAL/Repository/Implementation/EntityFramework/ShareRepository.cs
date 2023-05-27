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
    public class ShareRepository : GenericBaseEFRepository<Share>, IShareRepository
    {
        //This repository is created for if we have need extra functionality 

        private readonly DbSet<Share> _shareTable;
        public ShareRepository(EFDbContext context): base(context)
        {
            _shareTable = _dbContext.Set<Share>();
        }

        public async Task<Share> GetWithRelatedDataAsync(Expression<Func<Share, bool>> predicate)
        {
            return await _shareTable.Include(x => x.Trades).AsNoTracking().Where(predicate).FirstOrDefaultAsync();

        }
    }
}
