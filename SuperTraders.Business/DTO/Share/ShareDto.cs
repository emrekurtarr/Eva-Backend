using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.Business.DTO.Share
{
    public class ShareDto
    {
        public string Symbol { get; set; }
        public decimal Price { get; set; }

    }
}
