using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.Entities
{
    public class Customer
    {
        public int ID { get; set; }
        public string FullName { get; set; }

        public Portfolio Portfolio { get; set; }
    }
}
