
using AutoMapper;
using Shared;
using SuperTraders.Business.Constant.Messages;
using SuperTraders.Business.DTO.Portfolio;
using SuperTraders.Business.DTO.Share;
using SuperTraders.Business.DTO.Trade;
using SuperTraders.Business.Interfaces;
using SuperTraders.DAL.Repository.Interfaces.EntityFramework;
using SuperTraders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.Business.Implementations
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IShareService _shareService;
        private readonly IMapper _mapper;

        public PortfolioService(IPortfolioRepository portfolioRepository, IShareService shareService, IMapper mapper)
        {
            _portfolioRepository = portfolioRepository;
            _shareService = shareService;
            _mapper = mapper;
        }

        public async Task<Response<PortfolioDto>> GetAsync(int id)
        {
            Portfolio portfolio = await _portfolioRepository.GetAsync(x => x.PortfolioId == id);

            if (portfolio == null)
                return Response<PortfolioDto>.Error(PortfolioMessage.PortfolioDoesNotExist, 404);

            return Response<PortfolioDto>.Success(_mapper.Map<PortfolioDto>(portfolio), 200);
        }

        public async Task<Response<PortfolioDto>> HaveEnoughBalanceToTrade(TradeCreateDto tradeCreateDto)
        {
            Portfolio portfolio = await _portfolioRepository.GetAsyncAsNoTracking(x => x.CustomerId == tradeCreateDto.CustomerId);

            if (portfolio == null)
                return Response<PortfolioDto>.Error(PortfolioMessage.PortfolioDoesNotExist, 400);


            Response<ShareDto> shareResponse = await _shareService.GetShareAsync(tradeCreateDto.ShareSymbol);

            if (!shareResponse.IsSuccessful)
                return Response<PortfolioDto>.Error(shareResponse.Errors.Count > 0 ? shareResponse.Errors.FirstOrDefault() : ShareMessages.NotFound, 404);

            ShareDto shareDto = shareResponse.Data;

            decimal neededMoney = shareDto.Price * tradeCreateDto.Quantity;

            if (neededMoney > portfolio.Balance)
                return Response<PortfolioDto>.Error(PortfolioMessage.DoesNotHaveEnoughBalance, 400);

            return Response<PortfolioDto>.Success(_mapper.Map<PortfolioDto>(portfolio),200);


            
        }

        public async Task<Response<NoContent>> Update(Portfolio portfolio)
        {

            //Portfolio foundedPortfolio = await _portfolioRepository.GetAsync(x => x.PortfolioId == portfolioDto.PortfolioId);

            if(portfolio == null)
            {
                return Response<NoContent>.Error(PortfolioMessage.PortfolioDoesNotExist, 400);
            }

            portfolio.UpdatedAt = DateTime.Now;

            _portfolioRepository.Update(portfolio);

            return Response<NoContent>.Success(204);
        }
    }
}
