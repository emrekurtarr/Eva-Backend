using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperTraders.Entities;

namespace SuperTraders.DAL.DataSeed.Configurations
{
    public class TradeConfiguration : IEntityTypeConfiguration<Trade>
    {
        public void Configure(EntityTypeBuilder<Trade> builder)
        {
            builder.HasOne(e => e.Portfolio).WithMany(c => c.Trades).HasForeignKey(e => e.PortfolioId);
            builder.HasOne(e => e.Share).WithMany(c => c.Trades).HasForeignKey(e => e.ShareSymbol);

            builder.HasData(
                new Trade
                {
                    ID = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Direction = Position.Buy,
                    PortfolioId = 1,
                    IsActive = true,
                    ShareSymbol = "ATP",
                    Quantity = 2,
                },
                new Trade
                {
                    ID = 2,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Direction = Position.Buy,
                    PortfolioId = 2,
                    IsActive = true,
                    ShareSymbol = "ATP",
                    Quantity = 3,
                },
                new Trade
                {
                    ID = 3,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Direction = Position.Buy,
                    PortfolioId = 3,
                    IsActive = true,
                    ShareSymbol = "EKG",
                    Quantity = 4,
                },
                new Trade
                {
                    ID = 4,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Direction = Position.Buy,
                    PortfolioId = 4,
                    IsActive = true,
                    ShareSymbol = "EKG",
                    Quantity = 2,
                },
                new Trade
                {
                    ID = 5,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Direction = Position.Buy,
                    PortfolioId = 5,
                    IsActive = true,
                    ShareSymbol = "SIS",
                    Quantity = 1,
                }


                );

        }
    }
}
