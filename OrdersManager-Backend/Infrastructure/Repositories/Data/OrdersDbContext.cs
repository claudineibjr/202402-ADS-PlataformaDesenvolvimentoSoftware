using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace Infrastructure.Repositories.Data;

public partial class OrdersDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }

    public OrdersDbContext()
    {
    }

    public OrdersDbContext(DbContextOptions<OrdersDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
        .HasCharSet("utf8mb4");

        modelBuilder.Entity<Customer>()
            .HasKey(c => c.Id);
        modelBuilder.Entity<Customer>()
            .Property(c => c.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Order>()
            .HasKey(o => o.Id);
        modelBuilder.Entity<Order>()
            .Property(o => o.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<OrderItem>()
            .HasKey(oi => oi.Id);
        modelBuilder.Entity<OrderItem>()
            .Property(oi => oi.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Product>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<Product>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
