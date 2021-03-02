using Microsoft.EntityFrameworkCore;

namespace AngularNetCore.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            // Database.EnsureCreated();
        }
        public DbSet<User> Users {get; set;}
        public DbSet<Settings> Settings { get; set; }

    }
}