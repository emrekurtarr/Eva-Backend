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
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.Business.Implementations
{
    public class TradeService : ITradeService
    {
        private readonly ITradeRepository _tradeRepo;
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IShareRepository _shareRepository;
        private readonly ICustomerService _customerService;
        private readonly IPortfolioService _portfolioService;
        private readonly IShareService _shareService;
        private readonly IMapper _mapper;

        public TradeService(ITradeRepository tradeRepo, IPortfolioRepository portfolioRepository, IShareRepository shareRepository, ICustomerService customerService, IPortfolioService portfolioService,IShareService shareService,IMapper mapper)
        {
            _tradeRepo = tradeRepo;
            _portfolioRepository = portfolioRepository;
            _shareRepository = shareRepository; 
            _customerService = customerService;
            _portfolioService = portfolioService;
            _shareService = shareService;
            _mapper = mapper;
        }

        public async Task<Response<TradeDto>> Trade(TradeCreateDto tradeCreateDto)
        {
            #region Customer and portfolio check
            Response<NoContent> customerResponse = await _customerService.HavePortfolio(tradeCreateDto.CustomerId);

            if (!customerResponse.IsSuccessful)
                return Response<TradeDto>.Error(CustomerMessage.CustomerHasNotPortfolio, 400);
            #endregion

            #region Customer has enough balance to trade
            Response<PortfolioDto> portfolioResponse = await _portfolioService.HaveEnoughBalanceToTrade(tradeCreateDto);

            if (!portfolioResponse.IsSuccessful)
                return Response<TradeDto>.Error(portfolioResponse.Errors.Count > 0 ? portfolioResponse.Errors.FirstOrDefault() : PortfolioMessage.SomethingWentWrong, 400);

            Response<ShareDto> shareResponse = await _shareService.GetShareAsync(tradeCreateDto.ShareSymbol);
            ShareDto shareDto = shareResponse.Data;
            #endregion


            switch (tradeCreateDto.Direction)
            {
                case Entities.Position.Buy:

                    Trade addedBuyTrade = _mapper.Map<Trade>(tradeCreateDto);
                    addedBuyTrade.IsActive = false;
                    addedBuyTrade.PortfolioId = portfolioResponse.Data.PortfolioId;
                    addedBuyTrade.CreatedAt = DateTime.Now;
                    addedBuyTrade.UpdatedAt = DateTime.Now;

                    await _tradeRepo.AddAsync(addedBuyTrade);

                    Portfolio updatedPortfolio = await _portfolioRepository.GetAsync(x => x.PortfolioId == portfolioResponse.Data.PortfolioId);
                    updatedPortfolio.Balance -= (tradeCreateDto.Quantity * shareDto.Price);
                    await _portfolioService.Update(updatedPortfolio);

                    break;
                case Entities.Position.Sell:

                    List<Trade> tradesBelongsToCustomer = _tradeRepo.GetAll(x => x.PortfolioId == portfolioResponse.Data.PortfolioId && x.IsActive == true && x.Direction == Position.Buy);
                    tradesBelongsToCustomer = tradesBelongsToCustomer.Where(x => String.Equals(x.ShareSymbol, tradeCreateDto.ShareSymbol)).ToList();
                    bool isExistShareAtCustomerPortfolio = tradesBelongsToCustomer.Any();

                    int numberOfSharesCustomerHas = 0;

                    tradesBelongsToCustomer.ForEach(x => numberOfSharesCustomerHas += x.Quantity);

                    if (!isExistShareAtCustomerPortfolio)
                        return Response<TradeDto>.Error(ShareMessages.DoesNotExistOnCustomerPortfolio, 404);
                    if(numberOfSharesCustomerHas < tradeCreateDto.Quantity)
                        return Response<TradeDto>.Error(ShareMessages.NoEnoughShareToSell, 404);

                    List<Trade> buyTrades = await _tradeRepo.GetListAsync(x => String.Equals(shareDto.Symbol, x.ShareSymbol) && x.IsActive == true && x.Direction == Position.Buy);
                    List<Trade> sellTrades = await _tradeRepo.GetListAsync(x => String.Equals(shareDto.Symbol, x.ShareSymbol) && x.IsActive == true && x.Direction == Position.Sell);

                    long totalSumQuantityOfBuyTrades = 0;
                    buyTrades.ForEach(x => totalSumQuantityOfBuyTrades += x.Quantity);

                    long totalSumQuantityOfSellTrades = 0;
                    sellTrades.ForEach(x => totalSumQuantityOfSellTrades += x.Quantity);

                    long difference = totalSumQuantityOfBuyTrades - totalSumQuantityOfSellTrades;

                    if (difference < 0 || difference < tradeCreateDto.Quantity)
                    {
                        return Response<TradeDto>.Error(TradeMessage.NoEnoughVolume, 400);
                    }


                    Trade addedSellTrade = _mapper.Map<Trade>(tradeCreateDto);
                    addedSellTrade.IsActive = false;
                    addedSellTrade.PortfolioId = portfolioResponse.Data.PortfolioId;
                    addedSellTrade.CreatedAt = DateTime.Now;
                    addedSellTrade.UpdatedAt = DateTime.Now;

                    await _tradeRepo.AddAsync(addedSellTrade);

                    break;
                default:
                    break;
            }

            //It needs refactoring 
            return Response<TradeDto>.Success(200);

        }
    }
}
