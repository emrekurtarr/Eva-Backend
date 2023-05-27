using Shared;
using SuperTraders.Business.DTO.Portfolio;
using SuperTraders.Business.DTO.Trade;
using SuperTraders.Entities;

namespace SuperTraders.Business.Interfaces
{
    public interface IPortfolioService : IServiceBase
    {
        Task<Response<PortfolioDto>> HaveEnoughBalanceToTrade(TradeCreateDto tradeCreateDto);
        Task<Response<NoContent>> Update(Portfolio portfolio);
        Task<Response<PortfolioDto>> GetAsync(int id);

    }
}
