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
    public class TradeRepository : GenericBaseEFRepository<Trade>, ITradeRepository
    {
        //This repository is created for if we have need extra functionality 

        private readonly DbSet<Trade> _tradeTable;

        public TradeRepository(EFDbContext context) : base(context)
        {
            _tradeTable = _dbContext.Set<Trade>();
        }

        
    }
}
