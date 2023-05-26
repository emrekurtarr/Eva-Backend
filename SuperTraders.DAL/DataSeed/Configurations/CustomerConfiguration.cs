using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperTraders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.DAL.DataSeed.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasOne(x => x.Portfolio).WithOne(y => y.Customer).HasForeignKey<Portfolio>(z => z.CustomerId);

            builder.HasData(
                new Customer
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    FullName = "Emre Kurtar",
                    CustomerId = 1,
                    PortfolioId = 1
                },
                new Customer
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    FullName = "Can Avsar",
                    CustomerId = 2,
                    PortfolioId = 2
                },
                new Customer
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    FullName = "Ugur Evren",
                    CustomerId = 3,
                    PortfolioId = 3
                },
                new Customer
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    FullName = "Kemal Kilicdaroglu",
                    CustomerId = 4,
                    PortfolioId = 4
                },
                new Customer
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    FullName = "Tayyip Erdogan",
                    CustomerId = 5,
                    PortfolioId = 5
                }
            );
        }
    }
}
