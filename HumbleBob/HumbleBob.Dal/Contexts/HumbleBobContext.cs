using HumbleBob.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace HumbleBob.Dal.Contexts
{
    public class HumbleBobContext : DbContext
    {
        public HumbleBobContext() { }

        public HumbleBobContext(DbContextOptions<HumbleBobContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasIndex(i => i.Name).IsUnique();
            modelBuilder.Entity<Item>().Property(i => i.Price).HasColumnType("decimal(18,2)");
        }
    }
}
