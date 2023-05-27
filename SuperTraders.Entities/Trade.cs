using SuperTraders.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperTraders.Entities
{
    public class Trade : BaseEntity
    {

        public int ID  { get; set; }
        [ForeignKey("Share")]
        public string ShareSymbol { get; set; }
        public bool IsActive { get; set; }
        public int Quantity { get; set; }
        public Position Direction { get; set; }
        public int PortfolioId { get; set; }
        public Share Share { get; set; }
        public Portfolio Portfolio { get; set; }

    }

    public enum Position
    {
        Buy = 1,
        Sell = 2,
    }
}
