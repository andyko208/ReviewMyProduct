using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Review.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Review.Data.Context
{
    public class ReviewDbContext : IdentityDbContext<AppUser>
    {
        // Interpret Models -> db entities
        // query those entities (tables)

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        // Setting up the provider (SQL Server) and location of a database
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            // Local machine
            optionBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=review;Trusted_Connection=True");
            
            // Sql database for azure
            //optionBuilder.UseSqlServer(@"Server=tcp:rhrudaud0.database.windows.net,1433;Initial Catalog=ReviewMyProduct;Persist Security Info=False;User ID=rhrudaud0;Password=Ksy28188;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        
        // Seeding - Populate database with initial data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .HasConstraintName("ForeignKey_Comment_AppUser");

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.User)
                .WithMany(u => u.Ratings)
                .HasForeignKey(r => r.UserId)
                .HasConstraintName("ForeignKey_Rating_AppUser");

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "user", NormalizedName = "USER" },
                new IdentityRole { Name = "administrator", NormalizedName = "ADMINISTRATOR" }
                );

        }
    }
}
