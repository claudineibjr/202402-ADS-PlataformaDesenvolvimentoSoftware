using Microsoft.EntityFrameworkCore;
using Projeto01_OrdersManager.Core.Models;

namespace Projeto01_OrdersManager.Repositories.Data;

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

        modelBuilder.Entity<Order>()
            .HasKey(o => o.Id);
        modelBuilder.Entity<Order>()
            .Property(o => o.Id)
            .ValueGeneratedOnAdd();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
