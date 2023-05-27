using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.Business.DTO.Share
{
    public class CustomerShareUpdateDto
    {
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public int CustoemerId { get; set; }
    }
}
