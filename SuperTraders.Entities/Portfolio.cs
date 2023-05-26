using SuperTraders.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperTraders.Entities
{
    public class Portfolio : BaseEntity
    {
        public int ID { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Trade> Trades { get; set; }
    }
}
