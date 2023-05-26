using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperTraders.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Reflection.Emit;

namespace SuperTraders.DAL.DataSeed.Configurations
{
    public class PortfolioConfiguration : IEntityTypeConfiguration<Portfolio>
    {
        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {
            builder.HasOne(x => x.Customer).WithOne(y => y.Portfolio).HasForeignKey<Customer>(z => z.PortfolioId);
            builder.HasMany(c => c.Trades).WithOne(e => e.Portfolio);



            builder.HasData(
                new Portfolio
                {
                    PortfolioId = 1,
                    Balance = 100,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CustomerId = 1,
                },
                new Portfolio
                {
                    PortfolioId = 2,
                    Balance = 90,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CustomerId = 2,
                },
                new Portfolio
                {
                    PortfolioId = 3,
                    Balance = 85,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CustomerId = 3,
                },
                new Portfolio
                {
                    PortfolioId = 4,
                    Balance = 80,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CustomerId = 4,
                },
                new Portfolio
                {
                    PortfolioId = 5,
                    Balance = 75,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CustomerId = 5,
                }

                );
        }
    }
}
