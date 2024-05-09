using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmaguciaiDomain.Entities;

namespace SmaguciaiInfrastructure.Data.Configurations;

public class OrderProductConfiguration : IEntityTypeConfiguration<OrderPorduct>
{
    public void Configure(EntityTypeBuilder<OrderPorduct> builder)
    {
        builder
            .HasOne(o => o.Order)
            .WithMany(o => o.OrderPorducts)
            .HasForeignKey(o => o.OrderId);
        builder
            .HasOne(o => o.Product)
            .WithMany(o => o.OrderPorducts)
            .HasForeignKey(o => o.ProductId);
    }
}