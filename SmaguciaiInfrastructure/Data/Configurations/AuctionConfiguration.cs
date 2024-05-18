using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmaguciaiDomain.Entities;

namespace SmaguciaiInfrastructure.Data.Configurations;

public class AuctionConfiguration: IEntityTypeConfiguration<Auction>
{
    public void Configure(EntityTypeBuilder<Auction> builder)
    {
    }
}
