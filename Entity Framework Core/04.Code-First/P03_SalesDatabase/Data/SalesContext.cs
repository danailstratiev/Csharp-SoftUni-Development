using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_SalesDatabase.Data
{
   public class SalesContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConigureProduct(modelBuilder);

            ConigureCustomer(modelBuilder);

            ConigureStore(modelBuilder);

            ConigureSale(modelBuilder);

        }

        private void ConigureSale(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Sale>()
                .HasKey(s => s.SaleId);

            // No need to describe more because the properties are describet in other methods

            modelBuilder
                .Entity<Sale>()
                .Property(d => d.Date)
                .HasDefaultValueSql("GETDATE()");
        }

        private void ConigureCustomer(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Customer>()
                .HasKey(s => s.CustomerId);

            modelBuilder
                .Entity<Customer>()
                .Property(s => s.Name)
                .HasMaxLength(100)
                .IsUnicode();

            modelBuilder
                .Entity<Customer>()
                .Property(s => s.Email)
                .HasMaxLength(100)
                .IsUnicode();

            modelBuilder
                .Entity<Customer>()
                .HasMany(s => s.Sales)
                .WithOne(s => s.Customer);
        }

        private void ConigureStore(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Store>()
                .HasKey(s => s.StoreId);

            modelBuilder
                .Entity<Store>()
                .Property(s => s.Name)
                .HasMaxLength(80)
                .IsUnicode();
                        
            modelBuilder
                .Entity<Store>()
                .HasMany(s => s.Sales)
                .WithOne(s => s.Store);
        }

        private void ConigureProduct(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Product>()
                .HasKey(p => p.ProductId);

            modelBuilder
                .Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode();

            modelBuilder
               .Entity<Product>()
               .Property(d => d.Description)
               .HasMaxLength(250);

            modelBuilder
                .Entity<Product>()
                .HasMany(s => s.Sales)
                .WithOne(p => p.Product);           
        }
    }
}
