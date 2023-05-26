using SuperTraders.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperTraders.Entities
{
    public class Portfolio : BaseEntity
    {
        public int PortfolioId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Trade> Trades { get; set; }
    }
}
