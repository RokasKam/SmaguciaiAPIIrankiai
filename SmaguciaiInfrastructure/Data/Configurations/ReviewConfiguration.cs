using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmaguciaiDomain.Entities;

namespace SmaguciaiInfrastructure.Data.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder
            .HasOne(p => p.Product)
            .WithMany(c => c.Review)
            .HasForeignKey(p => p.ProductID);
        builder
            .HasOne(p => p.User)
            .WithMany(m => m.Review)
            .HasForeignKey(p => p.UserID);
    }

}