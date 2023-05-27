using FluentValidation;
using SuperTraders.Business.Constant.Messages;
using SuperTraders.Business.DTO.Trade;

namespace SuperTraders.Business.Validations.Trade
{
    public class TradeCreateDtoValidator : AbstractValidator<TradeCreateDto>
    {
        public TradeCreateDtoValidator()
        {
            RuleFor(x => x.ShareSymbol.Length == 3).NotEmpty().WithMessage(ShareMessages.SymbolExactlyThreeChars);
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage(CustomerMessage.CustomerIdRequired);
            RuleFor(x => x.Quantity).NotEmpty().WithMessage(ShareMessages.QuantityIsRequired);
            RuleFor(x => x.Direction).NotEmpty().WithMessage(TradeMessage.DirectionIsRequired);

        }
    }
}
