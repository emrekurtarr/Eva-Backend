

using Shared;
using SuperTraders.Business.DTO.Trade;

namespace SuperTraders.Business.Interfaces
{
    public interface ITradeService : IServiceBase
    {
        Task<Response<TradeDto>> Trade(TradeCreateDto tradeCreateDto);
    }
}
