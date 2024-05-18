using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmaguciaiDomain.Entities;

namespace SmaguciaiInfrastructure.Data.Configurations;

public class BidConfiguration : IEntityTypeConfiguration<Bid>
{
    public void Configure(EntityTypeBuilder<Bid> builder)
    {
        builder
            .HasOne(o => o.Auction)
            .WithMany(o => o.Bids)
            .HasForeignKey(o => o.AuctionId);
        builder
            .HasOne(o => o.User)
            .WithMany(o => o.Bids)
            .HasForeignKey(o => o.UserId);
    }
}