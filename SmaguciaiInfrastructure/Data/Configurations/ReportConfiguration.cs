using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmaguciaiDomain.Entities;

namespace SmaguciaiInfrastructure.Data.Configurations;

public class ReportConfiguration : IEntityTypeConfiguration<Report>
{
    public void Configure(EntityTypeBuilder<Report> builder)
    {
        builder
            .HasOne(p => p.Review)
            .WithMany(c => c.Report)
            .HasForeignKey(p => p.ReviewId);
        builder
            .HasOne(p => p.User)
            .WithMany(m => m.Report)
            .HasForeignKey(p => p.UserID)
            .OnDelete(DeleteBehavior.NoAction);
    }
}