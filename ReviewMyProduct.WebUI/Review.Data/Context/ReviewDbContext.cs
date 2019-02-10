using Microsoft.EntityFrameworkCore;
using Review.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Review.Data.Context
{
    public class ReviewDbContext : DbContext
    {
        public ReviewDbContext(DbContextOptions<ReviewDbContext> options): base(options) { }
        // Interpret Models -> db entities
        // query those entities (tables)
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFromShop> ProductFromShops { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
