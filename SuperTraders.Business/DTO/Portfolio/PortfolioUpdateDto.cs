using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SuperTraders.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.Business.DTO.Portfolio
{
    public class PortfolioUpdateDto
    {
        public int PortfolioId { get; set; }
        public decimal Balance { get; set; }
        public int CustomerId { get; set; }
        
    }
}
