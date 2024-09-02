using Microsoft.EntityFrameworkCore;
using POC.Models;

namespace POC.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
                
        }
        public DbSet<CrudItem> CrudItems { get; set; }
        public DbSet<UserAccount> userAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
