using AutoMapper;
using Shared;
using SuperTraders.Business.Constant.Messages;
using SuperTraders.Business.DTO.Share;
using SuperTraders.Business.Interfaces;
using SuperTraders.DAL.Repository.Interfaces.EntityFramework;
using SuperTraders.Entities;

namespace SuperTraders.Business.Implementations
{
    public class ShareService : IShareService
    {
        private readonly IShareRepository _shareRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public ShareService(IShareRepository shareRepository, ICustomerRepository customerRepository,IMapper mapper)
        {
            _shareRepository = shareRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Response<ShareDto>> GetShareAsync(string symbol)
        {
            Share share = await _shareRepository.GetAsync(x => String.Equals(symbol, x.Symbol));

            if (share == null)
                return Response<ShareDto>.Error(ShareMessages.NotFound, 400);

            return Response<ShareDto>.Success(_mapper.Map<ShareDto>(share), 200);
        }

        public async Task<Response<NoContent>> GetShareUpdateWithCustomer(CustomerShareUpdateDto customerShareUpdateDto)
        {
            Customer existCustomer = await _customerRepository.GetAsyncAsNoTracking(x => x.CustomerId == customerShareUpdateDto.CustoemerId);

            if (existCustomer == null)
                return Response<NoContent>.Error(CustomerMessage.DoesNotExist, 400);

            Share updatedShare = await _shareRepository.GetAsync(x => String.Equals(x.Symbol, customerShareUpdateDto.Symbol));
            updatedShare.Price = customerShareUpdateDto.Price;

            _shareRepository.Update(updatedShare);

            return Response<NoContent>.Success(204);
        }

        public async Task<Response<NoContent>> Update(ShareUpdateDto shareDto)
        {
            Share foundedShare = await _shareRepository.GetAsync(x => String.Equals(shareDto.Symbol,x.Symbol));

            if( foundedShare == null)
            {
                return Response<NoContent>.Error(ShareMessages.NotFound, 404);
            }

            return Response<NoContent>.Success(204);
        }
    }
}
