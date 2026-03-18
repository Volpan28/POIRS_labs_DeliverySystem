using Delivery.Application.Interfaces;
using Delivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Delivery.Infrastructure.Data;

public class AppDbContext : DbContext, IAppDbContext
{
    public DbSet<Courier> Couriers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Route> Routes { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken)
    {
        return await Database.BeginTransactionAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .HasOne<Client>()
            .WithMany()
            .HasForeignKey(o => o.ClientId)
            .IsRequired();
        
        modelBuilder.Entity<Order>()
            .HasOne<Courier>()
            .WithMany()
            .HasForeignKey(o => o.CourierId)
            .IsRequired(false);

        modelBuilder.Entity<Route>()
            .HasOne<Order>()
            .WithOne()
            .HasForeignKey<Route>("OrderId")
            .IsRequired(false);

    }
}