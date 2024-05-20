using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmaguciaiDomain.Entities;

namespace SmaguciaiInfrastructure.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder
            .HasOne(o => o.User)
            .WithMany(u => u.Order)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.NoAction);
        builder
            .HasOne(o => o.DiscountCode)
            .WithOne(d => d.Order)
            .HasForeignKey<Order>(o => o.DiscountcodeId);
        builder
            .HasOne(o => o.Route)
            .WithMany(d => d.Orders)
            .HasForeignKey(o => o.RouteId);
    }
}