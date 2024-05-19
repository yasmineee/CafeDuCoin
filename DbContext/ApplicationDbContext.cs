using CafeDuCoin.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeDuCoin
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<GameHistory> GameHistories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>().HasData(
            new Game { Id = 1, Name = "monopoli" },
            new Game { Id = 2, Name = "uno" },
            new Game { Id = 3, Name = "scrable" }
        );
            modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Login = "yasmine",Password="yasmine"  },
            new User { Id = 2, Login = "test", Password = "test" }
        );
        }
    }
}
