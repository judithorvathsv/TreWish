using Microsoft.EntityFrameworkCore;
using TreWishApi.Models;

namespace Backend.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {                 
        }

         public DbSet<Wish> Wishes {get; set;}  

         public DbSet<User> Users {get; set;}         
    }
}