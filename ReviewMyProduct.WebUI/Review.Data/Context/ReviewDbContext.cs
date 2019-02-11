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
        public DbSet<ProductFromShop> ProductFromShops { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<User> Users { get; set; }

        // Setting up the provider (SQL Server) and location of a database
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            // Bad way of providing the connection string
            optionBuilder.UseSqlServer(@"Sever=(localdb)\mssqllocaldb;Database=review;Trusted_Connection=True");
        }
        
        // Seeding - Populate database with initial data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rating>().HasData(
                new Rating { Id = 1, ThumbsUp = true },
                new Rating { Id = 2, ThumbsUp = false }
                );
        }
    }
}
