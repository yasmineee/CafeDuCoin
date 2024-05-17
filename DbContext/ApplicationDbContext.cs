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

            modelBuilder.Entity<GameHistory>()
                .Property(g => g.BorrowDate)
                .HasColumnType("date");

            modelBuilder.Entity<GameHistory>()
                .Property(g => g.ReturnDate)
                .HasColumnType("date");
           
            modelBuilder.Entity<GameHistory>()
                .Property(g => g.State)
                .HasConversion<string>()
                .HasDefaultValue(GameState.Free);
        }
    }
}
