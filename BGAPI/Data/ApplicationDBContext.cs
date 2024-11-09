using BGAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BGAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
            
        }

        public DbSet<BlogPosts> BlogPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPosts>().Property(b => b.Quote).HasMaxLength(100);
        }
    }
}
