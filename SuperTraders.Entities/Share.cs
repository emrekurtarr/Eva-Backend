using SuperTraders.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperTraders.Entities
{
    public class Share : BaseEntity
    {

        public string Symbol { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }


    }
}
