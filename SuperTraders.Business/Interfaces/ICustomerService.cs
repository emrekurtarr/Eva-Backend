using Shared;
using SuperTraders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.Business.Interfaces
{
    public interface ICustomerService : IServiceBase
    {
        Task<Response<NoContent>> HavePortfolio(int customerId);
    }
}
