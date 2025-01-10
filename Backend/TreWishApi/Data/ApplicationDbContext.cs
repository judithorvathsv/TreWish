using Microsoft.EntityFrameworkCore;
using TreWishApi.Models;

namespace Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Wish> Wishes { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wish>()
                        .HasOne(m => m.Wisher)
                        .WithMany(t => t.WishedWishes)
                        .HasForeignKey(m => m.WisherId)
                        .IsRequired();

            modelBuilder.Entity<Wish>()
                        .HasOne(w => w.Purchaser)
                        .WithMany(u => u.PurchasedWishes)
                        .HasForeignKey(w => w.PurchaserId);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "User 1" },
                new User { Id = 2, Name = "User 2" },
                new User { Id = 3, Name = "User 3" },
                new User { Id = 4, Name = "User 4" },
                new User { Id = 5, Name = "User 5" }
            );

            modelBuilder.Entity<Wish>().HasData(
                new Wish { Id = 1, Name = "Wish 1", Description = "Wish 1 Description", Price = 1.1, WisherId = 1 },
                new Wish { Id = 2, Name = "Wish 2", Description = "Wish 2 Description", Price = 2.2, WisherId = 1, PurchaserId = 2 },
                new Wish { Id = 3, Name = "Wish 3", Description = "Wish 3 Description", Price = 3.3, WisherId = 1, PurchaserId = 2 },
                new Wish { Id = 4, Name = "Wish 4", Description = "Wish 4 Description", Price = 4.4, WisherId = 2, PurchaserId = 3 },
                new Wish { Id = 5, Name = "Wish 5", Description = "Wish 5 Description", Price = 5.5, WisherId = 3, PurchaserId = 1 }
            );
        }


    }
}