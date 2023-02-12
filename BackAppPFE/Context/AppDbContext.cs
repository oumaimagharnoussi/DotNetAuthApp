using BackAppPFE.Models;
using Microsoft.EntityFrameworkCore;

namespace BackAppPFE.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
        }

        internal object GetSection(string v)
        {
            throw new NotImplementedException();
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Models.Type> Types { get; set; }

    }
   
}
