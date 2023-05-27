using Shared;
using SuperTraders.Business.Constant.Messages;
using SuperTraders.Business.Interfaces;
using SuperTraders.DAL.Repository.Interfaces.EntityFramework;
using SuperTraders.Entities;

namespace SuperTraders.Business.Implementations
{
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Response<NoContent>> HavePortfolio(int customerId)
        {
            Customer customer = await _customerRepository.GetWithRelatedDataAsync(x => x.CustomerId == customerId);

            if (customer.Portfolio == null)
                return Response<NoContent>.Error(CustomerMessage.CustomerHasNotPortfolio, 400);

            return Response<NoContent>.Success(200);
        }

        
    }
}
