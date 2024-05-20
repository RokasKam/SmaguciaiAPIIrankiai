using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmaguciaiDomain.Entities;

namespace SmaguciaiInfrastructure.Data.Configurations;

public class RouteConfiguration: IEntityTypeConfiguration<Route>
{
    public void Configure(EntityTypeBuilder<Route> builder)
    {
    }
}
