using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SuperTraders.Entities;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Reflection.Emit;

namespace SuperTraders.DAL.DataSeed.Configurations
{
    public class ShareConfiguration : IEntityTypeConfiguration<Share>
    {
        public void Configure(EntityTypeBuilder<Share> builder)
        {
            builder.HasKey("Symbol");
            builder.Property("Symbol").HasColumnType("char(3)");
            builder.Property("Price").HasColumnType("decimal(18,2)");
            builder.HasMany(c => c.Trades).WithOne(e => e.Share);

            builder.HasData(
                new Share
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Price = 5,
                    Symbol = "ATP",
                },
                new Share
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Price = 10,
                    Symbol = "EKG",
                },
                new Share
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Price = 15,
                    Symbol = "SIS",
                }

            );



        }
    }
}
