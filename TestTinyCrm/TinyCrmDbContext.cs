using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestTinyCrm
{
    public class TinyCrmDbContext : DbContext
    {
        private readonly String connectionString = "Server=localhost; Database=crm2; User Id=sa; Password=admin!@#123;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>()
                        .ToTable("Customer");
            modelBuilder.Entity<Product>()
                        .ToTable("Product");
            modelBuilder.Entity<Order>()
                        .ToTable("Order");
            modelBuilder.Entity<OrderProduct>()
                        .ToTable("OrderProduct");
            modelBuilder.Entity<OrderProduct>()
                        .HasKey(op => new { op.ProductId, op.OrderId });
        }
    }
}
