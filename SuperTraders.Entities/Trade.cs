using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.Entities
{
    public class Trade
    {

        public int ID  { get; set; }
        public string ShareSymbol { get; set; }
        public bool IsActive { get; set; }
        public int Quantity { get; set; }
        public Position Direction { get; set; }


        public Share Share { get; set; }
        public Portfolio Portfolio { get; set; }

    }


    public enum Position
    {
        Buy = 0,
        Sell = 1,
    }
}
