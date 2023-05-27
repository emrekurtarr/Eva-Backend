using AutoMapper;
using SuperTraders.Business.DTO.Portfolio;
using SuperTraders.Business.DTO.Share;
using SuperTraders.Business.DTO.Trade;
using SuperTraders.Entities;

namespace SuperTraders.Business.Infrastructure
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {

            // For Share entity
            CreateMap<Share, ShareDto>().ReverseMap();


            // For Portfolio entity
            CreateMap<Portfolio, PortfolioUpdateDto>().ReverseMap();
            //CreateMap<Customer, PortfolioUpdateDto.CustomerDto>();
            CreateMap<Portfolio, PortfolioDto>().ReverseMap();
            CreateMap<PortfolioDto, PortfolioUpdateDto>().ReverseMap();

            // For Trade enitity
            CreateMap<Trade, TradeCreateDto>().ReverseMap();
        }
    }
}
