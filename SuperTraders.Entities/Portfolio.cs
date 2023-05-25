using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.Entities
{
    public class Portfolio
    {
        public int ID { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }
        public Customer Customer { get; set; }
        public List<Trade> Trades { get; set; }
    }
}
