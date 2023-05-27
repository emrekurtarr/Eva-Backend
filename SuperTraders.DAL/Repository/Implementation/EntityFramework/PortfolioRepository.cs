using SuperTraders.DAL.Repository.Interfaces.EntityFramework;
using SuperTraders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.DAL.Repository.Implementation.EntityFramework
{
    public class PortfolioRepository : GenericBaseEFRepository<Portfolio>,IPortfolioRepository
    {
        //This repository is created for if we have need extra functionality 

        public PortfolioRepository(EFDbContext context) : base(context)
        {

        }
    }
}
