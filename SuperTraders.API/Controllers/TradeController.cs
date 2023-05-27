using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.CustomControllerBase;
using SuperTraders.Business.DTO.Trade;
using SuperTraders.Business.Interfaces;

namespace SuperTraders.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradeController : CustomBaseController
    {
        private readonly ITradeService _tradeService;

        public TradeController(ITradeService tradeService)
        {
            _tradeService = tradeService;
        }

        [HttpPost]
        public async Task<IActionResult> Trade(TradeCreateDto tradeDto)
        {
            var response = await _tradeService.Trade(tradeDto);

            return CreateActionResultInstance(response);
        }

    }
}
