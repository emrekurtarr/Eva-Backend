using Microsoft.EntityFrameworkCore;
using SuperTraders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.DAL.Repository.Implementation.EntityFramework
{
    public class EFDbContext : DbContext
    {

        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {

        }

        public DbSet<Trade> Trades { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Share> Shares { get; set; }
        public DbSet<Customer> Customers { get; set; }


    }
}
