using Microsoft.EntityFrameworkCore;
using Review.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Review.Data.Context
{
    public class ReviewDbContext : DbContext
    {
        // Interpret Models -> db entities
        // query those entities (tables)
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        // Setting up the provider (SQL Server) and location of a database
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            // Bad way of providing the connection string
            optionBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=review;Trusted_Connection=True");
        }
        
        // Seeding - Populate database with initial data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductFromShop>()
                .HasKey(ps => new { ps.ProductId, ps.ShopId });

            modelBuilder.Entity<ProductFromShop>()
                .HasOne<Product>(ps => ps.Product)
                .WithMany(p => p.ProductFromShops)
                .HasForeignKey(ps => ps.ProductId);
            modelBuilder.Entity<ProductFromShop>()
                .HasOne<Shop>(ps => ps.Shop)
                .WithMany(s => s.ProductFromShops)
                .HasForeignKey(ps => ps.ShopId);
        }
    }
}
