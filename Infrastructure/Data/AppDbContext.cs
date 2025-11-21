using Domain.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("AppDbContext") { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
              .HasKey(c => c.CustomerId);

            modelBuilder.Entity<Product>()
                .HasKey(p => p.ProductId);

            modelBuilder.Entity<Order>()
                .HasKey(o => o.Id);
            modelBuilder.Entity<Order>()
                .Property(o => o.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);

            modelBuilder.Entity<Order>()
               .HasRequired(o => o.Customer)
               .WithMany(p => p.Orders)
               .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<Order>()
                .HasRequired(o => o.Product)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.ProductId);
        }

    }
}
