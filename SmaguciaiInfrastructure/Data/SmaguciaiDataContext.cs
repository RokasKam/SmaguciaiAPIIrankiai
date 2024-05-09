using Microsoft.EntityFrameworkCore;
using SmaguciaiDomain.Entities;
using SmaguciaiInfrastructure.Data.Configurations;

namespace SmaguciaiInfrastructure.Data;

public class SmaguciaiDataContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Photo> Photos { get; set; }
    public DbSet<Review> Review { get; set; }
    public DbSet<ShippingAddress> ShippingAddresses { get; set; }
    public DbSet<DiscountCode> DiscountCodes { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderPorduct> OrderPorducts { get; set; }
    public DbSet<Report> Reports { get; set; }
    public SmaguciaiDataContext(DbContextOptions<SmaguciaiDataContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PhotoConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReviewConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShippingAddressConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DiscountCodeConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderProductConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReportConfiguration).Assembly);
    }
}