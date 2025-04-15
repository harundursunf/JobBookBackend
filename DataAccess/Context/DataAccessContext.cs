using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class DataAccessContext : DbContext
    {
        public DataAccessContext(DbContextOptions<DataAccessContext> options) : base(options) // Constructor
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>()
                        .HasOne(j => j.User)
                        .WithMany(u => u.Jobs)
                        .HasForeignKey(j => j.UserID);
        }
    }
}
