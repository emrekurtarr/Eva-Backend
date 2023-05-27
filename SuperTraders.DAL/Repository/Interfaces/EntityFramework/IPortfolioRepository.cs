using SuperTraders.DAL.Repository.Interfaces.EntityFramework.BaseRepos;
using SuperTraders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.DAL.Repository.Interfaces.EntityFramework
{
    public interface IPortfolioRepository : IRepository<Portfolio>,IAsyncRepository<Portfolio>
    {

    }
}
