using SuperTraders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.Business.DTO.Trade
{
    public class TradeCreateDto
    {
        public string ShareSymbol { get; set; }
        public int Quantity { get; set; }
        public Position Direction { get; set; }
        public int CustomerId { get; set; }
    }
}
