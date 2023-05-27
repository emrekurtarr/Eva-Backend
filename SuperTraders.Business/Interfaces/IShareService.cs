using Shared;
using SuperTraders.Business.DTO.Share;
using SuperTraders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.Business.Interfaces
{
    public interface IShareService : IServiceBase
    {
        Task<Response<NoContent>> Update(ShareUpdateDto shareDto);
        Task<Response<ShareDto>> GetShareAsync(string symbol);

        Task<Response<NoContent>> GetShareUpdateWithCustomer(CustomerShareUpdateDto customerShareUpdateDto);
    }
}
