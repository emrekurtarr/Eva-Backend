using SuperTraders.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperTraders.Entities
{
    public class Share : BaseEntity
    {
        [Key]
        public string Symbol { get; set; }
        public decimal Price { get; set; }

        public ICollection<Trade> Trades { get; set; }


    }
}
